module DavidTimovskiWebsite.BlogPostsRepository

open System
open Dapper
open Npgsql
open Models

let getLatest (connection : NpgsqlConnection) =
    connection.QueryFirst<Post> @"SELECT * FROM ""Posts"" WHERE ""Status"" = 1 ORDER BY ""DateCreated"" DESC"

let getById (id : int) (connection : NpgsqlConnection) =
    connection.QueryFirst<Post>(@"SELECT * FROM ""Posts"" WHERE ""Id"" = @Id AND ""Status"" = 1", {|Id = id|})

let getPrevious (dateCreated : DateTime) (connection : NpgsqlConnection) =
    connection.QueryFirstOrDefault<Post>(@"SELECT ""Id"", ""Title"" FROM ""Posts""
                             WHERE ""Status"" = 1 AND ""DateCreated"" < @DateCreated
                             ORDER BY ""DateCreated"" DESC", {|DateCreated = dateCreated|})

let getNext (dateCreated : DateTime) (connection : NpgsqlConnection) =
    connection.QueryFirstOrDefault<Post>(@"SELECT ""Id"", ""Title"" FROM ""Posts""
                             WHERE ""Status"" = 1 AND ""DateCreated"" > @DateCreated
                             ORDER BY ""DateCreated""", {|DateCreated = dateCreated|})

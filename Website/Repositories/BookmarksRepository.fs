module DavidTimovskiWebsite.BookmarksRepository

open Dapper
open Npgsql

let getAll(connection:NpgsqlConnection) =
    connection.Query<'Bookmark> @"SELECT * FROM ""Bookmarks"" ORDER BY ""Id"" DESC"
    |> Seq.toList

module DavidTimovskiWebsite.ExpertiseRepository

open Dapper
open Npgsql
open Models

let getAll(connection : NpgsqlConnection) =
    let expertise = 
        connection.Query<Expertise> @"SELECT * FROM ""Expertise"""
        |> Seq.toList

    let expertiseTags = 
        connection.Query<ExpertiseTag> @"SELECT * FROM ""ExpertiseTags"""
        |> Seq.toList

    let tags : list<Tag> = 
        connection.Query<Tag> @"SELECT * FROM ""Tags"""
        |> Seq.toList

    let getExpertiseWithTags (expertise : Expertise) expertiseTags (tags : list<Tag>) = 
        let et = List.where (fun et -> et.ExpertiseId = expertise.Id) expertiseTags
        let tagsInExpertise = 
            let expertiseTagsContainsTag (tag : Tag) = List.exists (fun e -> tag.Id = e.TagId) et

            List.where expertiseTagsContainsTag tags
            |> List.map (fun(t) -> t.Name)
            
        { 
            Id = expertise.Id; 
            Tech = expertise.Tech; 
            Answer = expertise.Answer; 
            Description = expertise.Description; 
            ImageUri = expertise.ImageUri; 
            Tags = tagsInExpertise 
        }
    
    expertise |> List.map (fun(e) -> getExpertiseWithTags e expertiseTags tags) 
    
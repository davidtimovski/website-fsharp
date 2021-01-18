module DavidTimovskiWebsite.Models

open System

[<CLIMutable>]
type Expertise =
    {
        Id : int
        Tech : string
        Answer : string
        Description : string
        ImageUri : string
        Tags : string list
    }
    
[<CLIMutable>]
type Tag =
    {
        Id : int
        Name : string
    }

[<CLIMutable>]
type ExpertiseTag =
    {
        ExpertiseId : int
        TagId : int
    }

[<CLIMutable>]
type Post =
    {
        Id : int
        Title : string
        Body : string
        Status : byte
        DateCreated : DateTime
        DateModified : DateTime
    }

type PostViewModel(title : string, body : string, date : string, previousPostId : Option<int>, previousPostTitle : Option<string>, nextPostId : Option<int>, nextPostTitle : Option<string>) =
    member this.Title = title
    member this.Body = body
    member this.Date = date
    member this.PreviousPostId = previousPostId
    member this.PreviousPostTitle = previousPostTitle
    member this.NextPostId = nextPostId
    member this.NextPostTitle = nextPostTitle

type BookmarkType = 
    | Article = 0
    | Video = 1
    | Tool = 2

[<CLIMutable>]
type Bookmark = 
    {
        Title : string
        Type : BookmarkType
        Author : string
        Url : string
    }
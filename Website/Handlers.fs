module DavidTimovskiWebsite.Handlers

open System
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.Logging
open Giraffe
open Npgsql
open DavidTimovskiWebsite.Views
open Models

let getConnection (ctx : HttpContext) =
    let configuration = ctx.GetService<IConfiguration>()
    new NpgsqlConnection(configuration.["ConnectionStrings:DefaultConnectionString"])

[<Literal>]
let private WeekInSeconds = 604800

let private weekResponseCaching : HttpHandler =
    publicResponseCaching WeekInSeconds None

let private toPostViewModel (post: Post) (previousPost: Post) (nextPost: Post) =
    let previousPostId =
        if previousPost |> box |> isNotNull then Some(previousPost.Id)
        else None
    let previousPostTitle =
        if previousPost |> box |> isNotNull then Some(previousPost.Title)
        else None

    let nextPostId =
        if nextPost |> box |> isNotNull then Some(nextPost.Id)
        else None
    let nextPostTitle =
        if nextPost |> box |> isNotNull then Some(nextPost.Title)
        else None

    PostViewModel(post.Title, post.Body, post.DateCreated.ToString("dd MMMM yyyy"), previousPostId, previousPostTitle, nextPostId, nextPostTitle)


let blogHandler : HttpHandler =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        let conn = getConnection ctx
        let post = BlogPostsRepository.getLatest conn
        let previousPost = BlogPostsRepository.getPrevious post.DateCreated conn
        let nextPost = BlogPostsRepository.getNext post.DateCreated conn

        let postViewModel = toPostViewModel post previousPost nextPost

        let view = Blog.view postViewModel
        htmlView view next ctx

let blogWithParamHandler (id : int) : HttpHandler =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        let conn = getConnection ctx
        let post = BlogPostsRepository.getById id conn
        let previousPost = BlogPostsRepository.getPrevious post.DateCreated conn
        let nextPost = BlogPostsRepository.getNext post.DateCreated conn

        let postViewModel = toPostViewModel post previousPost nextPost

        let view = Blog.view postViewModel
        htmlView view next ctx

let blogWithParamAndSlugHandler (id : int, _ : string) : HttpHandler =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        let conn = getConnection ctx
        let post = BlogPostsRepository.getById id conn
        let previousPost = BlogPostsRepository.getPrevious post.DateCreated conn
        let nextPost = BlogPostsRepository.getNext post.DateCreated conn

        let postViewModel = toPostViewModel post previousPost nextPost

        let view = Blog.view postViewModel
        htmlView view next ctx

let expertiseHandler : HttpHandler =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        let conn = getConnection ctx
        let model = ExpertiseRepository.getAll conn
        json model next ctx

let bookmarksHandler : HttpHandler =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        let conn = getConnection ctx
        let model = BookmarksRepository.getAll conn

        let view = Bookmarks.view model
        htmlView view next ctx

let errorHandler (ex : Exception) (logger : ILogger) =
    logger.LogError(ex, "An unhandled exception has occurred while executing the request.")
    clearResponse >=> setStatusCode 500 >=> text ex.Message

let webApp : (HttpFunc -> HttpContext -> HttpFuncResult) =
    choose [
        GET >=>
            choose [
                route "/" >=> weekResponseCaching >=> (htmlView Home.index)
                route "/sapphire-notes" >=> weekResponseCaching >=> (htmlView Home.sapphireNotes)
                route "/my-projects" >=> weekResponseCaching >=> (htmlView MyProjects.index)
                route "/my-projects/temporal" >=> weekResponseCaching >=> (htmlView MyProjects.temporal)
                route "/blog" >=> blogHandler
                routef "/blog/%i" blogWithParamHandler
                routef "/blog/%i/%s" blogWithParamAndSlugHandler
                route "/bookmarks" >=> weekResponseCaching >=> bookmarksHandler
                route "/api/expertise" >=> weekResponseCaching >=> expertiseHandler
            ]
        setStatusCode 404 >=> text "Not Found" ]

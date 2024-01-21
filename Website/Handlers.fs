module DavidTimovskiWebsite.Handlers

open System
open System.Collections.Generic
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.Logging
open Giraffe
open Npgsql
open DavidTimovskiWebsite.Views
open Models
open Website.Services

let getConnection (ctx : HttpContext) =
    let configuration = ctx.GetService<IConfiguration>()
    new NpgsqlConnection(configuration.["ConnectionStrings:DefaultConnectionString"])

let logHit (ctx : HttpContext) (route : string) =
    let metrics = ctx.GetService<MetricsService>()
    metrics.HitsCounter.Add(1, new KeyValuePair<string, obj>(MetricsService.RouteTag, route)) |> ignore

let logHitMetric (route : string) : HttpHandler =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        logHit ctx route |> ignore
        next ctx

[<Literal>]
let private twoHoursInSeconds = 7200

let private responseCaching : HttpHandler =
    publicResponseCaching twoHoursInSeconds None

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

let sapphireNotesHandler : HttpHandler =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        let configuration = ctx.GetService<IConfiguration>()
        let viewModel = configuration.GetSection("SapphireNotes").Get<SapphireNotesViewModel>()

        let view = Home.SapphireNotes.sapphireNotes viewModel
        htmlView view next ctx

let teamSketchHandler : HttpHandler =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        let configuration = ctx.GetService<IConfiguration>()
        let viewModel = configuration.GetSection("TeamSketch").Get<TeamSketchViewModel>()

        let view = Home.TeamSketch.teamSketch viewModel
        htmlView view next ctx

let blogHandler : HttpHandler =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        let conn = getConnection ctx
        let post = BlogPostsRepository.getLatest conn
        let previousPost = BlogPostsRepository.getPrevious post.DateCreated conn
        let nextPost = BlogPostsRepository.getNext post.DateCreated conn

        let viewModel = toPostViewModel post previousPost nextPost

        let view = Blog.view viewModel
        htmlView view next ctx

let blogWithParamHandler (id : int) : HttpHandler =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        logHit ctx $"/blog/{id}" |> ignore

        let conn = getConnection ctx
        let post = BlogPostsRepository.getById id conn
        let previousPost = BlogPostsRepository.getPrevious post.DateCreated conn
        let nextPost = BlogPostsRepository.getNext post.DateCreated conn

        let postViewModel = toPostViewModel post previousPost nextPost

        let view = Blog.view postViewModel
        htmlView view next ctx

let blogWithParamAndSlugHandler (id : int, _ : string) : HttpHandler =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        logHit ctx $"/blog/{id}" |> ignore

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
                route "/" >=> logHitMetric "/" >=> responseCaching >=> (htmlView Home.Index.index)
                route "/sapphire-notes" >=> logHitMetric "/sapphire-notes" >=> sapphireNotesHandler
                route "/team-sketch" >=> logHitMetric "/team-sketch" >=> teamSketchHandler
                route "/my-projects" >=> logHitMetric "/my-projects" >=> responseCaching >=> (htmlView MyProjects.index)
                route "/my-projects/temporal" >=> logHitMetric "/my-projects/temporal" >=> responseCaching >=> (htmlView MyProjects.temporal)
                route "/blog" >=> logHitMetric "/blog" >=> blogHandler
                routef "/blog/%i" blogWithParamHandler
                routef "/blog/%i/%s" blogWithParamAndSlugHandler
                route "/bookmarks" >=> logHitMetric "/bookmarks" >=> responseCaching >=> bookmarksHandler
                route "/api/expertise" >=> responseCaching >=> expertiseHandler
            ]
        setStatusCode 404 >=> text "Not Found" ]

module DavidTimovskiWebsite.App

open System
open System.IO
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Giraffe
open Handlers

let configureApp (app : IApplicationBuilder) =
    let env = app.ApplicationServices.GetService<IWebHostEnvironment>()

    app.UseStaticFiles() |> ignore

    (match env.IsDevelopment() with
    | true  ->
        app.UseDeveloperExceptionPage()
    | false ->
        app.UseGiraffeErrorHandler(errorHandler)
           .UseResponseCaching())
           
        .UseGiraffe(webApp)

let configureAppConfiguration (context: WebHostBuilderContext) (config: IConfigurationBuilder) = 
    config
        .AddJsonFile("appsettings.json", false, true)
        .AddJsonFile(sprintf "appsettings.%s.json" context.HostingEnvironment.EnvironmentName, true)
        .AddEnvironmentVariables() |> ignore

let configureServices (services : IServiceCollection) =
    services.AddApplicationInsightsTelemetry()
            .AddResponseCaching()
            .AddGiraffe() |> ignore
            
    services.AddSingleton<Json.ISerializer>(SystemTextJson.Serializer(SystemTextJson.Serializer.DefaultOptions)) |> ignore

[<EntryPoint>]
let main args =
    let contentRoot = Directory.GetCurrentDirectory()
    let webRoot     = Path.Combine(contentRoot, "WebRoot")
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(
            fun webHostBuilder ->
                webHostBuilder
                    .UseContentRoot(contentRoot)
                    .UseWebRoot(webRoot)
                    .ConfigureAppConfiguration(configureAppConfiguration)
                    .Configure(Action<IApplicationBuilder> configureApp)
                    .ConfigureServices(configureServices)
                    .UseUrls("http://localhost:5051")
                    |> ignore)
        .Build()
        .Run()
    0
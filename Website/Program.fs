module DavidTimovskiWebsite.App

open System
open System.Globalization
open System.IO
open Microsoft.ApplicationInsights.Extensibility
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Primitives
open Giraffe
open Handlers

let configureApp (app : IApplicationBuilder) =
    let env = app.ApplicationServices.GetService<IWebHostEnvironment>()
    (match env.IsDevelopment() with
    | true  ->
        let telemetryConfiguration = 
            app.ApplicationServices.GetService<TelemetryConfiguration>()
        telemetryConfiguration.DisableTelemetry <- true

        app.UseDeveloperExceptionPage()
           .UseStaticFiles()
    | false ->
        app.UseGiraffeErrorHandler(errorHandler)
           .UseStaticFiles(
               StaticFileOptions(
                   ServeUnknownFileTypes = true,
                   OnPrepareResponse = 
                       fun ctx ->
                           let yearInSeconds = 12 * 30 * 24 * 60 * 60;
                           ctx.Context.Response.Headers.Append("Cache-Control", StringValues($"public,max-age={yearInSeconds}"))
                           ctx.Context.Response.Headers.Append("Expires", StringValues(DateTime.UtcNow.AddMonths(12).ToString("R", CultureInfo.InvariantCulture)))
                   )
           )
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
            
    let serializationOptions = SystemTextJson.Serializer.DefaultOptions
    services.AddSingleton<Json.ISerializer>(SystemTextJson.Serializer(serializationOptions)) |> ignore

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
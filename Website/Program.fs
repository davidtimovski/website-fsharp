module DavidTimovskiWebsite.App

open System
open System.IO
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Giraffe
open OpenTelemetry.Metrics
open Handlers
open Metrics
open Configuration

let configureApp (app : IApplicationBuilder) =
    let env = app.ApplicationServices.GetService<IWebHostEnvironment>()

    app.UseStaticFiles() |> ignore

    app.UseRouting()
        .UseEndpoints(fun config ->
            config.MapPrometheusScrapingEndpoint() |> ignore
        ) |> ignore

    (match env.IsDevelopment() with
    | true  ->
        app.UseDeveloperExceptionPage()
    | false ->
        app.UseGiraffeErrorHandler(errorHandler)
           .UseResponseCaching())
           
        .UseGiraffe webApp

let configureAppConfiguration (context: WebHostBuilderContext) (config: IConfigurationBuilder) = 
    config
        .AddJsonFile("appsettings.json", false, true)
        .AddJsonFile(sprintf "appsettings.%s.json" context.HostingEnvironment.EnvironmentName, true)
        .AddEnvironmentVariables() |> ignore

let configureServices (services : IServiceCollection) =
    services.AddApplicationInsightsTelemetry()
            .AddResponseCaching()
            .AddGiraffe() |> ignore
            
    services.AddOpenTelemetry()
        .WithMetrics(fun opt ->
            opt.AddPrometheusExporter() |> ignore

            opt.AddMeter("Microsoft.AspNetCore.Hosting", "Microsoft.AspNetCore.Server.Kestrel", "Website") |> ignore

            opt.AddView("http.server.request.duration", new ExplicitBucketHistogramConfiguration( Boundaries = [| 0; 0.005; 0.01; 0.025; 0.05; 0.075; 0.1; 0.25; 0.5; 0.75; 1; 2.5; 5; 7.5; 10 |] )) |> ignore
        ) |> ignore

    services.AddSingleton<MetricsService>() |> ignore

    // Configure options
    let serviceProvider = services.BuildServiceProvider()
    let configuration =
        serviceProvider.GetService<IConfiguration>()

    services.Configure<DatabaseOptions>(
        configuration.GetSection("ConnectionStrings")) |> ignore
    services.Configure<SapphireNotesOptions>(
        configuration.GetSection("SapphireNotes")) |> ignore
    services.Configure<TeamSketchOptions>(
        configuration.GetSection("TeamSketch")) |> ignore

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
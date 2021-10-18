namespace FSEFCore

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.HttpsPolicy;
open Microsoft.AspNetCore.Mvc
open Microsoft.EntityFrameworkCore
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open EntityFrameworkCore.FSharp

type Startup(configuration: IConfiguration) =
    member _.Configuration = configuration

    member _.ConfigureServices(services: IServiceCollection) =
        services
            //.AddDbContext<Context>(fun options -> options.UseNpgsql("Server=localhost;Port=5432;User Id=postgres;Password=posgres;Database=foodb") |> ignore)
            .AddDbContext<Context>(fun options -> options.UseSqlServer("Server=localhost;Database=BarDb;User=sa;Password=Senha@123;MultipleActiveResultSets=True") |> ignore)

            .AddControllers() |> ignore

    member _.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =
        if (env.IsDevelopment()) then
            app.UseDeveloperExceptionPage() |> ignore
        app.UseHttpsRedirection()
           .UseRouting()
           .UseAuthorization()
           .UseEndpoints(fun endpoints ->
                endpoints.MapControllers() |> ignore
            ) |> ignore

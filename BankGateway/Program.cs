
using Microsoft.AspNetCore.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text;
/*void ConfigureServices(IServiceCollection services)
{
    services.AddOcelot();
}
static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                    webBuilder.ConfigureAppConfiguration(config =>
                        config.AddJsonFile($"ocelot.{env}.json"));
                })
            .ConfigureLogging(logging => logging.AddConsole());*/


var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("ocelot.json");
builder.Services.AddOcelot();


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

app.UseOcelot().Wait();
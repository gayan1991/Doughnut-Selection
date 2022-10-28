using ApiGateway;

var builder = Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
{
    webBuilder.UseStartup<StartUp>();
    webBuilder.ConfigureAppConfiguration(config =>
    {
        config.AddJsonFile($"ocelot.json");
    });
});

// Add services to the container.

var app = builder.Build();

app.Run();

using AdminApi;
using Microsoft.AspNetCore.Mvc.Rendering;

//var builder = WebApplication.CreateBuilder(args);

var builder = Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
{
    var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                        webBuilder.UseStartup<StartUp>();
                        webBuilder.ConfigureAppConfiguration(config =>
                        {
                            //config.AddJsonFile($"ocelot.{env}.json");
                        });
});

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();



app.Run();

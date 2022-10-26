using Microsoft.Extensions.DependencyInjection;
using Shard.Api.model;
using Shard.Shared.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<MapGenerator>();
builder.Configuration.GetSection("MapGeneratorOptions");
builder.Services.AddSingleton<Sector>();
builder.Services.AddSingleton<List<User>>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Services.GetService<Sector>();

app.UseAuthorization();

app.MapControllers();

app.Run();
namespace Shard.Api
{
    public partial class Program { }
}

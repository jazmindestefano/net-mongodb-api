using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MFlixApi.Models;
using MFlixApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<MoviesStoreDatabaseSettings>(
    builder.Configuration.GetSection(nameof(MoviesStoreDatabaseSettings)));

builder.Services.AddSingleton<IMoviesStoreDatabaseSettings>(sp => sp.GetRequiredService<IOptions<MoviesStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("MoviesStoreDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IMovieService, MovieService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


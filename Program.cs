using Microsoft.EntityFrameworkCore;
using MusicDataBaseEntityFramework.Entities;
using SpotifyClone.Core.DataBase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyMusicDbContext>(
    op => op.UseSqlServer(builder.Configuration.GetConnectionString("MainDatabaseConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//automaticly updating migrations
var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<MyMusicDbContext>();
var pendingMigrations = dbContext.Database.GetPendingMigrations();
if(pendingMigrations.Any())
{
    dbContext.Database.Migrate();
}

DataGenerator.GenerateData(dbContext);

app.MapGet("Endpoint", (MyMusicDbContext db) =>
{
    var list = db.Songs.Where(x => x.Performer.Name == "compressing transition").ToList();
    return list;
});

app.Run();


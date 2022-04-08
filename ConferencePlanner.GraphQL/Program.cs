using ConferencePlanner.GraphQL.Database;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = @"Data Source=Database\conferences.db"; 
builder.Services.AddDbContext<ConferenceDb>(options =>
    options.UseSqlite(connectionString));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

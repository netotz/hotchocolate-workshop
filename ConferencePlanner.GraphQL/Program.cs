using ConferencePlanner.GraphQL.Database;
using ConferencePlanner.GraphQL.Features;
using ConferencePlanner.GraphQL.Features.Speakers;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = @"Data Source=Database\conferences.db"; 
builder.Services.AddDbContext<ConferenceDb>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();


var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapGraphQL());  

app.MapGet("/", () => "Hello World!");

app.Run();

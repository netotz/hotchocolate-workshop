using ConferencePlanner.GraphQL.Database;
using ConferencePlanner.GraphQL.Features.Sessions;
using ConferencePlanner.GraphQL.Features.Speakers;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = @"Data Source=Database\conferences.db"; 
// pooled factory allows parallel queries
builder.Services.AddPooledDbContextFactory<ConferenceDb>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddGraphQLServer()
    .AddQueryType<SpeakerQuery>()
    .AddMutationType<SpeakerMutation>()
    .AddDataLoader<SpeakerByIdDataLoader>()
    .AddDataLoader<SessionByIdDataLoader>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGraphQL();

app.Run();

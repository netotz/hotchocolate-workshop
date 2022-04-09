using ConferencePlanner.GraphQL.Database;
using ConferencePlanner.GraphQL.Database.Entities;
using ConferencePlanner.GraphQL.Extensions;

using Microsoft.EntityFrameworkCore;

namespace ConferencePlanner.GraphQL.Features.Speakers;

public class Query
{
    [UseConferenceDb]
    public Task<List<Speaker>> GetSpeakers([ScopedService] ConferenceDb conferenceDb)
    {
        return conferenceDb.Speakers.ToListAsync();
    }
}

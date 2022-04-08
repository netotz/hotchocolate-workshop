using ConferencePlanner.GraphQL.Database;
using ConferencePlanner.GraphQL.Database.Entities;

namespace ConferencePlanner.GraphQL.Features.Speakers;

public class Query
{
    public IQueryable<Speaker> GetSpeakers([Service] ConferenceDb conferenceDb)
    {
        return conferenceDb.Speakers;
    }
}

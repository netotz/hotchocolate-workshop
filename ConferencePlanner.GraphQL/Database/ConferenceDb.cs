using ConferencePlanner.GraphQL.Database.Entities;

using Microsoft.EntityFrameworkCore;

namespace ConferencePlanner.GraphQL.Database;

public class ConferenceDb : DbContext
{
    public DbSet<Speaker> Speakers { get; set; } = default!;
    public DbSet<Attendee> Attendees { get; set; } = default!;
    public DbSet<Session> Sessions { get; set; } = default!;
    public DbSet<Track> Tracks { get; set; } = default!;

    public ConferenceDb(DbContextOptions<ConferenceDb> options)
        : base(options)
    {
    }
}

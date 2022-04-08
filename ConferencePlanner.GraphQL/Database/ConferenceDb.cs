using ConferencePlanner.GraphQL.Database.Entities;

using Microsoft.EntityFrameworkCore;

namespace ConferencePlanner.GraphQL.Database;

public class ConferenceDb : DbContext
{
    public DbSet<Speaker> Speakers { get; set; }

    public ConferenceDb(DbContextOptions<ConferenceDb> options)
        : base(options)
    {
    }
}

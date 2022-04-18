using ConferencePlanner.GraphQL.Database;
using ConferencePlanner.GraphQL.Database.Entities;

using Microsoft.EntityFrameworkCore;

namespace ConferencePlanner.GraphQL.Features.Sessions;

public class SessionByIdDataLoader : BatchDataLoader<int, Session>
{
    private readonly IDbContextFactory<ConferenceDb> _dbContextFactory;

    public SessionByIdDataLoader(
        IBatchScheduler batchScheduler,
        IDbContextFactory<ConferenceDb> dbContextFactory)
        : base(batchScheduler)
    {
        _dbContextFactory = dbContextFactory;
    }

    protected override async Task<IReadOnlyDictionary<int, Session>> LoadBatchAsync(
        IReadOnlyList<int> keys,
        CancellationToken cancellationToken)
    {
        await using var conferenceDb = await _dbContextFactory.CreateDbContextAsync();

        return await conferenceDb.Sessions
            .Where(s => keys.Contains(s.Id))
            .ToDictionaryAsync(k => k.Id, cancellationToken);
    }
}

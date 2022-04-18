using ConferencePlanner.GraphQL.Database;
using ConferencePlanner.GraphQL.Database.Entities;

using Microsoft.EntityFrameworkCore;

namespace ConferencePlanner.GraphQL.Features.Speakers;

public class SpeakerByIdDataLoader : BatchDataLoader<int, Speaker>
{
    private readonly IDbContextFactory<ConferenceDb> _dbContextFactory;

    public SpeakerByIdDataLoader(
        IBatchScheduler batchScheduler,
        IDbContextFactory<ConferenceDb> dbContextFactory)
        : base(batchScheduler)
    {
        _dbContextFactory = dbContextFactory;
    }

    protected override async Task<IReadOnlyDictionary<int, Speaker>> LoadBatchAsync(
        IReadOnlyList<int> keys,
        CancellationToken cancellationToken)
    {
        await using var conferenceDb = await _dbContextFactory.CreateDbContextAsync();

        return await conferenceDb.Speakers
            .Where(s => keys.Contains(s.Id))
            .ToDictionaryAsync(k => k.Id, cancellationToken);
    }
}

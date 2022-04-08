using ConferencePlanner.GraphQL.Database;
using ConferencePlanner.GraphQL.Database.Entities;

namespace ConferencePlanner.GraphQL.Features.Speakers;

public record AddSpeakerInput(
    string Name,
    string? Biography,
    string? WebSite);

public record AddSpeakerPayload(Speaker Speaker);

public class Mutation
{
    public async Task<AddSpeakerPayload> AddSpeakerAsync(
            AddSpeakerInput input, [Service] ConferenceDb conferenceDb)
    {
        var newSpeaker = new Speaker
        {
            Name = input.Name,
            Biography = input.Biography,
            WebSite = input.WebSite
        };

        conferenceDb.Speakers.Add(newSpeaker);
        await conferenceDb.SaveChangesAsync();

        return new AddSpeakerPayload(newSpeaker);
    }
}

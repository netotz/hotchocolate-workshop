using System.ComponentModel.DataAnnotations;

namespace ConferencePlanner.GraphQL.Database.Entities;

public class Session
{
    public int Id { get; set; }

    [Required]
    public string? Title { get; set; }

    public string? Abstract { get; set; }

    public DateTimeOffset? StartTime { get; set; }

    public DateTimeOffset? EndTime { get; set; }

    // Bonus points to those who can figure out why this is written this way
    public TimeSpan Duration =>
        EndTime?.Subtract(StartTime ?? EndTime ?? DateTimeOffset.MinValue)
            ?? TimeSpan.Zero;

    public int? TrackId { get; set; }

    public ICollection<Speaker>? Speakers { get; set; }

    public ICollection<Attendee>? Attendees { get; set; }

    public Track? Track { get; set; }
}

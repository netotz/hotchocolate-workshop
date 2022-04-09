using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace ConferencePlanner.GraphQL.Database.Entities;

[Index(nameof(UserName), IsUnique = true)]
public class Attendee
{
    public int Id { get; set; }

    [Required]
    public string? FirstName { get; set; }

    [Required]
    public string? LastName { get; set; }

    [Required]
    public string? UserName { get; set; }

    public string? EmailAddress { get; set; }

    public ICollection<Session>? Sessions { get; set; }
}

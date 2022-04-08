using System.ComponentModel.DataAnnotations;

namespace ConferencePlanner.GraphQL.Database.Entities;

public class Speaker
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    public string? Biography { get; set; }
    public string? WebSite { get; set; }
}

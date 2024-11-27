namespace SuperAppBlazor.Shared.Services.SuperHeroService.Models;

public class InsertSuperHero
{
    public required string Name { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Place { get; set; } = string.Empty;

    public string Power { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
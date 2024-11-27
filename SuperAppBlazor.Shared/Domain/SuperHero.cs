namespace SuperAppBlazor.Shared.Domain;

public class SuperHero
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Place { get; set; } = string.Empty;

    public string Power { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
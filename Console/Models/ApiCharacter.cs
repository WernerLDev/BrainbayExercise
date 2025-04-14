namespace Models;

public record ApiCharacter
{
    public int? Id { get;init; }
    public string? Name { get; init; }

    public string? Status { get; init; }
    public string? Species { get; init; }
    public string? Type { get ; init; }
    public string? Gender { get; init; }
    public ApiLink? Origin { get; init; }
    public ApiLink? Location { get; init; }
}

namespace Models;

public record ResponseInfo {
    public int Count { get; init; }
    public int Pages { get; init; }
    public string? Next { get; init; }
    public string? Prev { get; init; }
}

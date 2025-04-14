namespace Models;

public record ApiResponse<T> {

    public required ResponseInfo Info { get; init; }
    public required IEnumerable<T> Results { get; init; }
    
}

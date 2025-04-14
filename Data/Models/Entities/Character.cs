namespace Brainbay.Models;

public class Character
{
  public int Id { get; set; }
  public string? Name { get; set; } = string.Empty;
  public string? Status { get; set; } = string.Empty;
  public string? Species { get; set; } = string.Empty;
  public string? Type { get; set; } = string.Empty;
  public string? Gender { get; set; } = string.Empty;
  public string? Origin { get; set; } = string.Empty;
  public string? Location { get; set; } = string.Empty;

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

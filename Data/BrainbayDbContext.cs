using Microsoft.EntityFrameworkCore;
using Brainbay.Models;

namespace Brainbay.Data;

public class BrainbayDbContext : DbContext
{
  public BrainbayDbContext()
  {
  }

  public BrainbayDbContext(DbContextOptions options) : base(options)
  {
  }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    if (!options.IsConfigured)
    {
      options.UseSqlite($"Data Source=../Brainbay.db");
    }
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
  }

  public DbSet<Character> Characters { get; set; }
}

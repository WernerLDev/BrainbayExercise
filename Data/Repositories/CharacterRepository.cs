
using Brainbay.Data;
using Brainbay.Models;
using Brainbay.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Brainbay;

public class CharacterRepository(BrainbayDbContext dbContext) : ICharacterRepository
{
  public IEnumerable<Character> All()
  {
    return dbContext.Characters.ToList();
  }

  public async Task<Character> Create(CharacterDto dto)
  {
    Character entity = new Character()
    {
      Name = dto.Name,
      Status = dto.Status,
      Species = dto.Species,
      Type = dto.Type,
      Gender = dto.Gender,
      Origin = dto.Origin,
      Location = dto.Location,
    };

    dbContext.Characters.Add(entity);
    await dbContext.SaveChangesAsync();

    return entity;
  }


  public async Task DeleteAll()
  {
    await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM Characters;");
  }
}

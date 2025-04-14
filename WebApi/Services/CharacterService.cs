using Brainbay;
using Brainbay.Models;
using Brainbay.Models.Dtos;
using Microsoft.Extensions.Caching.Memory;

namespace Services;

public class CharacterService(ICharacterRepository repository, IMemoryCache memoryCache) : ICharacterService
{
  private readonly string CACHE_KEY = "characters";

  public IEnumerable<Character> GetAll()
  {
    return repository.All();
  }

  public async Task<Character> CreateCharacter(CharacterDto character)
  {
    memoryCache.Remove(CACHE_KEY);
    return await repository.Create(character);
  }

  public IEnumerable<Character>? TryGetAllCache()
  {
    if (memoryCache.TryGetValue(CACHE_KEY, out IEnumerable<Character>? characters))
    {
      return characters;
    }
    return null;
  }

  public void SetCache(IEnumerable<Character> characters)
  {
    var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromMinutes(5));

    memoryCache.Set(CACHE_KEY, characters, cacheEntryOptions);
  }

}

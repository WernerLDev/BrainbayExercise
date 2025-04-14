using Brainbay.Models;
using Brainbay.Models.Dtos;

public interface ICharacterService
{
  IEnumerable<Character> GetAll();
  Task<Character> CreateCharacter(CharacterDto character);
  IEnumerable<Character>? TryGetAllCache();
  void SetCache(IEnumerable<Character> characters);
}
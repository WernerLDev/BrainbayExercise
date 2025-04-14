using Brainbay.Models;
using Brainbay.Models.Dtos;

namespace Brainbay;

public interface ICharacterRepository
{
  IEnumerable<Character> All();
  Task<Character> Create(CharacterDto dto);
  Task DeleteAll();

}

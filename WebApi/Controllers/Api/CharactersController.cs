using Microsoft.AspNetCore.Mvc;
using Brainbay.Models;
using Brainbay.Models.Dtos;

namespace Brainbay.Controllers.Api;

[Route("/Api/Characters")]
public class CharactersController(ICharacterService characterService) : Controller
{
  [HttpGet]
  public ActionResult<IEnumerable<Character>> Get()
  {
    IEnumerable<Character>? cachedCharacters = characterService.TryGetAllCache();
    if (cachedCharacters == null)
    {
      HttpContext.Response.Headers.Append("from-database", "yes");
      IEnumerable<Character> characters = characterService.GetAll();
      characterService.SetCache(characters);
      return Ok(characters);
    }
    return Ok(cachedCharacters);
  }

  [HttpPost]
  public async Task<ActionResult<Character>> Post([FromBody] CharacterDto entity)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }

    return Ok(await characterService.CreateCharacter(entity));
  }

}

using Microsoft.AspNetCore.Mvc;
using starwars.IBusinessLogic;
using starwars.WebApi.Dtos;
using System.Collections.Generic;

namespace starwars.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CharactersController : ControllerBase
{
    private ICharacterService _characterService;

    public CharactersController(ICharacterService characterService)
    {
        _characterService = characterService;
    }

    [HttpGet]
    public IActionResult GetCharacters()
    {
        return Ok(_characterService.GetCharacters().Select(c => new CharacterDTO(c)).ToList());
    }
}


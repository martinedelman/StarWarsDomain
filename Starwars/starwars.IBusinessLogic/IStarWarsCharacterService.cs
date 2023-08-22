using System;
using starwars.Domain;

namespace starwars.IBusinessLogic
{
	public interface IStarWarsCharacterService
	{
        IEnumerable<StarWarsCharacter> GetCharacters();
        StarWarsCharacter GetCharacterById(int id);
        void InsertCharacter(StarWarsCharacter? character);
        StarWarsCharacter? UpdateCharacter(StarWarsCharacter? character);
        void DeleteCharacter(int id);
    }
}


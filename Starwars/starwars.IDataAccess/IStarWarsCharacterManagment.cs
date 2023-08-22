using starwars.Domain;

namespace starwars.IDataAccess;
public interface IStarWarsCharacterManagment
{
    IEnumerable<StarWarsCharacter> GetCharacters();
    StarWarsCharacter GetCharacterById(int id);
    void InsertCharacter(StarWarsCharacter? character);
    StarWarsCharacter? UpdateCharacter(StarWarsCharacter? character);
    void DeleteCharacter(int id);
}


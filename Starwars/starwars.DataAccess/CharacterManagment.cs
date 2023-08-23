using starwars.Domain;
using starwars.Exceptions;
using starwars.IDataAccess;

namespace starwars.DataAccess;
public class CharacterManagment : ICharacterManagment
{
    private List<Character> _characters;
    public CharacterManagment()
    {
        this._characters = new List<Character>
        {
            new Character
                {
                    Id = 11,
                    Name = "Darth Sidious (Emperor Palpatine)",
                    Description = "The cunning Sith Lord who orchestrated the fall of the Republic and rise of the Empire.",
                    ImageUrl = "darth_sidious_image_url"
                },
            new Character
                {
                    Id = 12,
                    Name = "Darth Vader (Anakin Skywalker)",
                    Description = "The iconic Sith Lord who was once a Jedi Knight but succumbed to the Dark Side.",
                    ImageUrl = "darth_vader_image_url"
                }
        };
    }
    public void DeleteCharacter(int id)
    {
        throw new NotImplementedException();
    }

    public Character GetCharacterById(int id)
    {
        return _characters.Where(u => u.Id == id).FirstOrDefault();
    }

    public IEnumerable<Character> GetCharacters()
    {
        throw new NotImplementedException();
    }

    public void InsertCharacter(Character? character)
    {
        _characters.Add(character!);
    }

    public Character? UpdateCharacter(Character? character)
    {
        if(_characters.Where(u=>u.Id == character.Id).FirstOrDefault() == null)
            throw new NotFoundException("La personaje no existe");
        return character;
    }
}


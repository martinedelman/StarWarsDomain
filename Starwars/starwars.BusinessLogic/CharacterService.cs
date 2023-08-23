using System;
using starwars.Domain;
using starwars.Domain.Enums;
using starwars.IBusinessLogic;
using starwars.IDataAccess;

namespace starwars.BusinessLogic
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterManagment charactersManagement;
        public CharacterService(ICharacterManagment charactersManagement)
        {
            this.charactersManagement = charactersManagement;
        }

        public void DeleteCharacter(int id)
        {
            charactersManagement.DeleteCharacter(id);
        }

        public Character GetCharacterById(int id)
        {
            return charactersManagement.GetCharacterById(id);
        }

        public IEnumerable<Character> GetCharacters()
        {
            return charactersManagement.GetCharacters();
        }

        public void InsertCharacter(Character? character)
        {
            if (IsCharacterValid(character))
              charactersManagement.InsertCharacter(character!);
        }

        public Character? UpdateCharacter(Character? character)
        {
            if (IsCharacterValid(character))
                return charactersManagement.UpdateCharacter(character);
            return null;
        }

        private bool IsCharacterValid(Character? character)
        {
            if (character == null)
            {
                throw new Exception("Personaje inválido");
            }
            if (character.Name == string.Empty)
            {
                throw new Exception("Personaje inválido");
            }
            return true;
        }
    }
}


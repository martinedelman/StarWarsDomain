using System;
using starwars.Domain;
using starwars.Domain.Enums;
using starwars.IBusinessLogic;
using starwars.IDataAccess;

namespace starwars.BusinessLogic
{
    public class StarWarsCharacterService : IStarWarsCharacterService
    {
        private readonly IStarWarsCharacterManagment charactersManagement;
        public StarWarsCharacterService(IStarWarsCharacterManagment charactersManagement)
        {
            this.charactersManagement = charactersManagement;
        }

        public void DeleteCharacter(int id)
        {
            charactersManagement.DeleteCharacter(id);
        }

        public StarWarsCharacter GetCharacterById(int id)
        {
            return charactersManagement.GetCharacterById(id);
        }

        public IEnumerable<StarWarsCharacter> GetCharacters()
        {
            return charactersManagement.GetCharacters();
        }

        public void InsertCharacter(StarWarsCharacter? character)
        {
            if (IsCharacterValid(character))
              charactersManagement.InsertCharacter(character!);
        }

        public StarWarsCharacter? UpdateCharacter(StarWarsCharacter? character)
        {
            if (IsCharacterValid(character))
                return charactersManagement.UpdateCharacter(character);
            return null;
        }

        private bool IsCharacterValid(StarWarsCharacter? character)
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


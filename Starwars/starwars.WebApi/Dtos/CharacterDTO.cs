using System;
using starwars.Domain;

namespace starwars.WebApi.Dtos
{
	public class CharacterDTO
	{
        public int Id { get; set; }
        public string Name { get; set; }

        public CharacterDTO(Character character)
		{
			Id = character.Id;
			Name = character.Name;
		}
	}
}


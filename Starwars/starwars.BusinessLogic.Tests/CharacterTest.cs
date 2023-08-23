using System.Collections.Generic;
using Moq;
using starwars.Exceptions;
using starwars.IDataAccess;
using static System.Net.Mime.MediaTypeNames;


namespace starwars.BusinessLogic.Tests;

[TestClass]
public class CharacterTest
{
    private Mock<ICharacterManagment>? mock;
    private CharacterService? service;
    private Character? character;
    private Character? nullCharacter;
    private IEnumerable<Character>? characters;
    private Character? invalidCharacter;

    [TestInitialize]
    public void InitTest()
    {
        mock = new Mock<ICharacterManagment>(MockBehavior.Strict);
        service = new CharacterService(mock.Object);
        character = new Character()
        {
            Id = 1,
            Description = "Test",
            Name = "Darth Nico",
            ImageUrl = ""
        };
        nullCharacter = null;
        characters = new List<Character>() { character };
        invalidCharacter = new Character() { Description = "", Id = 0, ImageUrl ="", Name=""};
    }

    [TestMethod]
    public void InsertCharacterOk()
    {
        //Arrange
        //Mock<ICharacterManagment>? mock = new Mock<ICharacterManagment>(MockBehavior.Strict);
        //CharacterService? service2 = new CharacterService(mock.Object);
        //character = new Character()
        //{
        //    Id = 1,
        //    Description = "Test",
        //    Name = "Darth Nico",
        //    ImageUrl = ""
        //};

        //Act
        mock!.Setup(x => x.InsertCharacter(character!));
        service!.InsertCharacter(character!);

        //Assert
        mock.VerifyAll();
    }


    [ExpectedException(typeof(Exception))]
    [TestMethod]
    public void InsertNullCharacter()
    {
        //Arrange
        //Mock<ICharacterService>? mock;
        //mock = new Mock<ICharacterService>(MockBehavior.Strict);
        //CharacterService? service;
        //service = new CharacterService();
        //Character? nullcharacter = null;
        //Act
        service!.InsertCharacter(nullCharacter);
        //Assert
        mock!.VerifyAll();
    }

    [TestMethod]
    public void GetAllCharacters()
    {
        mock!.Setup(x => x.GetCharacters()).Returns(characters!);
        service!.GetCharacters();
        mock.VerifyAll();
    }

    [ExpectedException(typeof(Exception))]
    [TestMethod]
    public void InsertInvalidCaracter()
    {
        service!.InsertCharacter(invalidCharacter!);
        mock!.VerifyAll();
    }

    //[ExpectedException(typeof(NotFoundException))]
    //[TestMethod]
    //public void UpdateMovieNonExist()
    //{
    //    mock!.Setup(x => x.GetCharacterById(character!.Id)).Returns(nullCharacter);
    //    service!.UpdateCharacter(character!);
    //    mock.VerifyAll();
    //}
}
using System.Collections.Generic;
using Moq;
using starwars.Exceptions;
using starwars.IDataAccess;
using static System.Net.Mime.MediaTypeNames;


namespace starwars.BusinessLogic.Tests;

[TestClass]
public class StarWarsCharacterTest
{
    private Mock<IStarWarsCharacterManagment>? mock;
    private StarWarsCharacterService? service;
    private StarWarsCharacter? character;
    private StarWarsCharacter? nullCharacter;
    private IEnumerable<StarWarsCharacter>? characters;
    private StarWarsCharacter? invalidCharacter;

    [TestInitialize]
    public void InitTest()
    {
        mock = new Mock<IStarWarsCharacterManagment>(MockBehavior.Strict);
        service = new StarWarsCharacterService(mock.Object);
        character = new StarWarsCharacter()
        {
            Id = 1,
            Description = "Test",
            Name = "DarthAlex",
            ImageUrl = ""
        };
        nullCharacter = null;
        characters = new List<StarWarsCharacter>() { character };
        invalidCharacter = new StarWarsCharacter() { Description = "", Id = 0, ImageUrl ="", Name=""};
    }

    [TestMethod]
    public void InsertCharacterOk()
    {
        //Arrange
        //En Initialize

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
        //Mock<IStarWarsCharacterService>? mock;
        //mock = new Mock<IStarWarsCharacterService>(MockBehavior.Strict);
        //StarWarsCharacterService? service;
        //service = new StarWarsCharacterService();
        //StarWarsCharacter? nullcharacter = null;
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

    [ExpectedException(typeof(NotFoundException))]
    [TestMethod]
    public void UpdateMovieNonExist()
    {
        mock!.Setup(x => x.GetCharacterById(character!.Id)).Returns(nullCharacter);
        service!.UpdateCharacter(character!);
        mock.VerifyAll();
    }
}
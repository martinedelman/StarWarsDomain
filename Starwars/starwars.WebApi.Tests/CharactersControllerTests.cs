using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Moq;
using starwars.Domain;
using starwars.IBusinessLogic;
using starwars.WebApi.Controllers;
using starwars.WebApi.Dtos;

namespace starwars.WebApi.Tests;

[TestClass]
public class CharactersControllerTests
{
    [TestMethod]
    public void GetAllCharacters()
    {
        //Arrange
        Character character = new Character()
        {
            Name = "Yoda",
            Description = "Jedi Master"
        };
        IEnumerable<Character> characters = new List<Character>()
            {
                character
            };

        Mock<ICharacterService> charactersLogicMock = new Mock<ICharacterService>(MockBehavior.Strict);
        charactersLogicMock.Setup(logic => logic.GetCharacters())
            .Returns(characters);

        CharactersController _characterController = new CharactersController(charactersLogicMock.Object);
        OkObjectResult expected = new OkObjectResult(new List<CharacterDTO>() {
                new CharacterDTO(characters.First())});

        List<CharacterDTO> expectedObject = (expected.Value as List<CharacterDTO>)!;
        //Act
        OkObjectResult result = (_characterController.GetCharacters() as OkObjectResult)!;
        Console.WriteLine(result.Value);
        List<CharacterDTO> objectResult = (result.Value as List<CharacterDTO>)!;
        //Assert
        charactersLogicMock.VerifyAll();
        Assert.IsTrue(result.StatusCode.Equals(expected.StatusCode)
            && expectedObject.First().Name.Equals(objectResult.First().Name));
    }

    [TestMethod]
    public void GetCharacterById()
    {
        //Arrange
        Character character = new Character()
        {
            Name = "Yoda",
            Description = "Jedi Master"
        };
        Mock<ICharacterService> charactersLogicMock = new Mock<ICharacterService>(MockBehavior.Strict);
        charactersLogicMock.Setup(logic => logic.GetCharacterById(It.IsAny<int>()))
            .Returns(character);
        CharactersController _characterController = new CharactersController(charactersLogicMock.Object);
        OkObjectResult expected = new OkObjectResult(new CharacterDTO(character));
        CharacterDTO expectedObject = (expected.Value as CharacterDTO)!;

        OkObjectResult result = (_characterController.GetCharacterById(1) as OkObjectResult)!;
        Console.WriteLine(result.Value);
        CharacterDTO objectResult = (result.Value as CharacterDTO)!;

        charactersLogicMock.VerifyAll();
        Assert.IsTrue(result.StatusCode.Equals(expected.StatusCode)
            && expectedObject.Name.Equals(objectResult.Name));
    }

    [TestMethod]
    public void InsertCharacter()
    { 
        CharacterCreateModel character = new CharacterCreateModel()
        {
            Name = "Jar Jar Bins",
            Description = "Sith Lord"
        };
        Mock<ICharacterService> charactersLogicMock = new Mock<ICharacterService>(MockBehavior.Strict);
        charactersLogicMock.Setup(x => x.InsertCharacter(It.IsAny<Character>()));
        CharactersController _characterController = new CharactersController(charactersLogicMock.Object);
        var result = _characterController.InsertCharacter(character);
        var objectResult = result as OkResult;
        var statusCode = objectResult.StatusCode;

        charactersLogicMock.VerifyAll();
        Assert.AreEqual(200, statusCode);
    }

    [TestMethod]
    public void DeleteCharacter()
    {
        Mock<ICharacterService> characterLogicMock = new Mock<ICharacterService>(MockBehavior.Strict);
        characterLogicMock.Setup(x => x.DeleteCharacter(It.IsAny<int>()));
        CharactersController charactersController = new CharactersController(characterLogicMock.Object);
        var result = charactersController.DeleteCharacter(1);
        var objectResult = result as OkResult;
        var statusCode = objectResult!.StatusCode;

        characterLogicMock.VerifyAll();
        Assert.AreEqual(200, statusCode);
    }
}
using Microsoft.AspNetCore.Mvc;
using Moq;
using starwars.BusinessLogic;
using starwars.Domain;
using starwars.IBusinessLogic;
using starwars.WebApi.Controllers;
using starwars.WebApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starwars.WebApi.Tests
{
    [TestClass]
    public class QuestionControllerTests
    {
        [TestMethod]
        public void GetQuestions()
        {
            //Arrange
            Question question = new Question
            {
                Id = 1,
                Category = Domain.Enums.QuestionCategory.Ambition,
                ForceValue = 10,
                Text = "¿Matarías por un puesto?"
            };
            List<Question> questions = new List<Question>()
            {
                question
            };

            Mock<IForceCalculator> forceLogicMock = new Mock<IForceCalculator>(MockBehavior.Strict);
            forceLogicMock.Setup(logic => logic.GetQuestions())
                .Returns(questions);

            QuestionsController _characterController = new QuestionsController(forceLogicMock.Object);
            OkObjectResult expected = new OkObjectResult(new List<Question>() {question});

            List<Question> expectedObject = (expected.Value as List<Question>)!;
            //Act
            OkObjectResult result = (_characterController.GetQuestions() as OkObjectResult)!;
            Console.WriteLine(result.Value);
            List<Question> objectResult = (result.Value as List<Question>)!;
            //Assert
            forceLogicMock.VerifyAll();
            Assert.IsTrue(result.StatusCode.Equals(expected.StatusCode)
                && expectedObject.First().Text.Equals(objectResult.First().Text));

        }

    }
}

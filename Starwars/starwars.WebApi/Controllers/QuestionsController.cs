using Microsoft.AspNetCore.Mvc;
using starwars.IBusinessLogic;

namespace starwars.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/questions")]
    public class QuestionsController : ControllerBase
    {
        private IForceCalculator _forceCalculator;
        public QuestionsController(IForceCalculator forceCalculator)
        {
            _forceCalculator = forceCalculator;
        }

        [HttpGet]
        public IActionResult GetQuestions() {
            return Ok(_forceCalculator.GetQuestions());
        }
        [HttpGet]
        public IActionResult DetermineCharacter()
        {
            //return Ok(_forceCalculator.DetermineCharacter());
            throw new NotImplementedException();
        }
    }
}
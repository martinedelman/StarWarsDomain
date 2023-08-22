using System;
using starwars.Domain;

namespace starwars.IBusinessLogic
{
	public interface IForceCalculator
	{
        public StarWarsCharacter DetermineStarWarsCharacter(IEnumerable<QuestionAnswer> answers);
        public List<Question> GetQuestions();
    }
}


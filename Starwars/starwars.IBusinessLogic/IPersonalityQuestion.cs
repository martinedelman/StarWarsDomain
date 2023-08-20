using System;
using starwars.Domain;

namespace starwars.IBusinessLogic
{
	public interface IPersonalityQuestion
    {
        IEnumerable<Question> GetQuestions();
    }
}


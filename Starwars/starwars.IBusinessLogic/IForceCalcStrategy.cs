using starwars.Domain;

namespace starwars.IBusinessLogic;
public interface IForceCalcStrategy
{
    int CalculateForce(IEnumerable<QuestionAnswer> answers);
    StarWarsCharacter DetermineCharacter(int forceLevel);
}



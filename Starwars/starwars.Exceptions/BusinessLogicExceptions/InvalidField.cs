using System;
namespace starwars.Exceptions.BusinessLogicExceptions
{
    [Serializable]
    public class InvalidField : Exception
    {
        public InvalidField(string message) : base(message)
        {
        }
    }
}


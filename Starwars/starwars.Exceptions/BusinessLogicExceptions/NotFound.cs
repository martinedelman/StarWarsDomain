using System;
namespace starwars.Exceptions.BusinessLogicExceptions
{
    [Serializable]
    public class NotFound : Exception
    {
        public NotFound(string message) : base(message)
        {
        }
    }
}


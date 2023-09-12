using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using starwars.Exceptions.BusinessLogicExceptions;

namespace starwars.WebApi.Filters
{
    public class ExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is InvalidField)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 400,
                    Content = context.Exception.Message,
                };
            }
        }
    }
}


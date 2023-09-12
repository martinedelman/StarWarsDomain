using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace starwars.WebApi.Filters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            throw new NotImplementedException();
        }
    }
}


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepAppEmpty.Infracstructures.Sessions;

namespace WepAppEmpty.Areas.Admin.Infracstructures.Security
{
    public class AdminRequiredAttribute : TypeFilterAttribute
    {
        public AdminRequiredAttribute() : base(typeof(AuthRequiredFilter))
        {

        }

        private class AuthRequiredFilter : IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                ISessionManager sessionManager = (ISessionManager)context.HttpContext.RequestServices.GetService(typeof(ISessionManager));

                if (sessionManager.User is null || !sessionManager.User.IsAdmin)
                {
                    //Pour dire la ressource n'est accessible, elle n'existe pas
                    context.Result = new NotFoundResult();
                }
            }
        }
    }
}

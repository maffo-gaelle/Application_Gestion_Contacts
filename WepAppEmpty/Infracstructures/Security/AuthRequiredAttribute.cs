using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepAppEmpty.Infracstructures.Sessions;
//En fait, ici je crée une classe(un attribut) qui va me permette de filter les autorisations à mon application. Cette classe reçoit en paramètre du constructeur un type de filtre qui est une une classe interne à mon attribut qui implemente l'interface IAuthorizationFilter. Cet interface va medemander de mettre en place une 
//méthode OnAuthorization. Cette méthode recupère le contexte et définit les raison pour lesquelle je ne pourrais pas acceder à la page. En l'occurence ici si le seesionManager.User est null, donc pas d'utilisateur connecter, on ne peut pas acceder à une page.
namespace WepAppEmpty.Infracstructures.Security
{
    //Cette classe va me permettre de faire en de ne plus acceder à une page sans être connecté, en d'autre terme, si il n'ya aucun user en session on est redirigé

    //Avec cet attribut, je dis que je vais pouvoir donner une authorization pour acceder à une classe ou une méthode(action). Par exemple en ce qui concerne la classe, tout ce qui est ContactController, il faut être connecté pour y acceder et dans AuthController, on peut acceder au méthodes login et signup sans être connecté
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthRequiredAttribute : TypeFilterAttribute
    {
        //mon constructeur ici va prendre un type de filtre qu'il va appliquer à notre site pour tout ce qui est authentification
        //Je peux passer à mon constructeur des arguments
        public AuthRequiredAttribute() : base(typeof(AuthRequiredFilter))
        {

        }

        //Je crée dans cette classe un type de filtre pour tout ce qui est authentification
        private class AuthRequiredFilter : IAuthorizationFilter
        {
            //En fait, ici on dit quand je veux authoriser quelqu'un, je demande au context de me fournir le sessionManager. Si à l'intérieur du sessionManager, je n'ai pas de user
            //je redirige la personne à la page login. Si j'ai un user, j'autoprise l'action
            public void OnAuthorization(AuthorizationFilterContext context)
            {//OnAuthorization = est ce que on est autorisé à acceder à la ressource ou pas
                //Je vais demander au ISessionMAnager de me fournir le service 
                ISessionManager sessionManager = (ISessionManager)context.HttpContext.RequestServices.GetService(typeof(ISessionManager));
                
                if(sessionManager.User is null)
                {//Pour un admin j'aurais pu faire sessionManager.User && sessionManager.User.IsAdmin == 1
                    //Ici, il va me retourner une page 401(not), donc pas authoriser
                    //context.Result = new UnauthorizedResult();

                    context.Result = new RedirectToActionResult("Login", "Auth", null);
                }
            }
        }
    }
}

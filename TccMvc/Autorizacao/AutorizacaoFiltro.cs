using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace TccMvc.Autorizacao
{
    public class AutorizacaoFiltro : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
           var Useremail = context.HttpContext.Session.GetString("EmailUser");
           var UserId = context.HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(UserId))
            {
                context.Result = new RedirectToRouteResult("login",null);
            }
            else if (!Useremail.Equals("matrizdecoradmin@hotmail.com") && context.HttpContext.Request.Path.Value.Equals("/admin")) 
            {
                context.Result = new RedirectToRouteResult("AccessDenied",null);
            }
        }
    }
}

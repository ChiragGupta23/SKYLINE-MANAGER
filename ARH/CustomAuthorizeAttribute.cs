//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using System.Net;
//using System.Security.Claims;

//namespace ARH
//{
//    public class CustomAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
//    {
//        public override void OnAuthorization(HttpActionContext actionContext)
//        {
//            var claims = ((ClaimsIdentity)Thread.CurrentPrincipal.Identity);
//            var claim = claims.Claims.Where(x => x.Type == "Company").FirstOrDefault();

//            string privilegeLevels = string.Join("", claim.Value);

//            if (privilegeLevels.Contains(this.Company) == false)
//            {
//                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Usuario de Empresa No Autorizado");
//            }
//        }
//    }
//}

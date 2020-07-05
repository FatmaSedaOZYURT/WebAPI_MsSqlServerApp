using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using WebAPI.DAL;

namespace WebAPI.API.Security
{
    public class APIAuthorizedAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            string role = Roles;
            string userName = HttpContext.Current.User.Identity.Name;
            UsersDAL userDal = new UsersDAL();
            User user = userDal.GetUserByName(userName);
            if (user != null & role.Contains(user.Role))
            {
                
            }
            else
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
        }
    }
}
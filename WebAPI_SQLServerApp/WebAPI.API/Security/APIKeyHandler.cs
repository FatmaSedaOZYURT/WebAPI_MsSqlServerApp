using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WebAPI.DAL;

namespace WebAPI.API.Security
{
    public class APIKeyHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //var queryString = request.RequestUri.ParseQueryString();
            //string apiKey = queryString["apiKey"];
            var apiKey = request.Headers.GetValues("apiKey").FirstOrDefault();
            UsersDAL usersDAL = new UsersDAL();
            var user = usersDAL.GetUserByApiKey(apiKey);
            if (user!=null)
            {
                var principal = new ClaimsPrincipal(new GenericIdentity(user.Name, "APIKey"));
                HttpContext.Current.User = principal;
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebAPI.API.Attributes;
using WebAPI.API.Security;

namespace WebAPI.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

           // config.Filters.Add(new ApiExceptionAttribute()); //Aplication seviyesinde
            //config.MessageHandlers.Add(new APIKeyHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;//PascalCase e göre verilerin json formatıyla düzgün bir şekilde çıktı vermesini sağlıyor

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); //Camelcase formatıyla gelmesini sağlıyoruz.
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http.Cors;

namespace Calculator.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            //
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = 
                new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            var enableCorsAttribute = new EnableCorsAttribute("http://localhost:65105",
                                                  "Origin, Content-Type, Accept",
                                                  "GET, PUT, POST, DELETE, OPTIONS");
            config.EnableCors(enableCorsAttribute);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

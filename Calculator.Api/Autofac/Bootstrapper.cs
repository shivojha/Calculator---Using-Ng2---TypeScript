using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Calculator.Api.Autofac
{
    public static class Bootstrapper
     {
     // public static void Run()
     // {
     //     SetAutofacWebAPI();
     // }       
     // private static void SetAutofacWebAPI()
     // {
     //    var configuration = GlobalConfiguration.Configuration;
     //   var builder = new ContainerBuilder();
     //   // Configure the container 
     //   builder.ConfigureWebApi(configuration);
     //  // Register API controllers using assembly scanning.
     //   builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
        
     //   var container = builder.Build();
     //   // Set the WebApi dependency resolver.
     //   var resolver = new AutofacWebApiDependencyResolver(container);
     //       configuration.Services.GetAssembliesResolver();
     //   configuration.ServiceResolver.SetResolver(resolver);             
     //}
   }
}
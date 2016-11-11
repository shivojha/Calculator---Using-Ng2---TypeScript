using System.Web.Http;
using Microsoft.Owin;
using Owin;
using Autofac;
using Autofac.Integration.WebApi;
using Calculator.Service;
using System.Reflection;

[assembly: OwinStartup(typeof(Calculator.Api.Startup))]
namespace Calculator.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var configuration = new HttpConfiguration();
            configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            WebApiConfig.Register(configuration);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            // Execute any other ASP.NET Web API-related initialization, i.e. IoC, authentication, logging, mapping, DB, etc.
            //ConfigureAuth(app);


            //IOC

            var builder = new ContainerBuilder();
                     

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly‌​());

            builder.RegisterInstance<ICalculatorService>(new CalculatorService());

            var container = builder.Build();

            var resolver = new AutofacWebApiDependencyResolver(container);
            configuration.DependencyResolver = resolver;
            
            //

            app.UseWebApi(configuration);


        }




    }
}
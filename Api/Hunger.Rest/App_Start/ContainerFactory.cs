using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using Hunger.DependencyEngine.Engine;

namespace Hunger.Rest.App_Start
{
    public class ContainerFactory
    {
        /// <summary>
        /// Builds Dependencies
        /// </summary>
        public static void BuildContainer()
        {
            #region DependencyInjection
            //**************DI: http://docs.autofac.org/en/latest/integration/webapi.html **********

            var builder = new ContainerBuilder();

            // Get HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);
            
            //Create Object Instances           
            new InstanceBuilder(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            #endregion DependencyInjection 
        }
    }
}
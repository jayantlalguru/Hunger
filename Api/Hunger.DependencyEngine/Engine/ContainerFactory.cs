using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using Hunger.Services.Registration.Interfaces;
using Hunger.Services.Registration;
using Hunger.Domain.Registration;
using Hunger.DAL.Registration.Interfaces;
using Hunger.DAL.Registration;

namespace Hunger.DependencyEngine.Engine
{
    public class ContainerFactory
    {
        public ContainerFactory(HttpConfiguration httpConfiguration)
        {
            this.BuildContainer(httpConfiguration);
        }
        //**************DI: http://docs.autofac.org/en/latest/integration/webapi.html **********
        /// <summary>
        /// Build Container
        /// </summary>
        /// <param name="httpConfiguration"></param>
        private void BuildContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(httpConfiguration);

            //Build the instances
            this.BuildInstance(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        /// <summary>
        /// Create object instances
        /// </summary>
        /// <param name="containerBuilder"></param>
        private void BuildInstance(ContainerBuilder builder)
        {
            //Service Instances
            builder.RegisterType<RegistrationService>().As<IRegistrationService>().InstancePerLifetimeScope();

            //DAL Instances
            builder.RegisterType<IRegistrationDAL>().As<RegistrationDAL>().InstancePerLifetimeScope();

            //Domain Instances



        }
    }
}

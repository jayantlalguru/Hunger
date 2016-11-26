using Autofac;
using Hunger.Services.Registration.Interfaces;
using Hunger.Services.Registration;
using Hunger.DAL.Registration.Interfaces;
using Hunger.DAL.Registration;

namespace Hunger.DependencyEngine.Engine
{
    public class InstanceBuilder
    {
        public InstanceBuilder(ContainerBuilder builder)
        {
            this.BuildInstance(builder);
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
            builder.RegisterType<RegistrationDAL>().As<IRegistrationDAL>().InstancePerLifetimeScope();

            //Domain Instances
            

        }
    }
}

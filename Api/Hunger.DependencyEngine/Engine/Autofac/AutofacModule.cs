using Autofac;
using Hunger.DAL.Registration;
using Hunger.DAL.Registration.Interfaces;

namespace Hunger.DependencyEngine.Engine.Autofac
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RegistrationDAL>().As<IRegistrationDAL>().InstancePerLifetimeScope();
        }
    }
}

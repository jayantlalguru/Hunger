using Autofac;
using System.Web.Http;

namespace Hunger.DependencyEngine.Engine.Interfaces
{
    public interface IContainerFactory
    {
        void BuildContainer(HttpConfiguration httpConfiguration);
    }
}

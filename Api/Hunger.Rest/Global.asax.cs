using System.Web.Http;
using Hunger.DependencyEngine.Engine;

namespace Hunger.Rest
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            
            // Get HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            //Dependency Injection Call
            new ContainerFactory(config);
        }
    }
}

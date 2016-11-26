using System.Web.Http;
using Hunger.Rest.App_Start;

namespace Hunger.Rest
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            ContainerFactory.BuildContainer();
        }
    }
}

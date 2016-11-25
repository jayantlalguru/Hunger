using Hunger.Rest.App_Start;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http;


namespace Hunger.Rest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
               name: "ActivateRegistration",
               routeTemplate: "api/{controller}/{action}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
                name: "GetRegistrationById",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }

        private static string[] ComposePluginsPaths()
        {
            string pluginBasePath = String.Format(@"{0}", AppDomain.CurrentDomain.BaseDirectory);
            var pluginsPaths = Directory.GetDirectories(pluginBasePath);
            return pluginsPaths;
        }
    }
}

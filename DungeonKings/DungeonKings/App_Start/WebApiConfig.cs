using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DungeonKings
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            JsonConvert.DefaultSettings = () =>
            {
                var settings = new JsonSerializerSettings();
                settings.Converters.Add(new StringEnumConverter {CamelCaseText = true});
                return settings;
            };
        }
    }
}

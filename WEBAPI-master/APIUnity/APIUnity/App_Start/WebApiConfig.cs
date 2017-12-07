using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace APIUnity
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            config.Formatters.JsonFormatter.SerializerSettings.Formatting =
                Newtonsoft.Json.Formatting.Indented;

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
= Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

        }
    }
}

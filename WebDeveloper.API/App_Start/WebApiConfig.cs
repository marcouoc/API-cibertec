using Microsoft.AspNet.WebApi.Extensions.Compression.Server;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Extensions.Compression.Core.Compressors;
using System.Web.Http;

namespace WebDeveloper.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //add line code-- header of the response add Gzip
            GlobalConfiguration.Configuration.MessageHandlers.Insert
                (0, new ServerCompressionHandler
                (new GZipCompressor(), new DeflateCompressor()));

            //devuelve la primera letra en minuscula en cuaquier response del api
            config.Formatters.JsonFormatter.SerializerSettings.
                ContractResolver = new CamelCasePropertyNamesContractResolver();



            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

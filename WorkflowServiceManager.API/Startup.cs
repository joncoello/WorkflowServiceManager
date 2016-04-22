using Newtonsoft.Json.Serialization;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

[assembly: InternalsVisibleTo("WorkflowServiceManager.AcceptanceTests")]
[assembly: InternalsVisibleTo("WorkflowServiceManager.APIHost")]

namespace WorkflowServiceManager.API
{
    class Startup
    {
        public void Configuration(IAppBuilder app) {

            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                "default",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional }
                );

            config.Formatters.XmlFormatter.UseXmlSerializer = false;

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();


            app.UseWebApi(config);
        }
    }
}

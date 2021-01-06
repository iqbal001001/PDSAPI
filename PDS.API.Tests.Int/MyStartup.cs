using Owin;
using System.Web;
using System.Web.Http;
using System.IO;
using PDS.API;

namespace Zap.DocumentStorage.Api.Tests.Int
{
    public class MyStartup
    {
        public void Configuration(IAppBuilder app)
        {
            //Startup.ConfigureAuth();
            app.UseErrorPage(); // See Microsoft.Owin.Diagnostics
            app.UseWelcomePage("/Welcome"); // See Microsoft.Owin.Diagnostics 
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello world using OWIN TestServer");
            //});

            //Get your HttpConfiguration. In OWIN, you'll create one
            //rather than using GlobalConfiguration.
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);



            //// OWIN WEB API SETUP:

            //// Register the Autofac middleware FIRST, then the Autofac Web API middleware,
            //// and finally the standard Web API middleware.
            app.UseWebApi(config);

            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""),
          new HttpResponse(new StringWriter())
          );

        }
    }
}


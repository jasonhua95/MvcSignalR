using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApiSignalR.Startup))]
namespace WebApiSignalR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
			app.MapSignalR();
        }
    }
}

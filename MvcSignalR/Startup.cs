using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcSignalR.Startup))]
namespace MvcSignalR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
			app.MapSignalR();
        }
    }
}

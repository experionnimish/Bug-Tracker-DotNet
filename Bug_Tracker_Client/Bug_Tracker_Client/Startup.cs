using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bug_Tracker_Client.Startup))]
namespace Bug_Tracker_Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ParcialSAP.Startup))]
namespace ParcialSAP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

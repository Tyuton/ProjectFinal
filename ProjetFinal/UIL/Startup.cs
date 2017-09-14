using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UIL.Startup))]
namespace UIL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

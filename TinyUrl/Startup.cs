using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TinyUrl.Startup))]
namespace TinyUrl
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

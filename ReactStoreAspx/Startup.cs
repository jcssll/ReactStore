using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReactStoreAspx.Startup))]
namespace ReactStoreAspx
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

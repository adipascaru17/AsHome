using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AsHomeStore.Startup))]
namespace AsHomeStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyStorage.Startup))]
namespace MyStorage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebNotebook.Startup))]
namespace WebNotebook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

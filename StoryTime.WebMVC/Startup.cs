using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StoryTime.WebMVC.Startup))]
namespace StoryTime.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WordsUpWeb.Startup))]
namespace WordsUpWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

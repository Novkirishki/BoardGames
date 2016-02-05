using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BoardGames.Startup))]
namespace BoardGames
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

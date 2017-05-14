using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FilmFestival.Startup))]
namespace FilmFestival
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

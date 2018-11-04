using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(medEvolution.Startup))]
namespace medEvolution
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

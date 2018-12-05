using Microsoft.Owin;
using Owin;
using medEvolution.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

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

using Microsoft.Owin;
using Owin;
using medEvolution.Models;
using MedEvolution.Models.App;
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
			createRolesandUsers();
        }
		private void createRolesandUsers()
		{
			MedEvolutionDbContext context = new MedEvolutionDbContext();
			var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
			var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

			if (!roleManager.RoleExists("Administrador"))
			{
				var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
				role.Name = "Administrador";
				roleManager.Create(role);

				var user = new ApplicationUser();
				user.UserName = "Admin";
				user.Email = "admin@gmail.com";

				string pass = "Daniel123!";

				var chkUser = UserManager.Create(user, pass);

				if (chkUser.Succeeded)
				{
					var result1 = UserManager.AddToRole(user.Id, "Admin");
				}

			}
			// Crenado role MAnager   
			if (!roleManager.RoleExists("Manager"))
			{
				var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
				role.Name = "Manager";
				roleManager.Create(role);

			}
			// creando role Recepcionista    
			if (!roleManager.RoleExists("Recepcionista"))
			{
				var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
				role.Name = "Recepcionista	";
				roleManager.Create(role);

			}
		}

    }
}

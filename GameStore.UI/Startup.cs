using GameStore.DAL;
using GameStore.UI.Utils;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Data.Entity;

[assembly: OwinStartup(typeof(GameStore.UI.Startup))]
namespace GameStore.UI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<DbContext>(() => new ApplicationContext()); // реєструємо контекст, для того щоб Identity знала який саме використовувати
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSigninManager>(ApplicationSigninManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            InitUsers();
        }

        private void InitUsers()
        {
            var userStore = new UserStore<IdentityUser>(new ApplicationContext());
            var userManager = new ApplicationUserManager(userStore);
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationContext()));

            var roleAdmin = new IdentityRole()
            {
                Name = "Admin"
            };

            var roleUser = new IdentityRole()
            {
                Name = "User"
            };

            roleManager.Create(roleAdmin);
            roleManager.Create(roleUser);

            userManager.Create(new IdentityUser
            {
                Email = "admin@gmail.com",
                UserName = "admin"
            }, "123456");

            userManager.Create(new IdentityUser
            {
                Email = "user@gmail.com",
                UserName = "user"
            }, "123456");

            userManager.AddToRole(userManager.FindByName("admin").Id, "Admin");
            userManager.AddToRole(userManager.FindByName("user").Id, "User");
        }
    }
}

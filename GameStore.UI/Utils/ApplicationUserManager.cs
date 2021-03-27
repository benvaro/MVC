using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace GameStore.UI.Utils
{
    public class ApplicationUserManager: UserManager<IdentityUser>
    {
        public ApplicationUserManager(IUserStore<IdentityUser> store) : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext owinContext)
        {
            var dbContext = owinContext.Get<DbContext>();
            var manager = new ApplicationUserManager(new UserStore<IdentityUser>(dbContext));

            manager.UserValidator = new UserValidator<IdentityUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            manager.PasswordValidator = new PasswordValidator()
            {
                RequiredLength = 6,
                //RequireDigit = true,
                //RequireLowercase = true,
                //RequireNonLetterOrDigit = true,
                //RequireUppercase = true
            };

            return manager;
        }
    }
}
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace GameStore.UI.Utils
{
    public class ApplicationSigninManager : SignInManager<IdentityUser, string>
    {
        public ApplicationSigninManager(UserManager<IdentityUser, string> userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
        {
        }

        public static ApplicationSigninManager Create(IdentityFactoryOptions<ApplicationSigninManager> options,
            IOwinContext owinContext)
        {
            var userManager = owinContext.GetUserManager<ApplicationUserManager>();
            var signinManager = new ApplicationSigninManager(userManager, owinContext.Authentication);

            return signinManager;
        }
    }
}
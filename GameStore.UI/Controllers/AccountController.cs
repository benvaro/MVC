using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GameStore.UI.Models;
using GameStore.UI.Utils;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace GameStore.UI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        public async Task<ActionResult> Register(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var manager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signinManager = HttpContext.GetOwinContext().GetUserManager<ApplicationSigninManager>();

            var user = new IdentityUser
            {
                UserName = model.UserName,
                Email = model.Email
            };
            var identityResult = await manager.CreateAsync(user, model.Password);
            if (identityResult.Succeeded)
            {
             //   await signinManager.PasswordSignInAsync(user.UserName, model.Password, false, false);
                await signinManager.SignInAsync(user, false, false);
                return RedirectToAction("Index", "Games");
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
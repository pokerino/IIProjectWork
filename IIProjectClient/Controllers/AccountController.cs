using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Hosting;
using System.Web.Security;
using IIProjectClient.Models;

namespace IIProjectClient.Controllers
{
    public class AccountController : Controller
    {
        XElement userList = XElement.Load(HostingEnvironment.MapPath("/App_Data/") + "users.xml");
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (user.IsValid(user.username, user.password))
            {
                FormsAuthentication.SetAuthCookie(user.username, user.rememberMe);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Login data is incorrect!");
            }
            return View(user);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Manage()
        {
            User user = new User();
            user = user.getUser(User.Identity.Name);
            return View(user);
        }

        [HttpPost]
        public ActionResult Manage(User user, string pword)
        {
            if(user.modifieUser(user, pword, User.Identity.Name))
            {
                FormsAuthentication.SetAuthCookie(user.username, User.Identity.IsAuthenticated);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Manage", "Account");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if(user.registerNewUser(user))
            {
                return RedirectToAction("Login", "Account");                
            }
            return View(user);
        }
    }
}
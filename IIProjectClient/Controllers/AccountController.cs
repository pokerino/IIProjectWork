using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Hosting;
using System.Web.Security;

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
        public ActionResult Login(Models.User user)
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


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Hosting;

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
        public ActionResult Login(string uname, string psw)
        {
            foreach (var Element in userList.Elements("user"))
            {
                if (Element.Element("username").Value.Equals(uname)&&Element.Element("password").Value.Equals(psw))
                {
                    return RedirectToAction("Sök", "Sök");
                }
            }
            return View();

        }
    }
}
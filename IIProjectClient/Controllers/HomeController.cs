using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Web.Hosting;


namespace IIProjectClient.Controllers
{
    public class HomeController : Controller
    {
        XElement userList = XElement.Load(HostingEnvironment.MapPath("/App_Data/") + "users.xml");
        
        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("Login", "Account");
        }
    }
}
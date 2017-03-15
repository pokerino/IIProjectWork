using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IIProjectClient.Controllers
{
    public class SharedController : Controller
    {
        // GET: Shared
        public ActionResult _LoginPartial()
        {
            return View();
        }

    }
}
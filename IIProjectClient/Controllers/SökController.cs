using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using IIProjectClient.Models;


namespace IIProjectClient.Controllers
{
    public class SökController : Controller
    {

        // GET: Sök
        public ActionResult Sök()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Sök(string _testor)
        {
            XElement passagerList = XElement.Load(HostingEnvironment.MapPath("/App_Data/") + "tmpTestXML.xml");
            IEnumerable<FordonPassage> viewPassager = (from passager in passagerList.Elements("FordonPassage")
                                                      let passage = FordonPassage.fromXML(passager)
                                                      select passage).OrderBy(p => p.Tid);
            return View(viewPassager);
        }


    }
}
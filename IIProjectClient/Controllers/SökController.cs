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
            // Local test file
            XElement passagerList = XElement.Load(HostingEnvironment.MapPath("/App_Data/") + "tmpTestXML.xml");
            
            // Service call client
            ProjectServiceReference1.Service1Client client = new ProjectServiceReference1.Service1Client();

            // Test Values -- USE AS INPUT PARAMETERS
            string urn = "urn:epc:id:sgln:735999271.000.13";
            DateTime _from = Convert.ToDateTime("2011-03-29");
            DateTime _to = _from.AddDays(1);
            
            // Service call (rightmost bool: refresh (delete and fetch new) masterdata in service)
            XElement x = XElement.Load(client.GetEventsForLocation(urn, _from, _to, false).CreateNavigator().ReadSubtree());

            // Convert to FordonsPassage class
            IEnumerable<FordonPassage> viewPassager = (
                                                        //from passager in passagerList.Elements("FordonPassage")
                                                        from    passager in x.Elements("FordonPassage")
                                                        let     passage = FordonPassage.fromXML(passager)
                                                        select  passage
                                                      ).OrderByDescending(p => p.Tid);

            Tjänstemeddelande newMessage = new Tjänstemeddelande(1, User.Identity.Name, this.ToString(), User.Identity.Name, _testor);
            XElement messages = XElement.Load(HostingEnvironment.MapPath("/App_Data/") + "Tjänstemeddelanden.xml");
            messages.Add(newMessage.toXml());
            messages.Save(HostingEnvironment.MapPath("/App_Data/") + "Tjänstemeddelanden.xml");

            return View(viewPassager);
        }


    }
}
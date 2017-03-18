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
        private static ProjectServiceReference1.Service1Client client = new ProjectServiceReference1.Service1Client();
        private static XElement locationList;
        
        // GET: Sök
        public ActionResult Sök()
        {
            locationList = XElement.Load(client.GetAllLocations().CreateNavigator().ReadSubtree());

            List<SelectListItem> dropdown = new List<SelectListItem>();
            foreach (var location in locationList.Descendants("Location"))
            {
                dropdown.Add(new SelectListItem { Text = location.Element("Name").Value, Value = location.Element("Epc").Value });
            }
            dropdown.Sort((x, y) => string.Compare(x.Text, y.Text));
            ViewBag.Sokning = dropdown;
            return View();
        }

        [HttpPost]
        public ActionResult Sök(string Location, DateTime From, DateTime Tom, string user)
        {
            int error = 1;
            Tjänstemeddelande newMessage;
            List<SelectListItem> dropdown = new List<SelectListItem>();
            
            locationList = XElement.Load(client.GetAllLocations().CreateNavigator().ReadSubtree());
            
            foreach (var location in locationList.Descendants("Location"))
            {
                dropdown.Add(new SelectListItem { Text = location.Element("Name").Value, Value = location.Element("Epc").Value });
            }
            
            ViewBag.Sokning = dropdown;
            string urn = Location;
            DateTime _from = From;
            DateTime _to = Tom;
            var search = Location +", " + From+", "+Tom+", false";
            
            XElement x;
            if (!IIProjectClient.Models.User.IsUser(user))
            {
                error = 3;
                x = new XElement("FordonsPassager", new XAttribute("xmlns", ""));
                newMessage = new Tjänstemeddelande(error, "Grupp 10", "Järnkoll v0.3.3", user, search);
                x.AddFirst(newMessage.toXml());
                XElement message = XElement.Load(HostingEnvironment.MapPath("/App_Data/") + "Tjänstemeddelanden.xml");
                message.Add(newMessage.toXml());
                message.Save(HostingEnvironment.MapPath("/App_Data/") + "Tjänstemeddelanden.xml");
                return RedirectToAction("Index", "Home");
            }

            // Service call (rightmost bool: refresh (delete and fetch new) masterdata in service)
            try { x = XElement.Load(client.GetEventsForLocation(urn, _from, _to, false).CreateNavigator().ReadSubtree());
            

            }
            catch { 
                error = 2;
                x = new XElement("FordonsPassager", new XAttribute("xmlns",""));
            }
            // Convert to FordonsPassage class
            IEnumerable<FordonPassage> viewPassager = (
                                                        //from passager in passagerList.Elements("FordonPassage")
                                                        from    passager in x.Elements("FordonPassage")
                                                        let     passage = FordonPassage.fromXML(passager)
                                                        select  passage
                                                        ).OrderByDescending(p => p.Tid);
            newMessage = new Tjänstemeddelande(error, "Grupp 10", "Järnkoll v0.3.3", user, search);         
            x.AddFirst(newMessage.toXml());
            XElement messages = XElement.Load(HostingEnvironment.MapPath("/App_Data/") + "Tjänstemeddelanden.xml");
            messages.Add(newMessage.toXml());
            messages.Save(HostingEnvironment.MapPath("/App_Data/") + "Tjänstemeddelanden.xml");

            return View(viewPassager);
        }
    }
}
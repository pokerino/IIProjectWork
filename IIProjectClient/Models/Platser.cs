using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace IIProjectClient.Models
{
    public class Platser
    {
        public string epc {get;set;}
        public string name {get;set;}
        
        public static Platser fromXml(XElement x)
        {
            Platser plats = new Platser();

            plats.epc = x.Element("Epc").Value;
            plats.name = x.Element("Name").Value;

            return plats;
        }
    }
}
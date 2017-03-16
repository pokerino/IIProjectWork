using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace IIProjectClient.Models
{
    public class FordonPassage
    {
        // Tid
        public DateTime Tid { get; set; }

        // Fordon
        public string FordonEPC { get; set; }
        public long EVN { get; set; }
        public string Fordonsinnehavare { get; set; }
        public string UnderhallsansvarigtForetag { get; set; }
        public string FordonsTyp { get; set; }
        public string FordonsunderkategoriKodFullVardeSE { get; set; }
        public string FordonsgodkannandeFullVardeSE { get; set; }
        /*public string FordonsgodkannandeGiltigtFrom { get; set; }
        public string FordonsgodkannandeGiltigtTom { get; set; } */
        public Nullable<DateTime> FordonsgodkannandeGiltigtFrom { get; set; }
        public Nullable<DateTime> FordonsgodkannandeGiltigtTom { get; set; } 

        // Plats
        public string LocationEpc { get; set; }
        public string LocationName { get; set; }



        public static FordonPassage fromXML(XElement x)
        {
            FordonPassage fp = new FordonPassage();

            fp.Tid = Convert.ToDateTime(x.Element("Tid").Value.ToString());

            fp.LocationName = x.Element("Location").Element("Name").Value.ToString();
            fp.LocationEpc = x.Element("Location").Element("Epc").Value.ToString();

            fp.FordonEPC = x.Element("Fordon").Element("EPC").Value.ToString();
            fp.EVN = Convert.ToInt64(x.Element("Fordon").Element("EVN").Value.ToString());
            fp.Fordonsinnehavare = x.Element("Fordon").Element("Fordonsinnehavare").Value.ToString();
            fp.UnderhallsansvarigtForetag = x.Element("Fordon").Element("UnderhallsansvarigtForetag").Value.ToString();
            fp.FordonsTyp = x.Element("Fordon").Element("FordonsTyp").Value.ToString();
            fp.FordonsunderkategoriKodFullVardeSE = x.Element("Fordon").Element("FordonsunderkategoriKodFullVardeSE").Value.ToString();
            fp.FordonsgodkannandeFullVardeSE = x.Element("Fordon").Element("FordonsgodkannandeFullVardeSE").Value.ToString();
            if (x.Element("Fordon").Elements("GiltigtFrom").Any())
            {
//                fp.FordonsgodkannandeGiltigtFrom = x.Element("Fordon").Element("GiltigtFrom").Value;
                fp.FordonsgodkannandeGiltigtFrom = Convert.ToDateTime(x.Element("Fordon").Element("GiltigtFrom").Value);
            }
            else
            {
                fp.FordonsgodkannandeGiltigtFrom = null;
            }
            if (x.Element("Fordon").Elements("GiltigtTom").Any())
            {
//                fp.FordonsgodkannandeGiltigtTom = x.Element("Fordon").Element("GiltigtTom").Value;
                fp.FordonsgodkannandeGiltigtTom = Convert.ToDateTime(x.Element("Fordon").Element("GiltigtTom").Value);
            }
            else
            {
                fp.FordonsgodkannandeGiltigtTom = null;
            }

            return fp;
        }

    }
}
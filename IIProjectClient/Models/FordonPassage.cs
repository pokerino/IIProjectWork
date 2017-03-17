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
        public Nullable<long> EVN { get; set; }
        public string Fordonsinnehavare { get; set; }
        public string UnderhallsansvarigtForetag { get; set; }
        public string FordonsTyp { get; set; }
        public string FordonsunderkategoriKodFullVardeSE { get; set; }
        public string FordonsgodkannandeFullVardeSE { get; set; }
        public Nullable<DateTime> FordonsgodkannandeGiltigtFrom { get; set; }
        public Nullable<DateTime> FordonsgodkannandeGiltigtTom { get; set; } 

        // Plats
        public string LocationEpc { get; set; }
        public string LocationName { get; set; }



        public static FordonPassage fromXML(XElement x)
        {
            FordonPassage fp = new FordonPassage();

            if (x.Elements("Tid").Any())
                fp.Tid = Convert.ToDateTime(x.Element("Tid").Value.ToString());

            if (x.Element("Location").Elements("Name").Any())
                fp.LocationName = x.Element("Location").Element("Name").Value.ToString();
            if (x.Element("Location").Elements("Epc").Any())
                fp.LocationEpc = x.Element("Location").Element("Epc").Value.ToString();

            if (x.Element("Fordon").Elements("EPC").Any())
                fp.FordonEPC = x.Element("Fordon").Element("EPC").Value.ToString();
            if (x.Element("Fordon").Elements("EVN").Any())
                fp.EVN = Convert.ToInt64(x.Element("Fordon").Element("EVN").Value.ToString());
            if (x.Element("Fordon").Elements("Fordonsinnehavare").Any())
                fp.Fordonsinnehavare = x.Element("Fordon").Element("Fordonsinnehavare").Value.ToString();
            if (x.Element("Fordon").Elements("UnderhallsansvarigtForetag").Any())
                fp.UnderhallsansvarigtForetag = x.Element("Fordon").Element("UnderhallsansvarigtForetag").Value.ToString();
            if (x.Element("Fordon").Elements("FordonsTyp").Any())
                fp.FordonsTyp = x.Element("Fordon").Element("FordonsTyp").Value.ToString();
            if (x.Element("Fordon").Elements("FordonsunderkategoriKodFullVardeSE").Any())
                fp.FordonsunderkategoriKodFullVardeSE = x.Element("Fordon").Element("FordonsunderkategoriKodFullVardeSE").Value.ToString();
            if (x.Element("Fordon").Elements("FordonsgodkannandeFullVardeSE").Any())
                fp.FordonsgodkannandeFullVardeSE = x.Element("Fordon").Element("FordonsgodkannandeFullVardeSE").Value.ToString();
            if (x.Element("Fordon").Elements("GiltigtFrom").Any())
                fp.FordonsgodkannandeGiltigtFrom = Convert.ToDateTime(x.Element("Fordon").Element("GiltigtFrom").Value);
            if (x.Element("Fordon").Elements("GiltigtTom").Any())
                fp.FordonsgodkannandeGiltigtTom = Convert.ToDateTime(x.Element("Fordon").Element("GiltigtTom").Value);
            
            return fp;
        }

    }
}
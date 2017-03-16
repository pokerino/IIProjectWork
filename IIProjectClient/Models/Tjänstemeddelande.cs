using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace IIProjectClient.Models
{
    public class Tjänstemeddelande
    {
        //Svarsinformation
        public int Svarskod { get; set; }
        public string Meddelande { get; set; }
        public string Tjänsteansvarig { get; set; }
        public string Applikation { get; set; }
        public DateTime Svarstid { get; set; }

        //Anropsinformation
        public string Anropsansvarig { get; set; }
        public string Argument { get; set; }



        public XElement toXml()
        {
            XElement newXml = new XElement("Tjänstemeddelande",
                new XElement("Svarsinformation",
                    new XElement("Svarskod", Svarskod),
                    new XElement("Meddelande", Meddelande),
                    new XElement("Tjänsteansvarig", Tjänsteansvarig),
                    new XElement("Applikation", Applikation),
                    new XElement("Svarstid", Svarstid)),
                new XElement("Anropsinformation",
                    new XElement("Anropsansvarig", Anropsansvarig),
                    new XElement("Argument", Argument)));
            return newXml;
        }

        public Tjänstemeddelande(int _svar, string _ansvarig, string _applikation, string _användare, string _argument)
        {
            Svarskod = _svar;
            switch (_svar)
            {
                case 1:
                    Meddelande = "Anrop lyckat";
                    break;
                case 2:
                    Meddelande = "Interntfel, kan ej utföra operation";
                    break;
                case 3:
                    Meddelande = "Autensitering misslyckad, icke godkänd användare";
                    break;
            }
            Tjänsteansvarig = _ansvarig;
            Applikation = _applikation;
            Svarstid = DateTime.Now;
            Anropsansvarig = _användare;
            Argument = _argument;

        }

    }
}
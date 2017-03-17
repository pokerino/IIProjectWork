using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using System.Xml.Linq;

namespace IIProjectService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}
        private static XElement Vehicles = new XElement("root", null);
        private static XElement Locations = new XElement("Locations", null);

        // Forward mehtods
        public IEnumerable<String> GetFilenames()
        {
            ServiceReference1.EpcisEventServiceClient client = new ServiceReference1.EpcisEventServiceClient();

            IEnumerable<String> filenames = client.GetFilenames();

            client.Close();

            return filenames;

        }

        public XElement GetEvent(string filename)
        {
            ServiceReference1.EpcisEventServiceClient client = new ServiceReference1.EpcisEventServiceClient();

            XElement e = new XElement("root", null);

            e = client.GetEvent(filename);

            client.Close();

            return e;

        }

        public IEnumerable<XElement> GetEvents(DateTime fromInclusive, DateTime toInclusive, String readPointEPC)
        {
            ServiceReference1.EpcisEventServiceClient client = new ServiceReference1.EpcisEventServiceClient();

            IEnumerable<XElement> iexe = client.GetEvents(fromInclusive, toInclusive, readPointEPC);

            return iexe;
        }


        public XElement GetVehicle(String epc)
        {
            ServiceReference1.NamingServiceClient client = new ServiceReference1.NamingServiceClient();

            XElement e = new XElement("root", null);

            e = client.GetVehicle(epc);

            return e;
        }

        public XElement GetLocation(String epc)
        {
            ServiceReference1.NamingServiceClient client = new ServiceReference1.NamingServiceClient();

            XElement e = new XElement("root", null);

            e = client.GetLocation(epc);

            return e;

        }

        public IEnumerable<XElement> GetAllLocations()
        {
            ServiceReference1.NamingServiceClient client = new ServiceReference1.NamingServiceClient();

            IEnumerable<XElement> iexe = (IEnumerable<XElement>)client.GetAllLocations();

            return iexe;

        }

        //Unique own methods
        //Hämtar alla events inom angivet datumintervall
        public XElement GetEventsForLocation(string locationUrn, DateTime fromDate, DateTime toDate, bool resetMasterData)
        {
            if(resetMasterData == true)
            {
                Locations.RemoveAll();
                Vehicles.RemoveAll();
            }


            ServiceReference1.EpcisEventServiceClient client = new ServiceReference1.EpcisEventServiceClient();

            XElement[] reply = new XElement[1];

            reply = client.GetEvents(fromDate, toDate, locationUrn);

            client.Close();

            // add vehicle
            foreach (XElement x in reply.Descendants("epcList"))
                x.AddAfterSelf(new XElement(VehicleFromService(x.Element("epc").Value.ToString())));

            // add location
            foreach (XElement x in reply.Descendants("ObjectEvent").Descendants("readPoint"))
                x.AddAfterSelf(new XElement(LocationFromService(x.Element("id").Value.ToString())));

            XElement replyAsXElement = new XElement("FordonsPassager", null);

            // tvätta
            foreach (XElement x in reply.Descendants("ObjectEvent"))
            {
                x.Element("eventTime").Name = "Tid";
                x.Element("eventTimeZoneOffset").Remove();
                x.Element("epcList").Remove();
                x.Element("action").Remove();
                x.Element("bizStep").Remove();
                x.Element("readPoint").Remove();
                x.Name = "FordonPassage";

                replyAsXElement.Add(x);
            }

            //XElement replyXElementWrapped = new XElement("FordonsPassager", replyAsXElement);

            return replyAsXElement;//replyXElementWrapped;
        }

        private XElement VehicleFromService(string urn)
        {
            XElement reply = new XElement("root", null);
            reply = null;

            if (Vehicles.Elements().Any())
            {
                reply = (
                   from x in Vehicles.Elements("Fordon")
                   where x.Element("EPC").Value.Equals(urn)
                   select new XElement(x)
                   ).FirstOrDefault();
            }
            //if (reply.IsEmpty == true)
            if (reply == null)
            {

                ServiceReference1.NamingServiceClient client = new ServiceReference1.NamingServiceClient();

                reply = client.GetVehicle(urn);

                client.Close();

                XElement reply2 = new XElement
                                    (
                                        "Fordon",
                                        new XElement
                                            ("EPC", urn),
                                        new XElement
                                            ("EVN", reply.Element("Fordonsindivider").Element("FordonsIndivid").Element("Fordonsnummer").Value),
                                        new XElement
                                            ("Fordonsinnehavare", reply.Element("Fordonsindivider").Element("FordonsIndivid").Element("Fordonsinnehavare").Element("Foretag").Value),
                                        new XElement
                                            ("UnderhallsansvarigtForetag", reply.Element("Fordonsindivider").Element("FordonsIndivid").Element("UnderhallsansvarigtForetag").Element("Foretag").Value),
                                        new XElement
                                            ("FordonsTyp", reply.Element("FordonsTyp").Element("FordonskategoriKodFullVardeSE").Value),
                                        new XElement
                                            ("FordonsunderkategoriKodFullVardeSE", reply.Element("FordonsTyp").Element("FordonsunderkategoriKodFullVardeSE").Value),
                                        new XElement
                                            ("FordonsgodkannandeFullVardeSE", reply.Element("Fordonsindivider").Element("FordonsIndivid").Element("Godkannande").Element("FordonsgodkannandeFullVardeSE").Value),

                                            (reply.Element("Fordonsindivider").Element("FordonsIndivid").Element("Godkannande").Elements("GiltigtTom").Any()) ?
                                                new XElement
                                                    ("GiltigtTom", reply.Element("Fordonsindivider").Element("FordonsIndivid").Element("Godkannande").Element("GiltigtTom").Value)
                                                : null,

                                            (reply.Element("Fordonsindivider").Element("FordonsIndivid").Element("Godkannande").Elements("GiltigtFrom").Any()) ?
                                                new XElement
                                                    ("GiltigtFrom", reply.Element("Fordonsindivider").Element("FordonsIndivid").Element("Godkannande").Element("GiltigtFrom").Value)
                                                : null
                    );

                Vehicles.Add(reply2);

                return reply2;
            }
            return reply;
        }

        private XElement LocationFromService(string urn)
        {
            XElement reply = new XElement("root", null);
            reply = null;

            if (Locations.Elements().Any())
            {
                reply = (
                   from x in Locations.Elements("Location")
                   where x.Element("Epc").Value.ToString().Equals(urn)
                   select new XElement(x)
                   ).FirstOrDefault();
            }
            //if (reply.IsEmpty == true)
            if (reply == null)
            {

                ServiceReference1.NamingServiceClient client = new ServiceReference1.NamingServiceClient();

                //XElement reply = new XElement("root", null);

                reply = client.GetLocation(urn);

                client.Close();
                //XElement reply2 = new XElement("Plats", reply.Element("Location").Element("Name").Value);
                reply = (XElement)reply.Element("Location");
                Locations.Add(reply);
            }
            //return reply2;
            return reply;//.Element("Location");
        }
    }
}

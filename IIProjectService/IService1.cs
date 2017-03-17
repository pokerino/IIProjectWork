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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
        [OperationContract]
        IEnumerable<String> GetFilenames();


        [OperationContract]
        XElement GetEvent(string filename);


        [OperationContract]
        IEnumerable<XElement> GetEvents(DateTime fromInclusive, DateTime toInclusive, String readPointEPC);

        [OperationContract]
        XElement GetVehicle(String epc);

        [OperationContract]
        XElement GetLocation(String epc);

        [OperationContract]
        IEnumerable<XElement> GetAllLocations();

        [OperationContract]
        XElement GetEventsForLocation(string locationUrn, DateTime fromDate, DateTime toDate, bool resetMasterData);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}
}

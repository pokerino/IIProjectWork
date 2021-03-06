﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.36366
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IIProjectClient.ProjectServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ArrayOfXElement", Namespace="http://schemas.datacontract.org/2004/07/System.Xml.Linq", ItemName="XElement")]
    [System.SerializableAttribute()]
    public class ArrayOfXElement : System.Collections.Generic.List<System.Xml.XmlElement> {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProjectServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetFilenames", ReplyAction="http://tempuri.org/IService1/GetFilenamesResponse")]
        string[] GetFilenames();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetFilenames", ReplyAction="http://tempuri.org/IService1/GetFilenamesResponse")]
        System.Threading.Tasks.Task<string[]> GetFilenamesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetEvent", ReplyAction="http://tempuri.org/IService1/GetEventResponse")]
        System.Xml.XmlElement GetEvent(string filename);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetEvent", ReplyAction="http://tempuri.org/IService1/GetEventResponse")]
        System.Threading.Tasks.Task<System.Xml.XmlElement> GetEventAsync(string filename);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetEvents", ReplyAction="http://tempuri.org/IService1/GetEventsResponse")]
        IIProjectClient.ProjectServiceReference1.ArrayOfXElement GetEvents(System.DateTime fromInclusive, System.DateTime toInclusive, string readPointEPC);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetEvents", ReplyAction="http://tempuri.org/IService1/GetEventsResponse")]
        System.Threading.Tasks.Task<IIProjectClient.ProjectServiceReference1.ArrayOfXElement> GetEventsAsync(System.DateTime fromInclusive, System.DateTime toInclusive, string readPointEPC);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetVehicle", ReplyAction="http://tempuri.org/IService1/GetVehicleResponse")]
        System.Xml.XmlElement GetVehicle(string epc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetVehicle", ReplyAction="http://tempuri.org/IService1/GetVehicleResponse")]
        System.Threading.Tasks.Task<System.Xml.XmlElement> GetVehicleAsync(string epc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetLocation", ReplyAction="http://tempuri.org/IService1/GetLocationResponse")]
        System.Xml.XmlElement GetLocation(string epc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetLocation", ReplyAction="http://tempuri.org/IService1/GetLocationResponse")]
        System.Threading.Tasks.Task<System.Xml.XmlElement> GetLocationAsync(string epc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllLocations", ReplyAction="http://tempuri.org/IService1/GetAllLocationsResponse")]
        System.Xml.XmlElement GetAllLocations();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllLocations", ReplyAction="http://tempuri.org/IService1/GetAllLocationsResponse")]
        System.Threading.Tasks.Task<System.Xml.XmlElement> GetAllLocationsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetEventsForLocation", ReplyAction="http://tempuri.org/IService1/GetEventsForLocationResponse")]
        System.Xml.XmlElement GetEventsForLocation(string locationUrn, System.DateTime fromDate, System.DateTime toDate, bool resetMasterData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetEventsForLocation", ReplyAction="http://tempuri.org/IService1/GetEventsForLocationResponse")]
        System.Threading.Tasks.Task<System.Xml.XmlElement> GetEventsForLocationAsync(string locationUrn, System.DateTime fromDate, System.DateTime toDate, bool resetMasterData);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : IIProjectClient.ProjectServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<IIProjectClient.ProjectServiceReference1.IService1>, IIProjectClient.ProjectServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] GetFilenames() {
            return base.Channel.GetFilenames();
        }
        
        public System.Threading.Tasks.Task<string[]> GetFilenamesAsync() {
            return base.Channel.GetFilenamesAsync();
        }
        
        public System.Xml.XmlElement GetEvent(string filename) {
            return base.Channel.GetEvent(filename);
        }
        
        public System.Threading.Tasks.Task<System.Xml.XmlElement> GetEventAsync(string filename) {
            return base.Channel.GetEventAsync(filename);
        }
        
        public IIProjectClient.ProjectServiceReference1.ArrayOfXElement GetEvents(System.DateTime fromInclusive, System.DateTime toInclusive, string readPointEPC) {
            return base.Channel.GetEvents(fromInclusive, toInclusive, readPointEPC);
        }
        
        public System.Threading.Tasks.Task<IIProjectClient.ProjectServiceReference1.ArrayOfXElement> GetEventsAsync(System.DateTime fromInclusive, System.DateTime toInclusive, string readPointEPC) {
            return base.Channel.GetEventsAsync(fromInclusive, toInclusive, readPointEPC);
        }
        
        public System.Xml.XmlElement GetVehicle(string epc) {
            return base.Channel.GetVehicle(epc);
        }
        
        public System.Threading.Tasks.Task<System.Xml.XmlElement> GetVehicleAsync(string epc) {
            return base.Channel.GetVehicleAsync(epc);
        }
        
        public System.Xml.XmlElement GetLocation(string epc) {
            return base.Channel.GetLocation(epc);
        }
        
        public System.Threading.Tasks.Task<System.Xml.XmlElement> GetLocationAsync(string epc) {
            return base.Channel.GetLocationAsync(epc);
        }
        
        public System.Xml.XmlElement GetAllLocations() {
            return base.Channel.GetAllLocations();
        }
        
        public System.Threading.Tasks.Task<System.Xml.XmlElement> GetAllLocationsAsync() {
            return base.Channel.GetAllLocationsAsync();
        }
        
        public System.Xml.XmlElement GetEventsForLocation(string locationUrn, System.DateTime fromDate, System.DateTime toDate, bool resetMasterData) {
            return base.Channel.GetEventsForLocation(locationUrn, fromDate, toDate, resetMasterData);
        }
        
        public System.Threading.Tasks.Task<System.Xml.XmlElement> GetEventsForLocationAsync(string locationUrn, System.DateTime fromDate, System.DateTime toDate, bool resetMasterData) {
            return base.Channel.GetEventsForLocationAsync(locationUrn, fromDate, toDate, resetMasterData);
        }
    }
}

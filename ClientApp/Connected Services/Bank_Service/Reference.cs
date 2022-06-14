﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientApp.Bank_Service {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Currency", Namespace="http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    public partial class Currency : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double ValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Code {
            get {
                return this.CodeField;
            }
            set {
                if ((object.ReferenceEquals(this.CodeField, value) != true)) {
                    this.CodeField = value;
                    this.RaisePropertyChanged("Code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Value {
            get {
                return this.ValueField;
            }
            set {
                if ((this.ValueField.Equals(value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Bank_Service.IBank_Service")]
    public interface IBank_Service {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBank_Service/Convert", ReplyAction="http://tempuri.org/IBank_Service/ConvertResponse")]
        double Convert(double amount, string from, string to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBank_Service/Convert", ReplyAction="http://tempuri.org/IBank_Service/ConvertResponse")]
        System.Threading.Tasks.Task<double> ConvertAsync(double amount, string from, string to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBank_Service/GetCurrencyInfo", ReplyAction="http://tempuri.org/IBank_Service/GetCurrencyInfoResponse")]
        ClientApp.Bank_Service.Currency[] GetCurrencyInfo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBank_Service/GetCurrencyInfo", ReplyAction="http://tempuri.org/IBank_Service/GetCurrencyInfoResponse")]
        System.Threading.Tasks.Task<ClientApp.Bank_Service.Currency[]> GetCurrencyInfoAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBank_ServiceChannel : ClientApp.Bank_Service.IBank_Service, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Bank_ServiceClient : System.ServiceModel.ClientBase<ClientApp.Bank_Service.IBank_Service>, ClientApp.Bank_Service.IBank_Service {
        
        public Bank_ServiceClient() {
        }
        
        public Bank_ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Bank_ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Bank_ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Bank_ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public double Convert(double amount, string from, string to) {
            return base.Channel.Convert(amount, from, to);
        }
        
        public System.Threading.Tasks.Task<double> ConvertAsync(double amount, string from, string to) {
            return base.Channel.ConvertAsync(amount, from, to);
        }
        
        public ClientApp.Bank_Service.Currency[] GetCurrencyInfo() {
            return base.Channel.GetCurrencyInfo();
        }
        
        public System.Threading.Tasks.Task<ClientApp.Bank_Service.Currency[]> GetCurrencyInfoAsync() {
            return base.Channel.GetCurrencyInfoAsync();
        }
    }
}
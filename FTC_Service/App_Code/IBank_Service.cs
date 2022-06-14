using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBank_Service" in both code and config file together.
[ServiceContract]
public interface IBank_Service
{
    [OperationContract]
    double Convert(double amount, string from, string to);
    [OperationContract]
    IEnumerable<Currency> GetCurrencyInfo();
}

[DataContract]
public class Currency
{
    [DataMember]
    public string Name { get; set; }
    [DataMember]
    public string Code { get; set; }
    [DataMember]
    public double Value { get; set; }
}
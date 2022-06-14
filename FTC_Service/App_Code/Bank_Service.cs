using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Bank_Service" in code, svc and config file together.
public class Bank_Service : IBank_Service
{
    IEnumerable<Currency> currencyInfo = null;
    IEnumerable<Currency> CurrencyInfo
    {
        get 
        {
            if (currencyInfo == null)
                currencyInfo = GetCurrenciesFromBank();
            return currencyInfo;
        }
    }

    public double Convert(double amount, string from, string to)
    {
        Currency fromCurrency = CurrencyInfo.Where(c => c.Code == from).FirstOrDefault();
        Currency toCurrency = CurrencyInfo.Where(c => c.Code == to).FirstOrDefault();

        if (fromCurrency == null || toCurrency == null)
            throw new Exception();

        return toCurrency.Value / fromCurrency.Value * amount;
    }

    public IEnumerable<Currency> GetCurrencyInfo()
    {
        return CurrencyInfo;
    }

    private IEnumerable<Currency> GetCurrenciesFromBank()
    {
        BankReference.DailyInfoSoapClient client = new BankReference.DailyInfoSoapClient();
        DataTable table = client.GetCursOnDate(DateTime.Now).Tables[0];

        List<Currency> result = new List<Currency>();
        foreach(DataRow row in table.Rows)
        {
            result.Add(new Currency()
            {
                Name = row["Vname"].ToString(),
                Code = row["Vcode"].ToString(),
                Value = double.Parse(row["Vcurs"].ToString().Trim())
            });
        }
        return result;
    }
}

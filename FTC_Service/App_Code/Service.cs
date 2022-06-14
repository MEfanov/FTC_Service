using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class FTCService : IFTCService
{
    public double CelsiusToFahrenheit(double celsius)
    {
        return 9 * 0.2 * celsius + 32;
    }

    public double FahrenheitToCelsius(double fahrenheit)
    {
        return 5 / 9 * (fahrenheit - 32);
    }
}

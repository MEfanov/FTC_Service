using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    public partial class FahrenheitCelsiusConverter : ValueConverterBase
    {
        public FahrenheitCelsiusConverter() : base()
        {
            LeftLabelText = "Градусов по шкале Цельсия";
            RightLabelText = "Градусов по шкале Фаренгейта";
        }

        public override string ConvertLeftToRight(string left)
        {
            if (LeftIsValid && double.TryParse(left, out double result))
            {
                FTC_Service.FTCServiceClient client = new FTC_Service.FTCServiceClient();
                return client.CelsiusToFahrenheit(result).ToString();
            }
            return "0";
        }

        public override string ConvertRightToLeft(string right)
        {
            if (RightIsValid && double.TryParse(right, out double result))
            {
                FTC_Service.FTCServiceClient client = new FTC_Service.FTCServiceClient();
                return client.FahrenheitToCelsius(result).ToString();
            }
            return "0";
        }

        public override bool ValidateLeft(string left)
        {
            return double.TryParse(left, out double a);
        }

        public override bool ValidateRight(string right)
        {
            return double.TryParse(right, out double a);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace ClientApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            FillCurrencyExpanders();
        }

        private void FillCurrencyExpanders()
        {
            Bank_Service.Bank_ServiceClient client = new Bank_Service.Bank_ServiceClient();

            ListBox leftList = new ListBox() { DisplayMemberPath = "Name", MaxHeight = 120, SelectedIndex = 0};
            leftList.SelectionChanged += LeftCurrencies_Selected;
            LeftCurrencies.Content = leftList;

            ListBox rightList = new ListBox() { DisplayMemberPath = "Name", MaxHeight = 120, SelectedIndex = 0 };
            rightList.SelectionChanged += RightCurrencies_Selected;
            RightCurrencies.Content = rightList;

            foreach(var row in client.GetCurrencyInfo())
            {
                leftList.Items.Add(row);
                rightList.Items.Add(row);
            }
        }

        private void LeftCurrencies_Selected(object sender, RoutedEventArgs e)
        {
            LeftCurrencies.Header = ((Bank_Service.Currency)((ListBox)sender).SelectedItem).Name;
        }

        private void RightCurrencies_Selected(object sender, RoutedEventArgs e)
        {
            RightCurrencies.Header = ((Bank_Service.Currency)((ListBox)sender).SelectedItem).Name;
        }

        private string ConvertLeftToRight(string left)
        {
            if (!CurrencyConverter.LeftIsValid)
                return "0";

            Bank_Service.Bank_ServiceClient client = new Bank_Service.Bank_ServiceClient();
            
            if(double.TryParse(left, out double res))
            {
                string leftCurrency = ((Bank_Service.Currency)((ListBox)LeftCurrencies.Content).SelectedItem).Code;
                string rightCurrency = ((Bank_Service.Currency)((ListBox)RightCurrencies.Content).SelectedItem).Code;
                return client.Convert(res, leftCurrency, rightCurrency).ToString();
            }
            else return "0";
        }

        private string ConvertRightToLeft(string right)
        {
            if (!CurrencyConverter.RightIsValid)
                return "0";

            Bank_Service.Bank_ServiceClient client = new Bank_Service.Bank_ServiceClient();

            if (double.TryParse(right, out double res))
            {
                string leftCurrency = ((Bank_Service.Currency)((ListBox)LeftCurrencies.Content).SelectedItem).Code;
                string rightCurrency = ((Bank_Service.Currency)((ListBox)RightCurrencies.Content).SelectedItem).Code;
                return client.Convert(res, rightCurrency, leftCurrency).ToString();
            }
            else return "0";
        }

        private bool ValidateLeft(string left)
        {
            return double.TryParse(left, out double res);
        }

        private bool ValidateRight(string right)
        {
            return double.TryParse(right, out double res);
        }
    }
}

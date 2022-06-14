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

namespace ClientApp
{
    public partial class ValueConverter : UserControl
    {
        public Predicate<string> ValidateLeft { get; set; }
        public Predicate<string> ValidateRight { get; set; }

        public Func<string, string> ConvertLeftToRight { get; set; }
        public Func<string, string> ConvertRightToLeft { get; set; }



        public Color TextColor_Default { get; set; } = Colors.Black;
        public Color TextColor_Invalid { get; set; } = Colors.Red;

        public string LeftLabelText
        {
            get { return LeftLabel.Text; }
            set { LeftLabel.Text = value; }
        }

        public string RightLabelText
        {
            get { return RightLabel.Text; }
            set { RightLabel.Text = value; }
        }

        public string LeftText 
        { 
            get { return LeftLabel.Text; }
            set { LeftLabel.Text = value; }
        }

        private string RightText
        {
            get { return RightLabel.Text; }
            set { RightLabel.Text = value; }
        }



        public bool HighlightInvalid { get; set; } = true;
        public bool DisableConvertOnInvalid { get; set; } = true;




        public bool LeftIsValid 
        { 
            get
            {
                if(ValidateLeft != null)
                    return ValidateLeft(LeftTextBox.Text);
                return true;
            } 
        }

        public bool RightIsValid
        {
            get
            {
                if (ValidateRight != null)
                    return ValidateRight(LeftTextBox.Text);
                return true;
            }
        }



        public ValueConverter()
        {
            InitializeComponent();
        }


        private void LeftToRight_Click(object sender, RoutedEventArgs e)
        {
            if (LeftIsValid && ConvertLeftToRight != null)
                RightTextBox.Text = ConvertLeftToRight(LeftTextBox.Text);
            else RightTextBox.Text = "";
        }


        private void RightToLeft_Click(object sender, RoutedEventArgs e)
        {
            if (RightIsValid && ConvertRightToLeft != null)
                LeftTextBox.Text = ConvertRightToLeft(RightTextBox.Text);
            else LeftTextBox.Text = "";
        }

        private void RightTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (RightIsValid)
            {
                RightTextBox.Foreground = new SolidColorBrush(TextColor_Default);
                RightToLeft.IsEnabled = true;
            }
            else
            {
                if(HighlightInvalid)
                    RightTextBox.Foreground = new SolidColorBrush(TextColor_Invalid);
                RightToLeft.IsEnabled = !DisableConvertOnInvalid;
            }
        }

        private void LeftTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LeftIsValid)
            {
                LeftTextBox.Foreground = new SolidColorBrush(TextColor_Default);
                LeftToRight.IsEnabled = true;
            }
            else
            {
                if (HighlightInvalid)
                    LeftTextBox.Foreground = new SolidColorBrush(TextColor_Invalid);
                LeftToRight.IsEnabled = !DisableConvertOnInvalid;
            }
        }
    }
}

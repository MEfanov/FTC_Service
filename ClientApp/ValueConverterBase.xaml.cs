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
    public abstract partial class ValueConverterBase : UserControl
    {
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
            get { return LeftTextBox.Text; }
            set { LeftTextBox.Text = value; }
        }

        public string RightText
        {
            get { return RightTextBox.Text; }
            set { RightTextBox.Text = value; }
        }



        public bool HighlightInvalid { get; set; } = true;
        public bool DisableConvertOnInvalid { get; set; } = true;




        public bool LeftIsValid
        {
            get
            {
                return ValidateLeft(LeftText);
            }
        }

        public bool RightIsValid
        {
            get
            {
                return ValidateRight(RightText);
            }
        }



        public ValueConverterBase()
        {
            InitializeComponent();
        }


        private void LeftToRight_Click(object sender, RoutedEventArgs e)
        {
            if (LeftIsValid)
                RightTextBox.Text = ConvertLeftToRight(LeftTextBox.Text);
            else RightTextBox.Text = "";
        }


        private void RightToLeft_Click(object sender, RoutedEventArgs e)
        {
            if (RightIsValid)
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
                if (HighlightInvalid)
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

        public abstract bool ValidateLeft(string left);
        public abstract bool ValidateRight(string right);
        public abstract string ConvertLeftToRight(string left);
        public abstract string ConvertRightToLeft(string right);
    }
}

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
using Taschenrechner.Classes;

namespace Taschenrechner
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool canCalculate = false;
        bool firstNumberExists = false;
        Calculate cal = new Calculate();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Result_Click(object sender, RoutedEventArgs e)
        {
            BuildSecondNumber();
            CalculateAndGetResult();
        }

        void CalculateAndGetResult()
        {
            cal.GetResult();
            cal._Number1 = cal._Result;
            firstNumberExists = false;
            ShowResult();
            cal._Number2 = 0;
            canCalculate = false;
        }

        void ShowResult()
        {
            txb_Display.Text = cal._Number1.ToString();
        }

        void ButtonClickNumbers(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string text = button.Content.ToString();
            BuildANumber(text);
        }

        void BuildANumber(string input)
        {
            if (txb_Display.Text == "0" && input != ",")
            {
                ClearDisplay();
            }

            string numberInString = txb_Display.Text;
            numberInString += input;
            txb_Display.Text = numberInString;
        }

        void ButtonClickOperator(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string operatorInString = button.Content.ToString();

            if (operatorInString == "X")
            {
                operatorInString = "*";
            }

            if (!canCalculate)
            {
                if (!firstNumberExists)
                {
                    PrepareFirstNumber(operatorInString);
                }
                else
                {
                    RememberOperator(operatorInString);
                    txb_Display.Text += operatorInString;
                    canCalculate = true;
                }
            } 
        }

        void PrepareFirstNumber(string operatorInString)
        {
            if (txb_Display.Text == "0" && operatorInString == "-")
            {
                BuildANumber(operatorInString);
            }
            else
            {
                BuildFirstNumber();
                RememberOperator(operatorInString);
                txb_Display.Text += operatorInString;
                firstNumberExists = true;
            }
        }

        void BuildFirstNumber()
        {
            cal._Number1 = Convert.ToDouble(txb_Display.Text);
        }

        void RememberOperator(string input)
        {
            cal._Operator = Convert.ToChar(input);
        }

        void BuildSecondNumber()
        {
            string cutFromString = $"{cal._Number1}{cal._Operator}";
            string number2InString = txb_Display.Text.Remove(0, cutFromString.Length);
            cal._Number2 = Convert.ToDouble(number2InString);
        }

        void ButtonClickClear(object sender, RoutedEventArgs e)
        {
            DisplayShow0();
        }

        void DisplayShow0()
        {
            txb_Display.Text = "0";
        }

        void ClearDisplay()
        {
            txb_Display.Text = "";
        }
    }
}

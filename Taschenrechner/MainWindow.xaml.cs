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
            if (!txb_Display.Text.EndsWith(cal._Operator.ToString()) && canCalculate)
            {
                if (txb_Display.Text.EndsWith(","))
                {
                    ChangeCommaIntoNumber();
                }
                CalculateAndGetResult();
                canCalculate = false;
                firstNumberExists = false;
            }
            
        }

        void CalculateAndGetResult()
        {
            BuildSecondNumber();
            cal.GetResult();
            cal._Number1 = cal._Result;
            cal._Number2 = 0;
            ShowResult();
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
            ChangeDisplayFontSize();
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

            if (txb_Display.Text.EndsWith("+") || txb_Display.Text.EndsWith("-") || txb_Display.Text.EndsWith("*") || txb_Display.Text.EndsWith("/") || txb_Display.Text.EndsWith("%"))
            {
                if(txb_Display.Text != "-")
                {
                    ChangeOperator(operatorInString);
                }
            }
            else if (txb_Display.Text.EndsWith(","))
            {
                DeleteLastSign();
            }
            else if (!canCalculate)
            {
                CheckOperatorProcess(operatorInString);
            }
            else
            {
                CalculateAndGetResult();
                RememberOperator(operatorInString);
                txb_Display.Text += operatorInString;
            }

            ChangeDisplayFontSize();
        }

        void ChangeOperator(string operatorInString)
        {
            DeleteLastSign();
            RememberOperator(operatorInString);
            if (txb_Display.Text != "0")
            {
                txb_Display.Text += operatorInString;
            }
            else
            {
                txb_Display.Text = operatorInString;
            }
        }

        void CheckOperatorProcess(string operatorInString)
        {
            if (!firstNumberExists && txb_Display.Text == "0")
            {
                if(operatorInString == "-")
                {
                    PrepareFirstNumber(operatorInString);
                }
            }
            else if (!firstNumberExists)
            {
                PrepareFirstNumber(operatorInString);
                canCalculate = true;
            }
            else
            {
                RememberOperator(operatorInString);
                txb_Display.Text += operatorInString;
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
            firstNumberExists = false;
            canCalculate = false;
        }

        void DisplayShow0()
        {
            txb_Display.Text = "0";
        }

        void ClearDisplay()
        {
            txb_Display.Text = "";
        }

        void ButtonClickDel(object sender, RoutedEventArgs e)
        {
            DeleteLastSign();
        }

        void DeleteLastSign()
        {
            int signsWithoutLastSingn = txb_Display.Text.Length - 1;

            if (txb_Display.Text.EndsWith("+") || txb_Display.Text.EndsWith("-") || txb_Display.Text.EndsWith("*") || txb_Display.Text.EndsWith("/"))
            {
                firstNumberExists = false;
            }
            if (txb_Display.Text != "0")
            {
                txb_Display.Text = txb_Display.Text.Substring(0, signsWithoutLastSingn);
            }
            if (txb_Display.Text == "")
            {
                DisplayShow0();
            }
        }

        void ChangeCommaIntoNumber()
        {
            DeleteLastSign();
            txb_Display.Text += "0,0";
        }

        void ChangeDisplayFontSize()
        {
            if (txb_Display.Text.Length < 10 )
            {
                txb_Display.FontSize = 25;
            }
            else if (txb_Display.Text.Length <= 15)
            {
                txb_Display.FontSize = 20;
            }
            else if (txb_Display.Text.Length <= 20)
            {
                txb_Display.FontSize = 14;
            }
            else
            {
                txb_Display.FontSize = 10;
            }
        }
    }
}

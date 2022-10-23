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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Result_Click(object sender, RoutedEventArgs e)
        {
            ReadDisplayInput();
        }

        void ReadDisplayInput()
        {
            string input = txb_Display.Text;
            Calculate cal = new Calculate();

            if (UserInputIsRight(input, cal) && CanCalculate(input, cal))
            {
                cal.GetResult();
            }
            else
            {
                MessageBox.Show("Falsche Eingabe!");
            }
            txb_Display.Text = $"{cal._Result}";
        }

        bool UserInputIsRight(string input, Calculate cal)
        {
            bool isRight = false;

            for (int i = 0; i < Operator().Length; i++)
            {
                if (input.Contains(Operator()[i]))
                {
                    isRight = true;
                    cal._Operator = Operator()[i];
                    break;
                }
            }
            return isRight;
        }

        bool CanCalculate(string input, Calculate cal)
        {
            bool areNumbers = false;

            string[] nums = input.Split(cal._Operator);
            try
            {
                cal._Number1 = Convert.ToDouble(nums[0]);
                cal._Number2 = Convert.ToDouble(nums[1]);
                areNumbers = true;
            }
            catch (Exception){ }
            
            return areNumbers;
        }

        char[] Operator()
        {
            return new char[] { '+', '-', '*', '/' };
        }


    }
}

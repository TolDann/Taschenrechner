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
            
        }

        char[] Operator()
        {
            return new char[] { '+', '-', '*', '/' };
        }

        void ButtonClickNumbers(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string text = button.Content.ToString();
            BuildANumber(text);
        }

        void BuildANumber(string input)
        {
            string numberInString = txb_Display.Text;
            numberInString += input;
            txb_Display.Text = numberInString;
        }
    }
}

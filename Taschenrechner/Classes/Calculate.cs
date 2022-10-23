using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Taschenrechner.Classes
{
    internal class Calculate
    {
        public double _Number1;
        public double _Number2;
        public char _Operator;
        public double _Result;

        public void GetResult()
        {
            switch (_Operator)
            {
                case '+':
                    _Result = _Number1 + _Number2;
                    break;
                case '-':
                    _Result = _Number1 - _Number2;
                    break;
                case '/':
                    _Result = _Number1 / _Number2;
                    break;
                case '*':
                    _Result = _Number1 * _Number2;
                    break;
            }
        }
    }
}

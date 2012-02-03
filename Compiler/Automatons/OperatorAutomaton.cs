using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler.Automatons
{
    static class OperatorAutomaton
    {
        public static bool Parse(string s)
        {
            //var x = s.Remove(' ');
            switch (s.FirstOrDefault())
            {
                case '+':
                case '-':
                case '*':
                case '/':
                case '%':
                case '^':
                case '=':
                case '<':
                    return true;
                default:
                    return false;    
            }
        }
    }
}

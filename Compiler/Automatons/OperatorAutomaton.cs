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
			// For this language, operators are all ALWAYS one character.
			if (s.Length > 1) { return false; }

            switch (s.First())
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

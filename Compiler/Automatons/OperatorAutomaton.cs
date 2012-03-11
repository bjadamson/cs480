using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler.Automatons
{
    public static class OperatorAutomaton
    {
        public static bool Parse(string s)
        {
			// For this language, operators are all ALWAYS three or less character.
			if (s.Length > 3) { return false; }

			if (s.Length > 1) {
				return s == "and" || s == "or" || s == "not" || s == "iff";
			}

			switch (s.First()) {
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

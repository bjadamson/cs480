using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler.Automatons
{
    public static class OperatorAutomaton
    {
		private static List<string> operators = new List<string>()
		{
			"and", "or", "not", "iff", "cos", "tan", "sin", "exp"
		};

        public static bool Parse(string s)
        {
			// For this language, operators are all ALWAYS three or less character.
			if (s.Length > 3) { return false; }

			if (s.Length > 1) {
				return operators.Contains(s);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler.Automatons
{
	class StringAutomaton
	{
		public static bool Parse(string s)
		{

			return s.Count(c => c == '"') == 2 &&
				(s.LastIndexOf('"') == s.Length - 1);
		}

		public static bool ParsePartialString(string s)
		{
			return s.Contains('"') && s.Count(c => c == '"') == 1;
		}
	}
}

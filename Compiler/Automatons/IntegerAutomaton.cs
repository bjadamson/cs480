using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler.Automatons
{
	public static class IntegerAutomaton
	{
		public static bool Parse(string s)
		{
			// Integers's do NOT contain white space
			if(s.Contains(' ')) { return false; }

			int result;
			return int.TryParse(s, out result);
		}
	}
}

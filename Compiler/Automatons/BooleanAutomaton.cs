using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler.Automatons
{
	public static class BooleanAutomaton
	{
		public static bool Parse(string s)
		{
			return s == true.ToString().ToLower() || s == false.ToString().ToLower();
		}
	}
}

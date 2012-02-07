using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler.Automatons
{
	public static class StringAutomaton
	{
		public static bool Parse(string s)
		{
			return s.Count(c => c == '"') - CountEscapedParenthesis(s, '\\') == 2 &&
				(s.LastIndexOf('"') == s.Length - 1);
		}

		public static bool ParsePartialString(string s)
		{
			return s.Contains('"') && 
				s.Count(c => c == '"') - CountEscapedParenthesis(s, '\\') == 1;
		}


		/// <summary>
		/// Count the occurence of the escaped character
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		private static int CountEscapedParenthesis(string s, char escapedCharacter)
		{
			int escapedParenthesisCount = 0;

			// index-based loop required (start at 1 so subtraction does not => OutOfArrayIndexException() )
			for (var i = 1; i < s.Length - 1; ++i) {
				if (s.ElementAt(i) == '"' && s.ElementAt(i - 1) == escapedCharacter) {
					++escapedParenthesisCount;
				}
			}

			return escapedParenthesisCount;
		}
	}
}


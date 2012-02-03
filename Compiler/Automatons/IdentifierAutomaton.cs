using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler.Automatons
{
    public static class IdentifierAutomaton
    {
        public static bool Parse(string s)
        {
            if (!char.IsLetter(s.First()) && s.First() != '_')
            {
                return false;
            }

            s = s.Substring(1);

            foreach (char c in s)
            {
                // Iterate through the string, if we find something other than a letter
                // or an underscore we know that this is not valid naming so we return false
                if (!char.IsLetterOrDigit(c) && c != '_')
                {
                    return false;
                }
            }
            return true;
        }
    }
}

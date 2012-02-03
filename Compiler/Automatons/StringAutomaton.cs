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
            var totalQuotes = 0;
            foreach (char c in s)
            {
                if(c.Equals('\\'))
                {
                    continue;
                }
                if (c.Equals('"'))
                {
                    totalQuotes++;
                    continue;
                }
                if(totalQuotes == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}

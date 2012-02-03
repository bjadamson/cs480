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
            if (s.Contains('"'))
            {
                s.Remove(s.IndexOf('"'));
                if (s.Contains('"'))
                {
                    return true;
                }
            }
            
            return false;
            
        }
    }
}

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
            if (s.Equals("true"))
            {
                return true;
            }
            else if (s.Equals("false"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

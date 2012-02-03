using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler.Automatons
{
    public static class RealAutomaton
    {
        public static bool Parse(string s)
        {
                double result;
                return double.TryParse(s, out result) && s.Contains('.');
        }
    }
}

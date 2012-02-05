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
                if (double.TryParse(s, out result) && s.Contains('.'))
                {
                    return true;
                }
                else if (s.Contains('f') && s.IndexOf('f') == (s.Length - 1))
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

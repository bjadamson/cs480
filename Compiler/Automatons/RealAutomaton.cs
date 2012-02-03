using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler.Automatons
{
    class RealAutomaton
    {
        public static bool Parse(string s)
        {
            double result;
            double.TryParse(s, out result);
            
            if (result != null)
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

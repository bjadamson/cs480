using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler.Automatons
{
    class IntegerAutomaton
    {
        public static bool Parse(string s)
        {
            int result;
            int.TryParse(s, out result);

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

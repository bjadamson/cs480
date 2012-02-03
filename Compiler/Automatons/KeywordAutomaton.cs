using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler.Automatons
{
    public static class KeywordAutomaton
    {
        private static List<string> RegisteredKeywords;

        static KeywordAutomaton()
        {
            RegisteredKeywords = new List<string>()
            {
                "int", "bool", "real", "string", 
                "println", "if", "while", "let", "assign"
            };
        }

        public static bool Parse(string s)
        {
            var whitespaceRemoved = s.Remove(' ');

            return RegisteredKeywords.Contains(whitespaceRemoved);
        }
    }
}

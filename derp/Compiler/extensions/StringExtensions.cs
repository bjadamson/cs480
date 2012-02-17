using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler.extensions
{
    public static class StringExtensions
    {
        public static ICollection<string> Tokenize(this string instance)
        {
            var a = instance.Replace('(', ' ');
            a = a.Replace(')', ' ');
			return a.Split(' ');
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokens;
using System.IO;
using Compiler.extensions;
using Compiler.Automatons;

namespace MilestoneTwo
{
	class Program
	{
		static void Main(string[] args)
		{
            List<string> lines = new List<string>();

            File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "\\test.txt")
                .ToList()
                .ForEach(x =>
                    {
                        var stringList = x.FormatLine();
                        foreach (var s in stringList)
                        {
                            if (s != string.Empty)
                            {
                                lines.Add(s);
                            }
                        }
                    }
                    );

            foreach(string s in lines)
            {
                if (OperatorAutomaton.Parse(s))
                {
                    // Need to create op token with type = operator, value = string
                    Token token = new Token(s, TokenType.Operator);
                }
                else if (KeywordAutomaton.Parse(s))
                {
                    // derpina
                    Token token = new Token(s, TokenType.Keyword);
                }
                
            }
		}
	}
}

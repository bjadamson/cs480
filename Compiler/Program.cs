using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokens;
using System.IO;
using Compiler.extensions;
using Compiler.Automatons;
using Compiler.LexicalAnalyzer;

namespace MilestoneTwo
{
    class Program
    {
		/// <summary>
		/// Automatically figures out the correct path depending on which platform you are on and gets the contents of the file
		/// </summary>
		/// <param name="filename"></param>
		/// <returns></returns>
		static IEnumerable<string> GetFileContents(string filename)
		{
			string fullFilePath = AppDomain.CurrentDomain.BaseDirectory;

			//var fileContents = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + @"\test.txt");

			if (Environment.OSVersion.ToString().Contains("Windows")) {
				fullFilePath += @"..\..\" + filename;
			} else {
				// assume unix
				fullFilePath += filename;
			}

			return File.ReadAllLines(fullFilePath);
		}
        static void Main(string[] args)
        {
			Console.WriteLine("{0}\n", Environment.OSVersion.ToString());
            Scanner scanner = new Scanner();
            List<string> lines = new List<string>();
            string actualString = "";
            List<Token> tokenList = new List<Token>();

			var fileContents = GetFileContents("test.txt");

            foreach (string content in fileContents)
            {
                var stringList = content.FormatLine();
                foreach (var s in stringList)
                {
                    if (actualString != string.Empty)
                    {
                        if (s.Contains('"'))
                        {
                            actualString = actualString + " " + s;
                            lines.Add(actualString);
                            actualString = " ";
                        }
                        else
                        {
                            actualString = actualString + " " + s;
                        }
                    }
                    else if (s != string.Empty)
                    {
                        if (s.Contains('"'))
                        {
                            actualString = s;
                        }
                        else
                        {
                            lines.Add(s);
                        }
                    }
                }
            }

            foreach (string s in lines)
            {
                var token = scanner.ParseToken(s);
                if (token == null)
                {
                    Console.WriteLine("You scrwered yo' shait up son'");
                }
                else
                {
                    Console.WriteLine("key:{0}, value:{1}", token.Key, token.Type);
                    tokenList.Add(token);
                }
            }
            Console.ReadLine();
        }
    }
}

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
    internal class Program
    {
		/// <summary>
		/// Entry-point for the application
		/// </summary>
		/// <param name="args">command arguments</param>
        static void Main(string[] args)
        {
            Scanner scanner = new Scanner();
            List<string> lines = new List<string>();
            string actualString = "";
            List<Token> tokenList = new List<Token>();

			StringBuilder sb = null;

            foreach (string content in GetFileContents("test.txt"))
            {
				var stringList = content.Tokenize()
					.Where(s => s != string.Empty);

                foreach (var s in stringList) 
				{
					if (sb != null) {
						sb.Append(" " + s);
						if (s.Contains('"')) {
							lines.Add(sb.ToString());
							sb = null;
						}
					}
                    else
                    {
                        if (s.Contains('"')) {
							sb = new StringBuilder(s);
                        } else {
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
                    Console.WriteLine("You screwed yo' shait up son'");
                }
                else
                {
                    Console.WriteLine("key:{0}, value:{1}", token.Key, token.Type);
                    tokenList.Add(token);
                }
            }
            Console.ReadLine();
        }


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
    }
}

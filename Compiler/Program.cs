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
            List<Token> tokenList = new List<Token>();

			string fileContents = GetFileContents("test.txt");
			while(fileContents.Any()) {
				var token = scanner.ParseToken(ref fileContents);
				tokenList.Add(token);

				scanner.RemoveTokenFromBeginning(ref fileContents, tokenList.Last());
			}

			Console.WriteLine(
				string.Join("", 
					tokenList.Select(item => string.Format("{0}\t:\t{1}\n", item.Key, item.Type))));
            Console.ReadLine();
        }


		/// <summary>
		/// Automatically figures out the correct path depending on which platform you are on and gets the contents of the file
		/// </summary>
		/// <param name="filename"></param>
		/// <returns></returns>
		static string GetFileContents(string filename)
		{
			string fullFilePath = AppDomain.CurrentDomain.BaseDirectory;

			if (Environment.OSVersion.ToString().Contains("Windows")) {
				fullFilePath += @"..\..\" + filename;
			} else {
				// assume unix
				fullFilePath += filename;
			}

			StringBuilder result = new StringBuilder();
			File.ReadAllLines(fullFilePath)
				.SelectMany(c => c)
				.ToList()
				.ForEach(x => {
					result.Append(x);
				});

			return result.ToString();
		}
    }
}

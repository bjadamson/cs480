using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compiler.LexicalAnalyzer;
using Tokens;
using System.IO;

namespace Compiler.Parser
{
	public class Parser
	{
		private Scanner scanner = new Scanner();
		List<Token> tokenList = new List<Token>();

		public void ParseFile(string filename) {

			string fileContents = GetFileContents(filename);
			while (fileContents.Any()) {
				var token = scanner.ParseToken(ref fileContents);
				tokenList.Add(token);
				scanner.RemoveTokenFromBeginning(ref fileContents, token);
			}
		}

		public void PrintTokens() {
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
		private string GetFileContents(string filename) {
			string fullFilePath = AppDomain.CurrentDomain.BaseDirectory;

			if (Environment.OSVersion.ToString().Contains("Windows")) {
				fullFilePath += @"..\..\..\" + filename;
			}
			else {
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

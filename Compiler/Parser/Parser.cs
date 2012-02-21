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
		private Token lastTokenScanned = null;
		private Scanner scanner = new Scanner();
		private List<Token> tokenList = new List<Token>();

		public void ParseFile(string filename) {

			string fileContents = GetFileContents(filename);
			ParseToken(ref fileContents);
		}

		public void PrintTokens() {
			Console.WriteLine(
				string.Join("",
					tokenList.Select(item => string.Format("{0}\t:\t{1}\n", item.Key, item.Type))));

			// only on windows do we need to read a line
			if (Environment.OSVersion.ToString().Contains("Windows")) {
				Console.ReadLine();
			}
		}

		private void ParseTokenHelper(ref string s, Token token) {

			if (token.Type == TokenType.LeftParen) {
				tokenList.Add(token);
				scanner.RemoveTokenFromBeginning(ref s, token);

				lastTokenScanned = scanner.GetNextToken(ref s);
				ParseTokenHelper(ref s, lastTokenScanned);
			}

			while (token.Type != TokenType.LeftParen && token.Type != TokenType.RightParen) {
				tokenList.Add(token);
				scanner.RemoveTokenFromBeginning(ref s, token);
				token = scanner.GetNextToken(ref s);
			}
			if (token.Type == TokenType.RightParen) {
				tokenList.Add(token);
				scanner.RemoveTokenFromBeginning(ref s, token);
			}
			else if (token.Type == TokenType.LeftParen) {
				if (s.Any()) {
					lastTokenScanned = scanner.GetNextToken(ref s);
					ParseTokenHelper(ref s, lastTokenScanned);
				}
			}
		}

		private void ParseToken(ref string s) {
			var firstToken = scanner.GetNextToken(ref s);
			lastTokenScanned = firstToken;

			if (firstToken.Type != TokenType.LeftParen) {
				throw new InvalidDataException(string.Format("Unexpected initial token {{{0} : {1}}}, expected {{'(' }}", firstToken.Key, firstToken.Type));
			}

			ParseTokenHelper(ref s, firstToken);

			if (lastTokenScanned.Type != TokenType.RightParen) {
				throw new InvalidDataException(string.Format("Unexpected final token {{{0} : {1}}}, expecting {{')'}}", lastTokenScanned.Key, lastTokenScanned.Type));
			}

			if (tokenList.Count == 2 && tokenList.ElementAt(0).Type == TokenType.LeftParen && tokenList.ElementAt(1).Type == TokenType.RightParen) {
				throw new InvalidDataException(string.Format("Parse error! Production rules do not allow S->epsilon."));
			}

			if (s.Any()) {
				throw new InvalidDataException(string.Format("Unexpected token {0}{1}, expected end of file.", lastTokenScanned.Key, lastTokenScanned.Type));
			}
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

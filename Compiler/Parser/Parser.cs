using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compiler.LexicalAnalyzer;
using Tokens;
using System.IO;

namespace Compiler.Parser
{
	enum ExpressionParseSucces { PASS, FAIL };

	public class Parser
	{
		private Token last = null;
		private Scanner scanner = new Scanner();
		private List<Token> tokenList = new List<Token>();
		private StringBuilder expressionBuilder = new StringBuilder();
		private List<Tuple<string, ExpressionParseSucces>> builtExpressions = new List<Tuple<string, ExpressionParseSucces>>();

		/// <summary>
		/// Parse the tokens within a file
		/// </summary>
		/// <param name="filename">contents of the file</param>
		public void ParseFile(string filename) {

			string fileContents = GetFileContents(filename);
			BeginParsingFile(ref fileContents);
		}

		/// <summary>
		/// Print the tokens out to the console.
		/// </summary>
		public void PrintTokens() {
			Console.WriteLine(
				string.Join("",
					tokenList.Select(item => string.Format("{0}\t:\t{1}\n", item.Key, item.Type))));
		}

		private void ParseExpressionHelper(ref string fileContents) {
		begin:
			if (last.Type == TokenType.LeftParen) {
				tokenList.Add(last);
				scanner.RemoveTokenFromBeginning(ref fileContents, last);
				expressionBuilder.Append(last.Key + " ");

				last = scanner.GetNextToken(ref fileContents);
				ParseExpressionHelper(ref fileContents);

				if (fileContents.Any()) {
					last = scanner.GetNextToken(ref fileContents);
					goto begin;
				}
			}
			while (last.Type != TokenType.LeftParen && last.Type != TokenType.RightParen) {
				tokenList.Add(last);
				scanner.RemoveTokenFromBeginning(ref fileContents, last);
				expressionBuilder.Append(last.Key + " ");

				if (!fileContents.Any()) {
					// expected left/right parenthesis
					throw new InvalidDataException(expressionBuilder.ToString());
				}
				last = scanner.GetNextToken(ref fileContents);
			}
			if (last.Type == TokenType.LeftParen) {

				tokenList.Add(last);
				scanner.RemoveTokenFromBeginning(ref fileContents, last);
				expressionBuilder.Append(last.Key + " ");

				last = scanner.GetNextToken(ref fileContents);
				ParseExpressionHelper(ref fileContents);

				if (fileContents.Any()) {
					last = scanner.GetNextToken(ref fileContents);
					goto begin;
				}
			}
			else if (last.Type == TokenType.RightParen) {

				tokenList.Add(last);
				if (!fileContents.Any()) {
					throw new InvalidDataException(expressionBuilder.ToString() + "\n");
				}
				scanner.RemoveTokenFromBeginning(ref fileContents, last);
				expressionBuilder.Append(last.Key + " ");
			}
		}

		/// <summary>
		/// Recursive token parser helper
		/// </summary>
		/// <param name="fileContents"></param>
		/// <param name="token"></param>
		private void ParseExpression(ref string fileContents) {

			last = scanner.GetNextToken(ref fileContents);
			expressionBuilder.Append(last.Key + " ");

			if (last.Type != TokenType.LeftParen) {
				throw new InvalidDataException(expressionBuilder.ToString().Replace(" ", ""));
			}

			tokenList.Add(last);
			scanner.RemoveTokenFromBeginning(ref fileContents, last);

			last = scanner.GetNextToken(ref fileContents);
			ParseExpressionHelper(ref fileContents);

		}

		private void ParseAllExpressions(ref string fileContents, Token token) {

			// If there is anything in fileContents, that means we are parsing the next expression within the file.
			while (fileContents.Any()) {

				try {
					ParseExpression(ref fileContents);

					if (tokenList.Count == 2 &&
							tokenList[0].Type == TokenType.LeftParen && tokenList[1].Type == TokenType.RightParen) {
						throw new InvalidDataException(string.Format("Parse error! Production rules do not allow S->epsilon."));
					}

					builtExpressions.Add(new Tuple<string, ExpressionParseSucces>(expressionBuilder.ToString(), ExpressionParseSucces.PASS));
				}
				catch (InvalidDataException ide) {
					var message = ide.Message.ToString() == string.Empty ? expressionBuilder.ToString() : ide.Message.ToString();
					builtExpressions.Add(new Tuple<string, ExpressionParseSucces>(expressionBuilder.ToString(), ExpressionParseSucces.FAIL));
					fileContents = string.Empty;
				}
				catch (InvalidOperationException ioe) {
					builtExpressions.Add(new Tuple<string, ExpressionParseSucces>(ioe.Message.ToString(), ExpressionParseSucces.FAIL));
					fileContents = string.Empty;

				}

				expressionBuilder.Clear();
				tokenList.Clear();
				scanner.ClearScannedTokens();
			}

			builtExpressions.ForEach(list =>
				Console.WriteLine(list.Item1 + string.Format("\t{0}", list.Item2.ToString())));
			Console.WriteLine("\n");
		}

		private void BeginParsingFile(ref string fileContents) {
			if (fileContents.Any()) {
				var firstToken = scanner.GetNextToken(ref fileContents);
				last = firstToken;

				if (firstToken.Type != TokenType.LeftParen) {
					Console.WriteLine("Expression: '{0}' does not begin with '(', invalid.", fileContents);
				}

				ParseAllExpressions(ref fileContents, firstToken);

				if (fileContents.Any()) {
					Console.WriteLine("Unexpected token \'{0}{1}\', expected end of file.", last.Key, last.Type);
				}
			}
			else {
				Console.WriteLine("File contains no tokens.\n\n");
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

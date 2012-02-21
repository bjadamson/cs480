using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokens;
using Compiler.Automatons;
using System.IO;

namespace Compiler.LexicalAnalyzer
{
	public class Scanner
	{
		/// <summary>
		/// Remove the token from the beginning of the string s
		/// </summary>
		/// <param name="s"></param>
		/// <param name="token"></param>
		public void RemoveTokenFromBeginning(ref string s, Token token)
		{
			s = s.Remove(0, token.Key.Length);

			// trim leading white-space, and the closing ')'
			s = s.TrimStart(' ');
		}

		/// <summary>
		/// Parse the input string for the first token
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public Token GetNextToken(ref string s)
		{
			var listOfPossibleTypes = new List<KeyValuePair<TokenType, int>>(10);

			var sb = new StringBuilder(s.First().ToString());
			int posInString = 0;
			int tokenLength = 0;
			bool automatonAcceptFlag = false;

			if (sb[0] == '(') {
				return new Token("(", TokenType.LeftParen);
			}
			else if(sb[0] == ')') {
				return new Token(")", TokenType.RightParen);
			}

			do {
				if (sb[sb.Length - 1] == ')' && !StringAutomaton.ParsePartialString(sb.ToString())) {

					// Remove the last parenthesis
					sb = sb.Remove(sb.Length - 1, 1);
					break;
				}

				automatonAcceptFlag = false;

				if (OperatorAutomaton.Parse(sb.ToString())) {
					listOfPossibleTypes.Add(new KeyValuePair<TokenType, int>(TokenType.Operator, tokenLength));
					automatonAcceptFlag = true;
				}
				if (KeywordAutomaton.Parse(sb.ToString())) {
					listOfPossibleTypes.Add(new KeyValuePair<TokenType, int>(TokenType.Keyword, tokenLength));
					automatonAcceptFlag = true;
				}
				if (BooleanAutomaton.Parse(sb.ToString())) {
					listOfPossibleTypes.Add(new KeyValuePair<TokenType, int>(TokenType.Boolean, tokenLength));
					automatonAcceptFlag = true;
				}
				if (RealAutomaton.Parse(sb.ToString())) {
					listOfPossibleTypes.Add(new KeyValuePair<TokenType, int>(TokenType.Real, tokenLength));
					automatonAcceptFlag = true;
				}	
				if (IntegerAutomaton.Parse(sb.ToString())) {
					listOfPossibleTypes.Add(new KeyValuePair<TokenType, int>(TokenType.Integer, tokenLength));
					automatonAcceptFlag = true;
				}
				if (StringAutomaton.Parse(sb.ToString())) {
					listOfPossibleTypes.Add(new KeyValuePair<TokenType, int>(TokenType.String, tokenLength));
					automatonAcceptFlag = true;
				}
				if (IdentifierAutomaton.Parse(sb.ToString())) {
					listOfPossibleTypes.Add(new KeyValuePair<TokenType, int>(TokenType.Identifier, tokenLength));
					automatonAcceptFlag = true;
				}

				if (!automatonAcceptFlag && StringAutomaton.ParsePartialString(sb.ToString())) {

					automatonAcceptFlag = true;
				}

				if (automatonAcceptFlag) {
					tokenLength++;
					posInString++;
					sb.Append(s.Length != posInString ? s.ElementAt(posInString) : ' ');
				}

			} while (automatonAcceptFlag);

			var check = listOfPossibleTypes.Select(x => x.Key);

			if (check.Contains(TokenType.Integer) && !check.Contains(TokenType.Real)) {
				foreach (var c in sb.ToString()) {
					if (!char.IsDigit(c) && c!= ' ') {
						throw new InvalidDataException(string.Format("Lexical analyzer could not tokenize token {0}", sb.ToString()));
					}
				}
			}
			if(check.Contains(TokenType.Real)) {
				foreach (var c in sb.ToString()) {
					if (!char.IsDigit(c) && c != '.' && c != ' ') {
						throw new InvalidDataException(string.Format("Lexical analyzer could not tokenize token {0}", sb.ToString()));
					}
				}
			}

			// order the possible types by the key
			var orderedByKey = listOfPossibleTypes
				.OrderByDescending(x => x.Value);

			// grab the longest-length value with the highest priority type
			var result = orderedByKey
				.Where(x => x.Value == orderedByKey.First().Value)
				.OrderBy(x => x.Key)
				.First();

			// construct the token with result
			return new Token(
				sb.ToString().Substring(0, result.Value + 1),
				result.Key);
	
		}
	}
}

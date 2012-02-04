using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokens;
using Compiler.Automatons;

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

			// trim leading white-space
			s = s.TrimStart(' ');
		}


		/// <summary>
		/// Parse the input string for the first token
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public Token ParseToken(string s)
        {
			var listOfPossibleTypes = new List<KeyValuePair<TokenType, int>>(10);

			var sb = new StringBuilder(s.First().ToString());
			int tokenLength = 0;
			bool automatonAcceptFlag = false;

			do {
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

					tokenLength += automatonAcceptFlag ? 1 : 0;
					sb.Append(s.ElementAt(tokenLength));
				}

			} while (automatonAcceptFlag);

			// order the possible types by the key
			var orderedByKey = listOfPossibleTypes
				.OrderBy(x => x.Key);

			// grab the longest-length value with the highest priority type
			var result = orderedByKey
				.Where(x => x.Key == orderedByKey.First().Key)
				.OrderByDescending(x => x.Value)
				.First();

			// construct the token with result
			return new Token(
				sb.ToString().Substring(0, result.Value + 1),
				result.Key);            
        }

	}
}

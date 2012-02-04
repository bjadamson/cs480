using System;

namespace Tokens
{
	public enum TokenType { Operator, Keyword, Real, Integer, Boolean, String, Identifier };

	public class Token
	{
		// Properties
        public string Key { get; set; }
        public TokenType Type { get; set; }

		public Token(string key, TokenType type)
		{
            Key = key;
            Type = type;
		}

		public Token(Expr expression)
		{
			
		}	

	}

}

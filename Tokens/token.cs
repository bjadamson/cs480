using System;

namespace Tokens
{
	public class Token
	{
		// Properties
		public Token token { get; private set; }
		public Expr expr { get; private set; }		

		public Token(Token tk)
		{
			token = tk;
		}

		public Token(Expr expression)
		{
			expr = expression;
		}	

	}

}

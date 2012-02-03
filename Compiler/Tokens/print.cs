using System;

namespace Tokens
{
	public class Print
	{
		// Properties
		public Atom atom { get; private set; }
		public Expr Expression { get; private set; }	
	
		public Print(Atom at)
		{
			atom = at;
		}

		public Print(Expr expr)
		{
			Expression = expr;
		}
	}
}

using System;

namespace Tokens
{
	public class Assign
	{
		// Properties
		public Atom atom { get; private set; }
		public Expr Expression { get; private set; }	
	
		public Assign(Atom at, Expr expr)
		{
			atom = at;
			Expression = expr;
		}	
	}
}

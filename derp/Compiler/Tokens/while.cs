using System;

namespace Tokens
{
	public class While
	{
		// Properties
		public Expr Expr1 { get; private set; }
		public Expr Expr2 { get; private set; }	
	
		public While(Expr expr1, Expr expr2)
		{
			Expr1 = expr1;
			Expr2 = expr2;	
		}
	}
}

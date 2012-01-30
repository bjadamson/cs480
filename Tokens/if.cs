using System;

namespace Tokens
{
	public class If
	{
		// Properties
		public Expr IfExpr { get; private set; }
		public Expr ThenExpr { get; private set; }	
		public Expr ElseExpr { get; private set; }
	
		public If(Expr ifexpr, Expr thenexpr, Expr elseexpr = null)
		{
			IfExpr = ifexpr;
			ThenExpr = thenexpr;
			ElseExpr = elseexpr;
		}
	}
}

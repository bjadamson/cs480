using System;

namespace Tokens
{
	public class ExprList
	{
		// Properties
		public Expr Expression { get; private set; }
		public ExprList ExpressionList { get; private set; }	
	
		public ExprList(Expr expr, ExprList list)
		{
			Expression = expr;
			ExpressionList = list;
		}
	}
}

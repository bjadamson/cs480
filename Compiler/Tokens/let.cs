using System;

namespace Tokens
{
	public class Let
	{
		// Properties
		public VariableList VL { get; private set; }
		public Stmt statement { get; private set; }	
		public ExprList expressionList { get; private set; }
	
		public Let(VariableList vl, Stmt st, ExprList list)
		{
			VL = vl;
			statement = st;
			expressionList = list;
		}
	}
}

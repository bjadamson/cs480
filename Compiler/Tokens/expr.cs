using System;

namespace Tokens
{
	public enum ExprType { expr_type, stmt_type, constant_type, variablelist_type, operator_type };
	public class Expr
	{
		// Properties
		public ExprType Expression
		{
			get
			{
				if(expression != null) { return ExprType.expr_type; }
				if(statement != null) { return ExprType.stmt_type; }
				if(@const != null) { return ExprType.constant_type; }
				if(variableList != null) { return ExprType.variablelist_type; }
				if(@operator != null) { return ExprType.operator_type; }
				throw new ArgumentNullException("ExprType");
			}
			private set { }
		}

		public Expr expression { get; set; }
		public Stmt statement { get; set; }
		public Constant @const { get; set; }
		public VariableList variableList { get; set; }
		public Operator @operator { get; set; }

		public Expr(Expr expr) { expression = expr; }
		public Expr(Stmt stmt) { statement = stmt; }
		public Expr(Constant constant) { @const = constant; }
		public Expr(VariableList vl) { variableList = vl; }
		public Expr(Operator op) { @operator = op; }
	}

}

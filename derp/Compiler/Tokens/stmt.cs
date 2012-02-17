using System;

namespace Tokens
{
	public enum StmtType { print_type, if_type, while_type, let_type, assign_type };

	public class Stmt
	{
		// Properties
		public StmtType Statement
		{
			get
			{
				if( print != null) { return StmtType.print_type; }
				if( @if != null) { return StmtType.if_type; }
				if( @while != null) { return StmtType.while_type; }
				if( let != null)  { return StmtType.let_type; }
				if( assign != null) { return StmtType.assign_type; }
				throw new ArgumentNullException("StmtType");
			}
			private set { }
		}

		public Print print { get; set; }
		public If @if { get; set; }
		public While @while { get; set; }
		public Let let { get; set; }
		public Assign assign { get; set; }

		public Stmt(Print printstmt) { print = printstmt; }
		public Stmt(If ifstmt) { @if = ifstmt; }
		public Stmt(While whilestmt) { @while = whilestmt; }
		public Stmt(Let letstmt) { let = letstmt; }
		public Stmt(Assign assignstmt) { assign = assignstmt; }
	}

}

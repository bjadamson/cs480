using System;

namespace Tokens
{
	public class Constant
	{
		public enum ConstType { bool_type, int_type, real_type, string_type };

		// Properties
		public ConstType constant
		{
			get
			{
				if(Bool != null) { return ConstType.bool_type; }
				if(Int != null) { return ConstType.int_type; }
				if(Real != null) { return ConstType.real_type; }
				if(@String != null) { return ConstType.string_type; }
				throw new ArgumentNullException("ConstType");
			}
			private set { }
		}

		public Tokens.Bool Bool { get; set; }
		public Tokens.Int Int { get; set; }
		public Tokens.Real Real { get; set; }
		public Tokens.String @String { get; set; }

		public Constant(Tokens.Bool val) { Bool = val; }
		public Constant(Tokens.Int val) { Int = val; }
		public Constant(Tokens.Real val) { Real = val; }
		public Constant(Tokens.String val) { @String = val; }
	}

}

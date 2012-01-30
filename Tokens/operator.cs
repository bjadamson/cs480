using System;

namespace Tokens
{
	public enum OperatorType { plus, minus, multiply, divide, modulous, exponent, equals, lessthan };

	public class Operator
	{
		public OperatorType OPType { get; private set; }
		
		public Operator(OperatorType optype)
		{
			OPType = optype;
		}
	}
}

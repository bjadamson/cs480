using System;
using System.Linq;

namespace Tokens
{
	/// <summary>
	/// The order of this enumeration MATTERS. The sort algorithm depends on the order of these operands.
	/// </summary>
	public enum TokenType { Operator, Keyword, Real, Integer, Boolean, String, Identifier, LeftParen, RightParen };

	public class Token
	{
		// Properties
        public string Key { get; set; }
        public TokenType Type { get; set; }

		public Token(string key, TokenType type)
		{
            Key = key;
            Type = type;
		}

		public override bool Equals(object obj)
		{
			if (obj.GetType() == typeof(Token)) {
				return ((Token)obj).Key == this.Key &&
					((Token)obj).Type == this.Type;
			}
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}

}

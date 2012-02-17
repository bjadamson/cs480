using System;

namespace Tokens
{
	public class VariableList
	{
		// Properties
		public Atom atom { get; private set; }
		public Constant constant { get; private set; }	
	
		public VariableList(Atom at, Constant cnst)
		{
			atom = at;
			constant = cnst;	
		}
	}
}

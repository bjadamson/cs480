using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokens;
using Compiler.Automatons;

namespace Compiler.LexicalAnalyzer
{
    public class Scanner
    {
        public Token ParseToken(string s)
        {
            Token token = null;
            if (OperatorAutomaton.Parse(s))
            {
                // Need to create op token with type = operator, value = string
                token = new Token(s, TokenType.Operator);
            }
            else if (KeywordAutomaton.Parse(s))
            {
                token = new Token(s, TokenType.Keyword);
            }
            else if (BooleanAutomaton.Parse(s))
            {
                token = new Token(s, TokenType.Boolean);
            }
            else if (RealAutomaton.Parse(s))
            {
                token = new Token(s, TokenType.Real);
            }
            else if (IntegerAutomaton.Parse(s))
            {
                token = new Token(s, TokenType.Integer);
            }
            else if (StringAutomaton.Parse(s))
            {
                token = new Token(s, TokenType.String);
            }
            else if (IdentifierAutomaton.Parse(s))
            {
                token = new Token(s, TokenType.Identifier);
            }

            return token;
        }
    }
}

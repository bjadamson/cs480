using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tokens;
using Compiler.LexicalAnalyzer;

namespace CompilerTester.LexicalAnalyzerTests
{
	[TestClass]
	public class LexicalAnalyzerTest
	{
		private Scanner _testScanner;

		private void ValidateExpectedVsActualTokens(List<Token> expectedTokens, List<Token> actualTokens) {
			Assert.AreEqual(expectedTokens.Count, actualTokens.Count);
			for (var i = 0; i < expectedTokens.Count; ++i) {
				Assert.AreEqual(actualTokens.ElementAt(i), expectedTokens.ElementAt(i));
			}
		}


		[TestMethod]
		public void AnalyzeTrueBoolean_Test()
		{
			_testScanner = new Scanner();

			Token expected = new Token("true", TokenType.Boolean);

			string s = "true";
			
			Token actual = _testScanner.GetNextToken(ref s);

			Assert.AreEqual(expected.Key, actual.Key);
			Assert.AreEqual(expected.Type, actual.Type);
		}
		
		[TestMethod]
		public void AnalyzeTrueIdentifier_Test()
		{
			_testScanner = new Scanner();

			Token expected = new Token("thisIdentifier", TokenType.Identifier);

			string s = ("thisIdentifier");

			Token actual = _testScanner.GetNextToken(ref s);

			Assert.AreEqual(expected.Key, actual.Key);
			Assert.AreEqual(expected.Type, actual.Type);
		}

		[TestMethod]
		public void AnalyzeTrueInteger_Test()
		{
			_testScanner = new Scanner();

			Token expected = new Token("1", TokenType.Integer);

			string s = "1";

			Token actual = _testScanner.GetNextToken(ref s);

			Assert.AreEqual(expected.Key, actual.Key);
			Assert.AreEqual(expected.Type, actual.Type);
		}

		[TestMethod]
		public void AnalyzeTrueKeyword_Test()
		{
			_testScanner = new Scanner();

			Token expected = new Token("int", TokenType.Keyword);

			string s = "int";

			Token actual = _testScanner.GetNextToken(ref s);

			Assert.AreEqual(expected.Key, actual.Key);
			Assert.AreEqual(expected.Type, actual.Type);
		}

		[TestMethod]
		public void AnalyzeTrueOperator_Test()
		{
			_testScanner = new Scanner();

			Token expected = new Token("+", TokenType.Operator);

			string s = "+";

			Token actual = _testScanner.GetNextToken(ref s);

			Assert.AreEqual(expected.Key, actual.Key);
			Assert.AreEqual(expected.Type, actual.Type);
		}

		[TestMethod]
		public void AnalyzeTrueReal_Test()
		{
			_testScanner = new Scanner();

			Token expected = new Token("10.0", TokenType.Real);

			string s = "10.0";

			Token actual = _testScanner.GetNextToken(ref s);

			Assert.AreEqual(expected.Key, actual.Key);
			Assert.AreEqual(expected.Type, actual.Type);
		}

		[TestMethod]
		public void AnalyzeTrueString_Test()
		{
			_testScanner = new Scanner();

			Token expected = new Token("\"This is a string\"", TokenType.String);

			string s = "\"This is a string\"";

			Token actual = _testScanner.GetNextToken(ref s);

			Assert.AreEqual(expected.Key, actual.Key);
			Assert.AreEqual(expected.Type, actual.Type);
		}

		[TestMethod]
		public void AnalyzeAssignString_Test()
		{
			_testScanner = new Scanner();

			List<Token> expectedList = new List<Token>();
			expectedList.Add(new Token("(", TokenType.LeftParen));
			expectedList.Add(new Token("assign", TokenType.Keyword));
			expectedList.Add(new Token("thisInt", TokenType.Identifier));
			expectedList.Add(new Token("1", TokenType.Integer));
			expectedList.Add(new Token(")", TokenType.RightParen));

			string s = "(assign thisInt 1)";

			List<Token> actualList = new List<Token>();

			while (s.Any())
			{
				var token = _testScanner.GetNextToken(ref s);
				actualList.Add(token);
				_testScanner.RemoveTokenFromBeginning(ref s, token);
			}

			ValidateExpectedVsActualTokens(expectedList, actualList);
		}

		[TestMethod]
		public void AnalyzeAssignStrinttoVarString_Test()
		{
			_testScanner = new Scanner();

			List<Token> expectedList = new List<Token>();
			expectedList.Add(new Token("(", TokenType.LeftParen));
			expectedList.Add(new Token("assign", TokenType.Keyword));
			expectedList.Add(new Token("thisString", TokenType.Identifier));
			expectedList.Add(new Token("\"This is a string\"", TokenType.String));
			expectedList.Add(new Token(")", TokenType.RightParen));

			string s = "(assign thisString \"This is a string\")";

			List<Token> actualList = new List<Token>();

			while (s.Any())
			{
				var token = _testScanner.GetNextToken(ref s);
				actualList.Add(token);
				_testScanner.RemoveTokenFromBeginning(ref s, token);
			}

			ValidateExpectedVsActualTokens(expectedList, actualList);
		}

		[TestMethod]
		public void AnalyzeAssignSecondString_Test()
		{
			_testScanner = new Scanner();

			List<Token> expectedList = new List<Token>();
			expectedList.Add(new Token("(", TokenType.LeftParen));
			expectedList.Add(new Token("assign", TokenType.Keyword));
			expectedList.Add(new Token("thisBool", TokenType.Identifier));
			expectedList.Add(new Token("true", TokenType.Boolean));
			expectedList.Add(new Token(")", TokenType.RightParen));

			string s = "(assign thisBool true)";

			List<Token> actualList = new List<Token>();

			while (s.Any())
			{
				var token = _testScanner.GetNextToken(ref s);
				actualList.Add(token);
				_testScanner.RemoveTokenFromBeginning(ref s, token);
			}

			ValidateExpectedVsActualTokens(expectedList, actualList);
		}

		[TestMethod]
		public void AnalyzePlusString_Test()
		{
			_testScanner = new Scanner();

			List<Token> expectedList = new List<Token>();
			expectedList.Add(new Token("(", TokenType.LeftParen));
			expectedList.Add(new Token("+", TokenType.Operator));
			expectedList.Add(new Token("1", TokenType.Integer));
			expectedList.Add(new Token("2", TokenType.Integer));
			expectedList.Add(new Token(")", TokenType.RightParen));

			string s = "(+ 1 2)";

			List<Token> actualList = new List<Token>();

			while (s.Any())
			{
				var token = _testScanner.GetNextToken(ref s);
				actualList.Add(token);
				_testScanner.RemoveTokenFromBeginning(ref s, token);
			}

			ValidateExpectedVsActualTokens(expectedList, actualList);
		}

		[TestMethod]
		public void AnalyzeMinusString_Test()
		{
			_testScanner = new Scanner();

			List<Token> expectedList = new List<Token>();
			expectedList.Add(new Token("(", TokenType.LeftParen));
			expectedList.Add(new Token("-", TokenType.Operator));
			expectedList.Add(new Token("1", TokenType.Integer));
			expectedList.Add(new Token("2", TokenType.Integer));
			expectedList.Add(new Token(")", TokenType.RightParen));

			string s = "(- 1 2)";

			List<Token> actualList = new List<Token>();

			while (s.Any())
			{
				var token = _testScanner.GetNextToken(ref s);
				actualList.Add(token);
				_testScanner.RemoveTokenFromBeginning(ref s, token);
			}

			ValidateExpectedVsActualTokens(expectedList, actualList);
		}

		[TestMethod]
		public void AnalyzeMultiplyString_Test()
		{
			_testScanner = new Scanner();

			List<Token> expectedList = new List<Token>();
			expectedList.Add(new Token("(", TokenType.LeftParen));
			expectedList.Add(new Token("*", TokenType.Operator));
			expectedList.Add(new Token("1", TokenType.Integer));
			expectedList.Add(new Token("2", TokenType.Integer));
			expectedList.Add(new Token(")", TokenType.RightParen));

			string s = "(* 1 2)";

			List<Token> actualList = new List<Token>();

			while (s.Any())
			{
				var token = _testScanner.GetNextToken(ref s);
				actualList.Add(token);
				_testScanner.RemoveTokenFromBeginning(ref s, token);
			}

			ValidateExpectedVsActualTokens(expectedList, actualList);
		}
		[TestMethod]
		public void AnalyzeDivideString_Test()
		{
			_testScanner = new Scanner();

			List<Token> expectedList = new List<Token>();
			expectedList.Add(new Token("(", TokenType.LeftParen));
			expectedList.Add(new Token("/", TokenType.Operator));
			expectedList.Add(new Token("1", TokenType.Integer));
			expectedList.Add(new Token("2", TokenType.Integer));
			expectedList.Add(new Token(")", TokenType.RightParen));

			string s = "(/ 1 2)";

			List<Token> actualList = new List<Token>();

			while (s.Any())
			{
				var token = _testScanner.GetNextToken(ref s);
				actualList.Add(token);
				_testScanner.RemoveTokenFromBeginning(ref s, token);
			}

			ValidateExpectedVsActualTokens(expectedList, actualList);
		}

		[TestMethod]
		public void AnalyzePowerString_Test()
		{
			_testScanner = new Scanner();

			List<Token> expectedList = new List<Token>();
			expectedList.Add(new Token("(", TokenType.LeftParen));
			expectedList.Add(new Token("^", TokenType.Operator));
			expectedList.Add(new Token("1", TokenType.Integer));
			expectedList.Add(new Token("2", TokenType.Integer));
			expectedList.Add(new Token(")", TokenType.RightParen));

			string s = "(^ 1 2)";

			List<Token> actualList = new List<Token>();

			while (s.Any())
			{
				var token = _testScanner.GetNextToken(ref s);
				actualList.Add(token);
				_testScanner.RemoveTokenFromBeginning(ref s, token);
			}

			ValidateExpectedVsActualTokens(expectedList, actualList);
		}

		[TestMethod]
		public void AnalyzeModString_Test()
		{
			_testScanner = new Scanner();

			List<Token> expectedList = new List<Token>();
			expectedList.Add(new Token("(", TokenType.LeftParen));
			expectedList.Add(new Token("%", TokenType.Operator));
			expectedList.Add(new Token("1", TokenType.Integer));
			expectedList.Add(new Token("2", TokenType.Integer));
			expectedList.Add(new Token(")", TokenType.RightParen));

			string s = "(% 1 2)";

			List<Token> actualList = new List<Token>();

			while (s.Any())
			{
				var token = _testScanner.GetNextToken(ref s);
				actualList.Add(token);
				_testScanner.RemoveTokenFromBeginning(ref s, token);
			}

			ValidateExpectedVsActualTokens(expectedList, actualList);
		}

		[TestMethod]
		public void AnalyzeEqualString_Test()
		{
			_testScanner = new Scanner();

			List<Token> expectedList = new List<Token>();
			expectedList.Add(new Token("(", TokenType.LeftParen));
			expectedList.Add(new Token("=", TokenType.Operator));
			expectedList.Add(new Token("1", TokenType.Integer));
			expectedList.Add(new Token("2", TokenType.Integer));
			expectedList.Add(new Token(")", TokenType.RightParen));

			string s = "(= 1 2)";

			List<Token> actualList = new List<Token>();

			while (s.Any())
			{
				var token = _testScanner.GetNextToken(ref s);
				actualList.Add(token);
				_testScanner.RemoveTokenFromBeginning(ref s, token);
			}

			ValidateExpectedVsActualTokens(expectedList, actualList);
		}

		[TestMethod]
		public void AnalyzeLessThanString_Test()
		{
			_testScanner = new Scanner();

			List<Token> expectedList = new List<Token>();
			expectedList.Add(new Token("(", TokenType.LeftParen));
			expectedList.Add(new Token("<", TokenType.Operator));
			expectedList.Add(new Token("1", TokenType.Integer));
			expectedList.Add(new Token("2", TokenType.Integer));
			expectedList.Add(new Token(")", TokenType.RightParen));

			string s = "(< 1 2)";

			List<Token> actualList = new List<Token>();

			while (s.Any())
			{
				var token = _testScanner.GetNextToken(ref s);
				actualList.Add(token);
				_testScanner.RemoveTokenFromBeginning(ref s, token);
			}

			ValidateExpectedVsActualTokens(expectedList, actualList);
		}

		[TestMethod]
		public void AnalyzeIntVariableString_Test()
		{
			_testScanner = new Scanner();

			List<Token> expectedList = new List<Token>();
			expectedList.Add(new Token("(", TokenType.LeftParen));
			expectedList.Add(new Token("thisVar", TokenType.Identifier));
			expectedList.Add(new Token("int", TokenType.Keyword));
			expectedList.Add(new Token(")", TokenType.RightParen));

			string s = "(thisVar int)";

			List<Token> actualList = new List<Token>();

			while (s.Any())
			{
				var token = _testScanner.GetNextToken(ref s);
				actualList.Add(token);
				_testScanner.RemoveTokenFromBeginning(ref s, token);
			}

			ValidateExpectedVsActualTokens(expectedList, actualList);
		}

		[TestMethod]
		public void AnalyzeBoolVariableString_Test()
		{
			_testScanner = new Scanner();

			List<Token> expectedList = new List<Token>();
			expectedList.Add(new Token("(", TokenType.LeftParen));
			expectedList.Add(new Token("thisVar", TokenType.Identifier));
			expectedList.Add(new Token("bool", TokenType.Keyword));
			expectedList.Add(new Token(")", TokenType.RightParen));

			string s = "(thisVar bool)";

			List<Token> actualList = new List<Token>();

			while (s.Any())
			{
				var token = _testScanner.GetNextToken(ref s);
				actualList.Add(token);
				_testScanner.RemoveTokenFromBeginning(ref s, token);
			}

			ValidateExpectedVsActualTokens(expectedList, actualList);
		}

		[TestMethod]
		public void AnalyzeRealVariableString_Test()
		{
			_testScanner = new Scanner();

			List<Token> expectedList = new List<Token>();
			expectedList.Add(new Token("(", TokenType.LeftParen));
			expectedList.Add(new Token("thisVar", TokenType.Identifier));
			expectedList.Add(new Token("real", TokenType.Keyword));
			expectedList.Add(new Token(")", TokenType.RightParen));

			string s = "(thisVar real)";

			List<Token> actualList = new List<Token>();

			while (s.Any())
			{
				var token = _testScanner.GetNextToken(ref s);
				actualList.Add(token);
				_testScanner.RemoveTokenFromBeginning(ref s, token);
			}

			ValidateExpectedVsActualTokens(expectedList, actualList);
		}

		[TestMethod]
		public void AnalyzeStringVariableString_Test()
		{
			_testScanner = new Scanner();

			List<Token> expectedList = new List<Token>();
			expectedList.Add(new Token("(", TokenType.LeftParen));
			expectedList.Add(new Token("thisVar", TokenType.Identifier));
			expectedList.Add(new Token("string", TokenType.Keyword));
			expectedList.Add(new Token(")", TokenType.RightParen));

			string s = "(thisVar string)";

			List<Token> actualList = new List<Token>();

			while (s.Any()) {
				var token = _testScanner.GetNextToken(ref s);
				actualList.Add(token);
				_testScanner.RemoveTokenFromBeginning(ref s, token);
			}

			ValidateExpectedVsActualTokens(expectedList, actualList);
		}

		[TestMethod]
		public void AnalyzeWhileLoopString_Test() 
		{
			_testScanner = new Scanner();

			List<Token> expectedList = new List<Token>();
			expectedList.Add(new Token("(", TokenType.LeftParen));
			expectedList.Add(new Token("while", TokenType.Keyword));
			expectedList.Add(new Token("thisBool", TokenType.Identifier));
			expectedList.Add(new Token("(", TokenType.LeftParen));
			expectedList.Add(new Token("if", TokenType.Keyword));
			expectedList.Add(new Token("thisBool", TokenType.Identifier));
			expectedList.Add(new Token("false", TokenType.Boolean));
			expectedList.Add(new Token(")", TokenType.RightParen));
			expectedList.Add(new Token(")", TokenType.RightParen));

			string s = "(while thisBool (if thisBool false))";

			List<Token> actualList = new List<Token>();

			while (s.Any())
			{
				var token = _testScanner.GetNextToken(ref s);
				actualList.Add(token);
				_testScanner.RemoveTokenFromBeginning(ref s, token);
			}

			ValidateExpectedVsActualTokens(expectedList, actualList);
		}

		[TestMethod]
		public void AnalyzeEscapeQuoteCharacterString_Test()
		{
			_testScanner = new Scanner();
			List<Token> expectedTokens = new List<Token>() {
				new Token("(", TokenType.LeftParen),
				new Token("assign", TokenType.Keyword),
				new Token("thisInt", TokenType.Identifier),
				new Token("\"BOS test \\\" string \\\" EOS\"", TokenType.String),
				new Token(")", TokenType.RightParen)
			};

			List<Token> actualTokens = new List<Token>();

			string inputString = "(assign thisInt \"BOS test \\\" string \\\" EOS\")";
			while (inputString.Any()) {
				var token = _testScanner.GetNextToken(ref inputString);
				actualTokens.Add(token);
				_testScanner.RemoveTokenFromBeginning(ref inputString, token);
			}

			ValidateExpectedVsActualTokens(expectedTokens, actualTokens);
		}
        [TestMethod]
		public void AnalyzeCrazyEscapeCharacterString_Test()
		{
			_testScanner = new Scanner();
			List<Token> expectedTokens = new List<Token>() {
				new Token("(", TokenType.LeftParen),
				new Token("assign", TokenType.Keyword),
				new Token("thisVar", TokenType.Identifier),
				new Token("\"This is \\\"suppose\\\" to be \\\"something\\\" \\n ormal.\\; \"", TokenType.String),
				new Token(")", TokenType.RightParen)
			};

			List<Token> actualTokens = new List<Token>();

            string inputString = "(assign thisVar \"This is \\\"suppose\\\" to be \\\"something\\\" \\n ormal.\\; \")";
			while (inputString.Any()) {
				var token = _testScanner.GetNextToken(ref inputString);
				actualTokens.Add(token);
				_testScanner.RemoveTokenFromBeginning(ref inputString, token);
			}

			ValidateExpectedVsActualTokens(expectedTokens, actualTokens);
		}
	}
}

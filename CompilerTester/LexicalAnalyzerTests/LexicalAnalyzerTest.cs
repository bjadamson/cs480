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
        [TestMethod]
        public void AnalyzeTrueBoolean_Test()
        {
            _testScanner = new Scanner();

            Token expected = new Token("true", TokenType.Boolean);

            string s = "true";
            
            Token actual = _testScanner.ParseToken(ref s);

            Assert.AreEqual(expected.Key, actual.Key);
            Assert.AreEqual(expected.Type, actual.Type);
        }
        
        [TestMethod]
        public void AnalyzeTrueIdentifier_Test()
        {
            _testScanner = new Scanner();

            Token expected = new Token("thisIdentifier", TokenType.Identifier);

            string s = ("thisIdentifier");

            Token actual = _testScanner.ParseToken(ref s);

            Assert.AreEqual(expected.Key, actual.Key);
            Assert.AreEqual(expected.Type, actual.Type);
        }

        [TestMethod]
        public void AnalyzeTrueInteger_Test()
        {
            _testScanner = new Scanner();

            Token expected = new Token("1", TokenType.Integer);

            string s = "1";

            Token actual = _testScanner.ParseToken(ref s);

            Assert.AreEqual(expected.Key, actual.Key);
            Assert.AreEqual(expected.Type, actual.Type);
        }

        [TestMethod]
        public void AnalyzeTrueKeyword_Test()
        {
            _testScanner = new Scanner();

            Token expected = new Token("int", TokenType.Keyword);

            string s = "int";

            Token actual = _testScanner.ParseToken(ref s);

            Assert.AreEqual(expected.Key, actual.Key);
            Assert.AreEqual(expected.Type, actual.Type);
        }

        [TestMethod]
        public void AnalyzeTrueOperator_Test()
        {
            _testScanner = new Scanner();

            Token expected = new Token("+", TokenType.Operator);

            string s = "+";

            Token actual = _testScanner.ParseToken(ref s);

            Assert.AreEqual(expected.Key, actual.Key);
            Assert.AreEqual(expected.Type, actual.Type);
        }

        [TestMethod]
        public void AnalyzeTrueReal_Test()
        {
            _testScanner = new Scanner();

            Token expected = new Token("10.0", TokenType.Real);

            string s = "10.0";

            Token actual = _testScanner.ParseToken(ref s);

            Assert.AreEqual(expected.Key, actual.Key);
            Assert.AreEqual(expected.Type, actual.Type);
        }

        [TestMethod]
        public void AnalyzeTrueString_Test()
        {
            _testScanner = new Scanner();

            Token expected = new Token("\"This is a string\"", TokenType.String);

            string s = "\"This is a string\"";

            Token actual = _testScanner.ParseToken(ref s);

            Assert.AreEqual(expected.Key, actual.Key);
            Assert.AreEqual(expected.Type, actual.Type);
        }
    }
}

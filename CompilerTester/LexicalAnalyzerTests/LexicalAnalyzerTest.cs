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
            Token expected = new Token("true", TokenType.Boolean);

            string s = "true";

            Token actual = _testScanner.ParseToken(s);

            Assert.AreEqual(expected, actual);
        }
    }
}

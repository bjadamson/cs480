using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tokens;
using Compiler.Automatons;
namespace CompilerTester.AutomatonTests
{
    [TestClass]
    public class AutomatonTester
    {
        [TestMethod]
        public void ParseValid_BooleanToken()
        {
            bool expected = true;
            string s = "true";

            bool actual = BooleanAutomaton.Parse(s);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseInvalid_BooleanToken()
        {
            bool expected = false;
            string s = "Not a Boolean";

            bool actual = BooleanAutomaton.Parse(s);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseValid_IdentifierToken()
        {
            bool expected = true;
            string s = "thisIdentifier";

            bool actual = IdentifierAutomaton.Parse(s);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseInvalid_IdentifierToken()
        {
            bool expected = false;
            string s = "1notIdentifier";

            bool actual = IdentifierAutomaton.Parse(s);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseValid_IntegerToken()
        {
            bool expected = true;
            string s = "12";

            bool actual = IntegerAutomaton.Parse(s);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseInvalid_IntegerToken()
        {
            bool expected = false;
            string s = "a";

            bool actual = IntegerAutomaton.Parse(s);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseValid_KeywordAutomaton()
        {
            bool expected = true;
            List<string> list = new List<string>() 
            { 
                "int", "bool", "real", "string", "println", "if", "while", "let", "assign" 
            };

            foreach (string s in list)
            {
                bool actual = KeywordAutomaton.Parse(s);

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void ParseInvalid_KeywordAutomaton()
        {
            bool expected = false;

            string s = "notInt";

            bool actual = KeywordAutomaton.Parse(s);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseValid_OperatorAutomaton()
        {
            bool expected = true;

            List<string> list = new List<string>() 
            { 
                "+", "-", "*", "/", "%", "^", "=", "<"
            };

            foreach (string s in list)
            {
                bool actual = OperatorAutomaton.Parse(s);

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void ParseInvalid_operatorAutomaton()
        {
            bool expected = false;
            string s = "a+";

            bool actual = OperatorAutomaton.Parse(s);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseValid_RealAutomaton()
        {
            bool expected = true;

            List<string> list = new List<string>()
            {
                "+10.", "10.0", "-10."
            };

            foreach (string s in list)
            {
                bool actual = RealAutomaton.Parse(s);

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void ParseEmptyString_RealAutomaton()
        {
            bool expected = false;

            string s = "";
           
            bool actual = RealAutomaton.Parse(s);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseInt_RealAutomaton()
        {
            bool expected = false;

            string s = "10";

            bool actual = RealAutomaton.Parse(s);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseLetter_RealAutomaton()
        {
            bool expected = false;

            string s = "a";

            bool actual = RealAutomaton.Parse(s);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseValid_StringAutomaton()
        {
            bool expected = true;

            List<string> list = new List<string>()
            {
                "\"\"", "\"This is a string\""
            };

            foreach (string s in list)
            {
                bool actual = StringAutomaton.Parse(s);

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void ParseInvalid_StringAutomaton()
        {
            bool expected = false;

            string s = "Not a valid string";

            bool actual = StringAutomaton.Parse(s);

            Assert.AreEqual(expected, actual);
        }
    }
}

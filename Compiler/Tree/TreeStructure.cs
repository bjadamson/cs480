using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokens;

namespace Compiler.Tree {
    public class TreeStructure {
        private List<string> floatingPointOperators = new List<string>() {
            "sin", "tan", "cos", "exp", 
        };

        TreeNode rootNode = null;
        TreeNode sentinel = null;
        bool stringConcat = false;

        public void AddToken(Token token) {
            if (rootNode == null) {
                rootNode = new TreeNode(token);
                sentinel = rootNode;
            }
            else {
                while (sentinel.CorrectNumberChildren()) {
                    sentinel = sentinel.Parent;
                }
                if (token.Type != TokenType.Operator) {
                    Insert(token, sentinel);
                }
                else {
                    InsertOperator(token, sentinel);
                }
            }
        }

        private void InsertOperator(Token token, TreeNode node) {
            Insert(token, node);
            sentinel = node.HasRightChild()
                ? node.RightChild
                : node.LeftChild;
        }

        private void Insert(Token token, TreeNode node) {
            if (node.HasLeftChild()) {
                node.SetRightChild(token);
            }
            else {
                node.SetLeftChild(token);
            }
        }

        private void PrintTreePostTraversalHelper(TreeNode node) {
            if (node == null) {
                return;
            }

            PrintTreePostTraversalHelper(node.LeftChild);
            PrintTreePostTraversalHelper(node.RightChild);

            if (node.Token.Type == TokenType.String) {
                if (node.Parent != null
                    && node.Parent.RightChild != null
                    && node.Parent.Token.Key == "+"
                    && node.Parent.RightChild.Token.Type == TokenType.String) {
                    node.FormatStringConcat();
                    Console.Write("s\" " + node.Token.Key + " " + node.Parent.RightChild.Token.Key);
                    node.Parent.RightChild = null;
                    stringConcat = true;
                }
                else {
                    Console.Write("s\" " + node.Token.Key.Substring(1));
                }
            }
            else if (node.Token.Type == TokenType.Real) {
                Console.Write(node.Token.Key + "e");
            }
            else if (node.Token.Type == TokenType.Operator) {
                if (floatingPointOperators.Contains(node.Token.Key)) {
                    Console.Write("f" + node.Token.Key);
                }
                else if (node.Token.Key == "iff") {
                    Console.Write("invert xor");
                }
                else if (node.Token.Key == "not") {
                    Console.Write("invert");
                }
                else if (stringConcat) {
                    // A string concat has occured and we reset the flag and don't print out the +
                    stringConcat = false;
                }
                else if (node.LeftChild.Token.Type == TokenType.Real && node.RightChild.Token.Type == TokenType.Real) {
                    Console.Write("f" + node.Token.Key);
                }
                else if (node.RightChild == null && node.Token.Key == "-") {
                    if (node.LeftChild.Token.Type == TokenType.Real) {
                        Console.Write("fnegate");
                    }
                    else if (node.LeftChild.Token.Type == TokenType.Integer) {
                        Console.Write("negate");
                    }
                }
                else {
                    Console.Write(node.Token.Key);
                }

            }
            else {
                Console.Write(node.Token.Key);
            }

            Console.Write(" ");
        }

        public void PrintTreePostTraversal() {
            PrintTreePostTraversalHelper(rootNode);
            Console.WriteLine();
        }
    }
}

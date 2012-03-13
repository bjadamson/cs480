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
        int needsConcat = 0;
        string stringConcat = "";

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
                    && node.Parent.Token.Key == "+") {
                        if (node.Parent.RightChild.Token.Type != TokenType.String) {
                            stringConcat = stringConcat == string.Empty ? node.Token.Key.Substring(1, node.Token.Key.Length - 2) :
                                                            stringConcat + " " + node.Token.Key.Substring(1, node.Token.Key.Length - 2);
                            ++needsConcat;
                        }
                        else { 
                            node.FormatStringConcat();
                            Console.Write("s\" {0}{1}{2} {3}", stringConcat, stringConcat == string.Empty ? "" : " ", node.Token.Key, node.Parent.RightChild.Token.Key);
                            node.Parent.RightChild = null;
                            ++needsConcat;
                        }
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
                else if (needsConcat > 0) {
                    // A string concat has occured and we reset the flag and don't print out the +
                    --needsConcat;
                }
                else if (node.RightChild == null && node.Token.Key == "-") {
                    if (node.LeftChild.Token.Type == TokenType.Real) {
                        Console.Write("fnegate");
                    }
                    else if (node.LeftChild.Token.Type == TokenType.Integer) {
                        Console.Write("negate");
                    }
                }
                else if (sentinel.LeftChild.Token.Type == TokenType.Real) {
                    Console.Write("f" + node.Token.Key);
                }
                
                else if (node.Token.Key == "%") {
                    if (node.LeftChild.Token.Type == TokenType.Real && node.RightChild.Token.Type == TokenType.Real) {
                        Console.Write("fmod");
                    }
                    else if (node.LeftChild.Token.Type == TokenType.Real && node.RightChild.Token.Type == TokenType.Real) {
                        Console.Write("mod");
                    }
                }
                else if (node.Token.Key == "println") {
                    if (sentinel.LeftChild.Token.Type == TokenType.String) {
                        Console.Write("type cr");
                    }
                    else if (sentinel.LeftChild.Token.Type == TokenType.Real) {
                        Console.Write("f. cr");
                    }
                    else {
                        Console.Write(". cr");
                    }
                }
                else {
                    Console.Write(node.Token.Key);
                }
            }
            else {
                Console.Write(node.Token.Key);
            }
            if (needsConcat == 0) { 
                Console.Write(" ");
            }
        }

        public void PrintTreePostTraversal() {
            PrintTreePostTraversalHelper(rootNode);
            Console.WriteLine();
        }
    }
}

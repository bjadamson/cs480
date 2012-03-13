using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokens;

namespace Compiler.Tree
{
    public class TreeNode
    {
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }
        public TreeNode Parent { get; set; }

        public Token Token;

        public TreeNode(Token token) {
            Token = token;
        }

        public void SetParent(TreeNode parent) {
            Parent = parent;
        }

        public void SetLeftChild(Token token) {
            LeftChild = new TreeNode(token);
            LeftChild.SetParent(this);
        }

        public void SetRightChild(Token token) {
            RightChild = new TreeNode(token);
            RightChild.SetParent(this);
        }

        public bool HasLeftChild() {
            return LeftChild != null;
        }

        public bool HasRightChild() {
            return RightChild != null;
        }

        public bool CorrectNumberChildren() {
            if (Token.Type == TokenType.Operator 
                && (Token.Key == "not" || Token.Key == "println")) {
                return HasLeftChild();
            }
            else {
                return HasLeftChild() && HasRightChild();
            }
        }

        public void FormatStringConcat() {
            Token.Key = Token.Key.Substring(1, Token.Key.Length - 2);
            Parent.RightChild.Token.Key = Parent.RightChild.Token.Key.Substring(1, Parent.RightChild.Token.Key.Length - 1);
        }
    }
}

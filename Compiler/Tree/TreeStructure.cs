using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokens;

namespace Compiler.Tree
{
	public class TreeStructure
	{
		TreeNode rootNode = null;
		TreeNode sentinel = null;

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

				Console.Write("s\" " + node.Token.Key.Substring(1));
			}
			else if (node.Token.Type == TokenType.Real) {
				Console.Write(node.Token.Key + "e");
			}
			else{
				Console.Write(node.Token.Key);
			}
		}

		public void PrintTreePostTraversal() {
			PrintTreePostTraversalHelper(rootNode);
			Console.WriteLine();
		}
	}
}

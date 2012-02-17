using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokens;
using System.IO;
using Compiler.extensions;
using Compiler.Automatons;
using Compiler.LexicalAnalyzer;
using Compiler.Parser;

namespace MilestoneTwo
{
	internal class Program
	{
		/// <summary>
		/// Entry-point for the application
		/// </summary>
		/// <param name="args">command arguments</param>
		static void Main(string[] args)
		{
			Parser parser = new Parser();

			if (args.Length == 0)
			{
				Console.WriteLine("Please specify input file for lexical analysis. Usage: make run ARG=\"../test.txt\"");
				return;
			}

			try {
				parser.ParseFile(args.First());
				parser.PrintTokens();
			}
			catch (InvalidDataException ide) {
				Console.WriteLine(ide.Message);
				Console.ReadLine();
			}
		}
	}
}


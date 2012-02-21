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
		static void Main(string[] args) {
			foreach (var file in string.Join(" ", args).Split(' ')) {
				Parser parser = new Parser();

				Console.WriteLine("Processing File {0}", file);
				bool expectPass = file.Contains("pass", StringComparison.OrdinalIgnoreCase);

				if (args.Length == 0) {
					Console.WriteLine("Please specify input file for lexical analysis. Usage: make run ARG=\"../file1.txt ../file2.txt\"");
					return;
				}

				try {
					parser.ParseFile(file);
					parser.PrintTokens();
				}
				catch (InvalidDataException ide) {
				
					if(expectPass){
						Console.WriteLine("Expected File to Pass but it failed! {0}", file); 	
					}
					else{
						Console.WriteLine("Expected File to Fail and it did! {0}", file);
					}

					Console.WriteLine(ide.Message + "\nParse Failed!!\n");

				}
			}
			// only on windows do we need to read a line
			if (Environment.OSVersion.ToString().Contains("Windows")) {
				Console.ReadLine();
			}
		}
	}
}


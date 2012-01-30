#this makefile will make all the necessary files to make the project work correctly.

PKG_CONFIG_PATH:=/nfs/stak/students/a/adamsben/mono/lib/pkgconfig/

all: 
	/nfs/stak/students/a/adamsben/mono/bin/dmcs ./Program.cs ./Tokens/expr.cs ./Tokens/constant.cs ./Tokens/bool.cs ./Tokens/int.cs ./Tokens/string.cs ./Tokens/real.cs ./Tokens/stmt.cs ./Tokens/if.cs ./Tokens/while.cs ./Tokens/exprlist.cs ./Tokens/atom.cs ./Tokens/variablelist.cs ./Tokens/let.cs ./Tokens/print.cs ./Tokens/assign.cs ./Tokens/token.cs ./Tokens/operator.cs

run:
	/nfs/stak/students/a/adamsben/mono/bin/mono ./Program.exe

clean:
	rm -f *.exe

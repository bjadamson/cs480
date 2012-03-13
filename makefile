#this makefile will make all the necessary files to make the project work correctly.

PKG_CONFIG_PATH:=/nfs/stak/students/a/adamsben/mono/lib/pkgconfig/
PATH=../tests/milestone4/
ARG1=$(PATH)test1.txt
ARG2=$(PATH)test2.txt
ARG3=$(PATH)test3.txt
ARG4=$(PATH)test4.txt

stutest: 
	/nfs/stak/students/a/adamsben/mono/bin/dmcs ./Compiler/Program.cs ./Compiler/Tokens/*.cs ./Compiler/extensions/*.cs ./Compiler/Automatons/*.cs ./Compiler/LexicalAnalyzer/*.cs ./Compiler/Parser/*.cs ./Compiler/Tree/*.cs
	/nfs/stak/students/a/adamsben/mono/bin/mono ./Compiler/Program.exe $(ARG1) $(ARG2) $(ARG3) $(ARG4) > stutest.out

proftest:
	/nfs/stak/students/a/adamsben/mono/bin/dmcs ./Compiler/Program.cs ./Compiler/Tokens/*.cs ./Compiler/extensions/*.cs ./Compiler/Automatons/*.cs ./Compiler/LexicalAnalyzer/*.cs ./Compiler/Parser/*.cs ./Compiler/Tree/*.cs
	/nfs/stak/students/a/adamsben/mono/bin/mono ./Compiler/Program.exe $(ARG) > proftest.out
clean:
	rm -f *.exe
	rm -f stutest.out
	rm -f proftest.out

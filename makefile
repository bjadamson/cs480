#this makefile will make all the necessary files to make the project work correctly.

PKG_CONFIG_PATH:=/nfs/stak/students/a/adamsben/mono/lib/pkgconfig/
ARG1=../test1[FAIL].txt
ARG2=../websiteTest1[PASS].txt
ARG3=../websiteTest2[PASS].txt
ARG4=../websiteTest3[PASS].txt

stutest: 
	/nfs/stak/students/a/adamsben/mono/bin/dmcs ./Compiler/Program.cs ./Compiler/Tokens/*.cs ./Compiler/extensions/*.cs ./Compiler/Automatons/*.cs ./Compiler/LexicalAnalyzer/*.cs ./Compiler/Parser/*.cs
	/nfs/stak/students/a/adamsben/mono/bin/mono ./Compiler/Program.exe $(ARG1) $(ARG2) $(ARG3) $(ARG4) > stutest.out

proftest:
	/nfs/stak/students/a/adamsben/mono/bin/dmcs ./Compiler/Program.cs ./Compiler/Tokens/*.cs ./Compiler/extensions/*.cs ./Compiler/Automatons/*.cs ./Compiler/LexicalAnalyzer/*.cs ./Compiler/Parser/*.cs
	/nfs/stak/students/a/adamsben/mono/bin/mono ./Compiler/Program.exe $(ARG) > proftest.out
clean:
	rm -f *.exe

#this makefile will make all the necessary files to make the project work correctly.

PKG_CONFIG_PATH:=/nfs/stak/students/a/adamsben/mono/lib/pkgconfig/
PATH=../tests/milestone2/
ARG1=$(PATH)test0.txt
ARG2=$(PATH)test1.txt
ARG3=$(PATH)test2.txt
ARG4=$(PATH)test3.txt
ARG5=$(PATH)test4.txt
ARG6=$(PATH)test5.txt
ARG7=$(PATH)test6.txt
ARG8=$(PATH)test7.txt
ARG9=$(PATH)test8.txt
ARG10=$(PATH)test9.txt
ARG11=$(PATH)test10.txt
ARG12=$(PATH)test11.txt
ARG13=$(PATH)test12.txt
ARG14=$(PATH)test13.txt
ARG15=$(PATH)test14.txt

stutest: 
	/nfs/stak/students/a/adamsben/mono/bin/dmcs ./Compiler/Program.cs ./Compiler/Tokens/*.cs ./Compiler/extensions/*.cs ./Compiler/Automatons/*.cs ./Compiler/LexicalAnalyzer/*.cs ./Compiler/Parser/*.cs
	/nfs/stak/students/a/adamsben/mono/bin/mono ./Compiler/Program.exe $(ARG1) $(ARG2) $(ARG3) $(ARG4) $(ARG5) $(ARG6) $(ARG7) $(ARG8) $(ARG9) $(ARG10) $(ARG11) $(ARG12) $(ARG13) $(ARG14) > stutest.out

proftest:
	/nfs/stak/students/a/adamsben/mono/bin/dmcs ./Compiler/Program.cs ./Compiler/Tokens/*.cs ./Compiler/extensions/*.cs ./Compiler/Automatons/*.cs ./Compiler/LexicalAnalyzer/*.cs ./Compiler/Parser/*.cs
	/nfs/stak/students/a/adamsben/mono/bin/mono ./Compiler/Program.exe $(ARG) > proftest.out
clean:
	rm -f *.exe
	rm -f stutest.out
	rm -f proftest.out

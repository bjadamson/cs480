#this makefile will make all the necessary files to make the project work correctly.

PKG_CONFIG_PATH:=/nfs/stak/students/a/adamsben/mono/lib/pkgconfig/

all: 
	/nfs/stak/students/a/adamsben/mono/bin/dmcs ./Test/Program.cs

run:
	/nfs/stak/students/a/adamsben/mono/bin/mono ./Test/Program.exe

clean:
	rm -f *.exe

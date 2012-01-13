#this makefile will make all the necessary files to make the project work correctly.

all: 
	/scratch/adamsben/bin/dmcs ./Test/Program.cs

run:
	/scratch/adamsben/bin/mono ./Test/Program.exe

clean:
	rm -f *.exe

#--------------------------------------------
# INSTRUCTION
# Quoted strings are to be filled in by student
#
CCC = gforth
CCFLAGS = -e bye
OBJS =
SOURCE = test
RUNFLAGS =

$(OBJS): $(SOURCE)
	$(CCC) $(CCFLAGS) -c $(SOURCE)

compiler: $(OBJS)
	$(CCC) $(CCFLAGS) -o compiler $(OBJS)

clean:
	rm -f ".o files" core ".exe/class files" "outputs"
	ls

stutest.out: compiler
	cat stutest1.in
	-compiler $(RUNFLAGS) stutest1.in > stutest1.out
	cat stutest1.out

# Notice the next line. The `-' says to ignore the return code. This
# is a way to have multiple tests of errors that cause non-zero return
# codes.
	cat stutest2.in
	-compiler stutest2.in > stutest2.out
	cat stutest2.out

proftest.out: compiler
	cat $(PROFTEST)
	compiler $(PROFTEST) > proftest.out
	cat proftest.out

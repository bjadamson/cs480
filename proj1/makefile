clean:
	rm -f ".o files" core ".exe/class files" "outputs"
	ls

stutest.out:
	cat ex1 > stutest.out
	cout ex2 >> stutest.out
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

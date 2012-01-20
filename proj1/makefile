clean:
	rm -f "stutest.out"

stutest.out:
	chmod 770 ./stutest.sh
	./stutest.sh

# Notice the next line. The `-' says to ignore the return code. This
# is a way to have multiple tests of errors that cause non-zero return
# codes.
	#cat stutest2.in
	#-compiler stutest2.in > stutest2.out
	#cat stutest2.out

proftest.out: compiler
	cat $(PROFTEST)
	compiler $(PROFTEST) > proftest.out
	cat proftest.out

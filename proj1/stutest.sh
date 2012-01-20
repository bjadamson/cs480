#!/bin/bash
# Author: Benjamin Adamson
# Class : CS480
# Purpose: Program to produce stutest.out for assignent 1

echo > stutest.out
echo "Exercise 1 (printf('Hello World\n');)" >> stutest.out
gforth ex1 >> stutest.out
echo >> stutest.out

echo "Exercise 2 (10 + 7 - 3 * 5 / 12 )" >> stutest.out
gforth ex2 >> stutest.out
echo >> stutest.out

echo "Exercise 3 (10.0 + 7.0 - 3.0 * 5.0 / 12.0)" >> stutest.out
gforth ex3 >> stutest.out
echo >> stutest.out

echo "Exercise 4 (10.0e0 + 7.0e0 - 3.0e0 * 5.0e0 / 12.0e0)" >> stutest.out
gforth ex4 >> stutest.out
echo >> stutest.out

echo "Exercise 5 (10 + 7.0e0 - 3.0e0 * 5 / 12)" >> stutest.out
gforth ex5 >> stutest.out
echo >> stutest.out

echo "Exercise 6 (y = 10; x = 7.0e0; y + x - 3.0e0 * 5 / 12 )" >> stutest.out
gforth ex6 >> stutest.out
echo >> stutest.out

echo "Exercise 7 (if 5 < 3 then 7 else 2)" >> stutest.out
gforth ex7 >> stutest.out
echo >> stutest.out

echo "Exercise 8 (if 5 > 3 then 7 else 2)" >> stutest.out
gforth ex8 >> stutest.out
echo >> stutest.out

echo "Exercise 9 (for ( i = 0; i <= 5; i++ ) printf("%d ", i);)" >> stutest.out
gforth ex9 >> stutest.out
echo >> stutest.out

echo "Exercise 10 (double convertint(int x) { return ((double)x); })" >> stutest.out
echo "Test one, converting 0 (edge case), expected output: 0." >> stutest.out
echo "Actual result:" >> stutest.out
gforth ex10 -e "0 convertint f. CR BYE" >> stutest.out
echo "Test two, converting 1 (edge case), expected output: 1." >> stutest.out
echo "Actual result:" >> stutest.out
gforth ex10 -e "1 convertint f. CR BYE" >> stutest.out
echo "Test three, converting 13, expected output: 13." >> stutest.out
echo "Actual result:" >> stutest.out
gforth ex10 -e "13 convertint f. CR BYE" >> stutest.out
echo >> stutest.out

echo "Exercise 11 (int fact(int i) { if (i <= 0 ) return 1; else return i*fact(i-1); })" >> stutest.out
echo "Test one, calling factorial on 0 (edge case), expected output: 1" >> stutest.out
echo "Actual result:" >> stutest.out
gforth ex11 -e "0 fact . CR BYE" >> stutest.out
echo "Test two, calling factorial on 1 (edge case), exptected output: 1" >> stutest.out
echo "Actual result:" >> stutest.out
gforth ex11 -e "1 fact . CR BYE" >> stutest.out
echo "Test three, calling factorial on 11, expected output: 39916800." >> stutest.out
echo "Actual result:" >> stutest.out
gforth ex11 -e "11 fact . CR BYE" >> stutest.out
echo >> stutest.out

echo "Exercise 12 (int fib(int i) { if(i == 0) return 0; else if(i == 1) return 1; else return fib(i-1) + fib(i-2); })" >> stutest.out
echo "Test one, calling fib on 0 (edge case), expected output: 0" >> stutest.out
echo "Actual result:" >> stutest.out
gforth ex12 -e "0 fib . CR BYE"  >> stutest.out
echo "Test two, calling fib on 1 (edge case), expected output: 1" >> stutest.out
echo "Actual result:" >> stutest.out
gforth ex12 -e "1 fib . CR BYE"  >> stutest.out
echo "Test three, calling fib on 8, expected output: 21" >> stutest.out
echo "Actual result:" >> stutest.out
gforth ex12 -e "8 fib . CR BYE"  >> stutest.out
echo >> stutest.out

chmod 770 stutest.out

#!/bin/bash
# Author: Benjamin Adamson
# Class : CS480
# Purpose: Program to produce stutest.out for assignent 1

echo > stutest.out
echo "Exercise 1 (printf("Hello World\n");)" >> stutest.out
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
gforth ex10 -e "17 convertint d.s CR BYE" >> stutest.out
echo >> stutest.out

echo "Exercise 11 (int fact(int i) { if (i <= 0 ) return 1; else return i*fact(i-1); })" >> stutest.out
gforth ex11 -e "5 fact . CR BYE" >> stutest.out
echo >> stutest.out

echo "Exercise 12 (int fib(int i) { if(i == 0) return 0; else if(i == 1) return 1; else return fib(i-1) + fib(i-2); })" >> stutest.out
gforth ex12 -e "9 fib . CR BYE"  >> stutest.out
echo >> stutest.out

# Consecutive occurences using given odds

```cmd
Inputs: (1) odds of A happening
        (2) number of coinflips to be done with calculated odds
```
```cmd
Output: Number of times that both odds have consecutively happened.
```

## Example

User input of 73 will set the odds of A to 73% and B to 27%.
Second user input will choose 1,000,000 test to be done.

```cmd
What are the odds of A happening? (ex. 20%, enter 20)
73
Odds of B happening have been set to 27%
How many tests would you like to run?
1000000

////////////////////////////////////
Consecutive A wins along with length
////////////////////////////////////
Number of consec. wins for A at length 1: 53297
Number of consec. wins for A at length 2: 38463
Number of consec. wins for A at length 3: 28650
Number of consec. wins for A at length 4: 20637
Number of consec. wins for A at length 5: 15278
Number of consec. wins for A at length 6: 11088
Number of consec. wins for A at length 7: 7988
Number of consec. wins for A at length 8: 5772
Number of consec. wins for A at length 9: 4341
Number of consec. wins for A at length 10: 3094
Number of consec. wins for A at length 11: 2284
Number of consec. wins for A at length 12: 1586
Number of consec. wins for A at length 13: 1207
Number of consec. wins for A at length 14: 950
Number of consec. wins for A at length 15: 647
Number of consec. wins for A at length 16: 488
Number of consec. wins for A at length 17: 310
Number of consec. wins for A at length 18: 264
Number of consec. wins for A at length 19: 190
Number of consec. wins for A at length 20: 145
Number of consec. wins for A at length 21: 101
Number of consec. wins for A at length 22: 72
Number of consec. wins for A at length 23: 54
Number of consec. wins for A at length 24: 38
Number of consec. wins for A at length 25: 28
Number of consec. wins for A at length 26: 20
Number of consec. wins for A at length 27: 15
Number of consec. wins for A at length 28: 8
Number of consec. wins for A at length 29: 8
Number of consec. wins for A at length 30: 7
Number of consec. wins for A at length 31: 6
Number of consec. wins for A at length 32: 1
Number of consec. wins for A at length 33: 2
Number of consec. wins for A at length 34: 2
Number of consec. wins for A at length 35: 1
Number of consec. wins for A at length 36: 1
Number of consec. wins for A at length 37: 1
Summation of wins = 729542

////////////////////////////////////
Consecutive B wins along with length
////////////////////////////////////
Number of consec. wins for B at length 1: 143618
Number of consec. wins for B at length 2: 38964
Number of consec. wins for B at length 3: 10493
Number of consec. wins for B at length 4: 2870
Number of consec. wins for B at length 5: 779
Number of consec. wins for B at length 6: 221
Number of consec. wins for B at length 7: 81
Number of consec. wins for B at length 8: 10
Number of consec. wins for B at length 9: 5
Number of consec. wins for B at length 10: 4
Summation of wins = 270458

1000000 rolls were done.
A has won 729542 times, and B has won 270458 times.

C:\Users\snowy\OneDrive\Desktop\ConsecutiveRNG\ConsecutiveRNG\bin\Debug\netcoreapp3.1\ConsecutiveRNG.exe (process 7028) exited with code 0.
To automatically close the console when debugging stops, enable Tools->Options->Debugging->Automatically close the console when debugging stops.
Press any key to close this window . . .
```

using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsecutiveRNG
{
    public class CoinFlip
    {
        public static void Main()
        {
            int A = 0, B = 0, counter = 0, tracker = 0;
            int randomInt;
            char currentOdd = new char();

            decimal[] collection = DesiredOdds();
            List<char> consecutiveChars = new List<char>();
            List<oddsDataDto> consecutiveRolls = new List<oddsDataDto>();
            Random rnd = new Random();


            while (collection[0] < 1 || collection[0] > 100)
            {
                Console.WriteLine("Invalid entry for A. Please re-enter the odds.");
                collection = DesiredOdds();
            }

            while (counter < collection[2])
            {
                randomInt = rnd.Next(1, 101);
                // ex. A odds are 20%, therefore if chosen value is 1-20, A wins.
                // Hence B odds will be 80%, therefore if chosen value is 21-100, B wins.
                if (randomInt <= collection[0])
                {
                    A++;

                    if (counter == 0)
                    {
                        currentOdd = 'A';
                        tracker = 1;

                    }
                    else if (currentOdd == 'A')
                    {
                        tracker++;

                    }
                    else
                    {
                        consecutiveRolls.Add(new oddsDataDto
                        {
                            consecutive = tracker,
                            charName = currentOdd
                        });
                        currentOdd = 'A';
                        tracker = 1;
                    }

                    if (counter+1 == collection[2])
                    {
                        consecutiveRolls.Add(new oddsDataDto
                        {
                            consecutive = tracker,
                            charName = currentOdd
                        });
                    }

                }
                else if (randomInt > collection[0])
                {
                    B++;

                    if (counter == 0)
                    {
                        currentOdd = 'B';
                        tracker = 1;

                    }
                    else if (currentOdd == 'B')
                    {
                        tracker++;

                    }
                    else
                    {
                        consecutiveRolls.Add(new oddsDataDto
                        {
                            consecutive = tracker,
                            charName = currentOdd
                        });
                        currentOdd = 'B';
                        tracker = 1;
                    }

                    // This was causing an off by 1 error since we would not be storing the current object on final rolls.
                    if (counter + 1 == collection[2])
                    {
                        consecutiveRolls.Add(new oddsDataDto
                        {
                            consecutive = tracker,
                            charName = currentOdd
                        });
                    }
                }
                counter++;
            }

            int currMaxConsec = consecutiveRolls.Max(x => x.consecutive);
            int[,] finalResults = new int[currMaxConsec + 1, 2];

            for (int i = 0; i < currMaxConsec + 1; i++)
            {
                int aCount = consecutiveRolls.Where(x => x.consecutive == i && x.charName == 'A').Count();
                int bCount = consecutiveRolls.Where(x => x.consecutive == i && x.charName == 'B').Count();

                // Using index 0 for A values and index 1 for B values
                finalResults[i, 0] = aCount;
                finalResults[i, 1] = bCount;
            }

            Console.WriteLine("\n//////////////////////////////////// \nConsecutive A wins along with length \n////////////////////////////////////\n");
            int summation = 0;
            for (int i = 0; i < currMaxConsec + 1; i++)
            {
                if (finalResults[i, 0] != 0)
                {
                    Console.WriteLine("Number of consec. wins for A at length " + i + ": " + finalResults[i, 0]);
                    summation += finalResults[i, 0] * i;
                }
            }
            Console.WriteLine("Summation of wins = " + summation);

            Console.WriteLine("\n//////////////////////////////////// \nConsecutive B wins along with length \n////////////////////////////////////\n");
            summation = 0;
            for (int i = 0; i < currMaxConsec + 1; i++)
            {
                if (finalResults[i, 1] != 0)
                {
                    Console.WriteLine("Number of consec. wins for B at length " + i + ": " + finalResults[i, 1]);
                    summation += finalResults[i, 1] * i;
                }
            }
            Console.WriteLine("Summation of wins = " + summation);


            Console.WriteLine(collection[2] + " rolls were done.");
            Console.WriteLine("A has won " + A + " times, and B has won " + B + " times.");
        }

        public static decimal[] DesiredOdds()
        {
            // Index 0 will be for A, index 1 will be for B, index 2 will be for number of rolls
            decimal[] desiredOdds = new decimal[3];
            string userInput;

            Console.WriteLine("What are the odds of A happening? (ex. 20%, enter 20)");
            userInput = Console.ReadLine();
            desiredOdds[0] = Decimal.Parse(userInput);

            Console.WriteLine("Odds of B happening have been set to " + (100 - desiredOdds[0]) + "%");
            //userInput = Console.ReadLine();
            desiredOdds[1] = 100 - desiredOdds[0];

            Console.WriteLine("How many tests would you like to run? ");
            userInput = Console.ReadLine();
            desiredOdds[2] = Decimal.Parse(userInput);

            return desiredOdds;
        }

        public class oddsDataDto
        {
            public int consecutive;
            public char charName;
        }
    }
}

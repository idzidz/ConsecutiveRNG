using System;
using System.Linq;
using System.Collections.Generic;

public class CoinFlip
{
	public static void Main()
	{
        int A=0, B=0, counter=0, tracker=0;
        int randomInt;

        // This will have the first occurrence of 'A' or 'B' have a single point at chain length of 0
        // Will be ignoring chain lengths of 0 anyway, so my bad code is ok here.
        char currentOdd = 'Z';

        decimal[] collection = DesiredOdds();
        List<char> consecutiveChars = new List<char>();
        List<oddsDataDto> consecutiveRolls = new List<oddsDataDto>();
        Random rnd = new Random();


        while(collection[0] < 1 || collection[0] > 100)
        {
            Console.WriteLine("Invalid entry for A. Please re-enter the odds.");
            collection = DesiredOdds();
        }

        while(counter < collection[2])
        {
            randomInt = rnd.Next(1, 101);
            if (randomInt <= collection[0])
            {
                //Console.WriteLine("A wins with roll " + randomInt);
                A++;
                if (currentOdd == 'A') { tracker++; }
                else
                {
                    currentOdd = 'A';
                    consecutiveRolls.Add(new oddsDataDto
                    {
                        consecutive = tracker,
                        charName = 'B'
                    });
                    tracker = 1;
                }

            }else if(randomInt > collection[1])
            {
                //Console.WriteLine("B wins with roll " + randomInt);
                B++;
                if (currentOdd == 'B') { tracker++; }
                else
                {
                    currentOdd = 'B';
                    consecutiveRolls.Add(new oddsDataDto
                    {
                        consecutive = tracker,
                        charName = 'A'
                    });
                    tracker = 1;
                }
            }
            counter++;
        }

        int currMaxConsec = consecutiveRolls.Max(x => x.consecutive);
        var whichIsIt = consecutiveRolls.Where(x => x.consecutive == currMaxConsec).ToList().FirstOrDefault();
        int[,] finalResults = new int[currMaxConsec+1, 2];

        Console.WriteLine("Current max consec is: " + currMaxConsec);
        Console.WriteLine("One of the examples are: " + whichIsIt.charName + ":" + whichIsIt.consecutive);
        //Console.WriteLine("The size of our data collection is: " + consecutiveRolls.Count());

        for (int i=1; i<=currMaxConsec; i++)
        {
            //var temp = consecutiveRolls.Where(x => x.consecutive == i).Select(x => x.charName).ToList();
            //int aCount = temp.Where(x => x.Equals('A')).Count(); // == null ? 0 : temp.Where(x => x.Equals('A')).Count();
            //int bCount = temp.Where(x => x.Equals('B')).Count(); // == null ? 0 : temp.Where(x => x.Equals('B')).Count();

            int aCount = consecutiveRolls.Where(x => x.consecutive == i && x.charName == 'A').Count();
            int bCount = consecutiveRolls.Where(x => x.consecutive == i && x.charName == 'B').Count();

            // Using index 0 for A values and index 1 for B values
            finalResults[i, 0] = aCount;
            finalResults[i, 1] = bCount;

            Console.WriteLine("Consecutive times A has occured with length " + i + ": " + finalResults[i, 0]);
            Console.WriteLine("Consecutive times B has occured with length " + i + ": " + finalResults[i, 1]);
        }

        //int i = 1;
        //while (true)
        //{
        //    //consecutiveChars.Add(consecutiveRolls.Where(x => x.consecutive == i).Select(x => x.charName));
            

        //    //consecutiveChars.Add(temp);
        //}

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
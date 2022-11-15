using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Number Tracker");
            //create an empty list of numbers
            var numbers = new List<int>();

            //controls if we are still running our loop asking for more numbers
            var isRunning = true;

            //while we are running
            while (isRunning)
            {
                //show the list of numbers
                Console.WriteLine("--------------------");

                foreach (var number in numbers)
                {
                    Console.WriteLine(number);
                }
                Console.WriteLine($"Our list has: {numbers.Count} entries");
                Console.WriteLine("--------------------");

                //Ask for a new number or the word quit to end
                Console.WriteLine("Enter a number or type 'quit' to end");
                var input = Console.ReadLine().ToLower();
                if (input == "quit")
                {
                    isRunning = false;
                }
                else
                {
                    //add the number to the list
                    var number = int.Parse(input);
                    numbers.Add(number);
                }
            }
        }
    }
}

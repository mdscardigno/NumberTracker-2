using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;//third party library outside of Microsoft

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
            }//end of while
            //the fileWriter uses the file "numbers.csv"
            var fileWriter = new StreamWriter("numbers.csv");
            //send some data to the stream
            //CsvWriter uses the fileWriter 
            var cvsWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);
            //write some records. please write some records and what I want you to write is my list of numbers.
            cvsWriter.WriteRecords(numbers);
            //close the fileWriter
            fileWriter.Close();//like a waterfall
        }
    }
}

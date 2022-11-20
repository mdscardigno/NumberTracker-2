using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;//third party library outside of Microsoft
using CsvHelper.Configuration;

namespace NumberTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Number Tracker!");
            var numbers = new List<int>();
            if (File.Exists("numbers.csv"))
            {
                // //Generic reader that can be a StreamReader or a StringReader
                // TextReader reader;
                // //If the file exists
                // if (File.Exists("numbers.csv"))
                // {
                //     //assign a StreamReader to the read from the file
                //     reader = new StreamReader("numbers.csv");
                // }
                // else
                // {
                //     //Assign a StringReader to read from an empty string
                //     reader = new StringReader("");
                // }

                //create a file reader to read from numbers.csv
                var fileReader = new StreamReader("numbers.csv");

                //create a configuration that indicates this csv file has no header
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    //tell the header not to interpret the first row as a header since it is just the first number
                    HasHeaderRecord = false
                };

                // var csvReader = new CsvReader(fileReader, config); rather than reading from fileReader we user reader instead
                var csvReader = new CsvReader(fileReader, config);
                // var csvReader = new CsvReader(reader, config);//if no file exists
                //what kind of data to read it as <int> and that we want it back as a list. Therefore, GetRecords is gonna give us a list of ints
                //creates a list of ints but from *READING* the data from the file
                numbers = csvReader.GetRecords<int>().ToList();//when trying the TextReader this uncommented out
            }
            //create an empty list of numbers
            // var numbers = new List<int>();

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

using System;
using System.Collections.Generic;


namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Blake's Grade Book");
            book.GradeAdded += OnGradeAdded;

            EnterGrade(book);

            var stats = book.GetStats();

            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average}");
        }

        private static void EnterGrade(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a Grade or q to Quit.");
                var input = Console.ReadLine();
                if (input == "q")
                    break;

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // Console.WriteLine("@@@");
                }
            };
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added.");
        }

    }
}

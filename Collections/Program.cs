using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] daysOfTheWeek = {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

           Console.WriteLine("Which day do you want to display");
           int iDay = int.Parse(Console.ReadLine());

           string chosenDay = daysOfTheWeek[iDay-1];
           Console.WriteLine($"That day of the week is {chosenDay}");
        }
    }
}

using System;
using System.Collections.Generic;

namespace GradeBook
{
     public class Book
     {
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        } 

        public void AddGrade(double grade)
        {
           if(grade >= 0 && grade <= 100)
           {
               grades.Add(grade);
           }
           else
           {
              throw new ArgumentException($"Invalid {nameof(grade)}");
           }
        }

        public Stats GetStats()
        {   
            var result = new Stats();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach (var grade in grades)
            {
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                result.Average += grade;
            }
            result.Average /= grades.Count;

            return result;
        }
        private List<double> grades;
        public string Name;

     }
}
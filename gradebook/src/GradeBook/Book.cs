using System;
using System.Collections.Generic;

namespace GradeBook
{
     public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NameObject
    {
        public NameObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    
    
    public interface IBook 
    {
        void AddGrade(double grade);
        // static GetStats();
        string Name {get;}
        event GradeAddedDelegate GradeAdded; 

    }

    public class DiskBook : Book, IBook
    {
        public DiskBook(string name) : base(name)
        {
        }
        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            var writer = File.AppendText($"{Name}.txt");
            writer.WriteLine(grade);
        }
        public override Stats GetStats()
        {
            throw new NotImplementedException();
        }
    }
    public abstract class Book : NameObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Stats GetStats();
    }

     public class InMemBook : Book
     {
       //Constructor 
        public InMemBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        } 

        public void AddGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;

            }
        }

        // overloaded class method
        public override void AddGrade(double grade)
        {
           if(grade >= 0 && grade <= 100)
           {
               grades.Add(grade);
               if(GradeAdded != null)
               {
                   GradeAdded(this, new EventArgs());
               }
           }
           else
           {
              throw new ArgumentException($"Invalid {nameof(grade)}");
           }
        }

        public override Stats GetStats()
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

        public override event GradeAddedDelegate GradeAdded;
        private List<double> grades;
        
        // Class Property
        // public string Name
        // {
        //     get 
        //     {
        //         return name;
        //     }
        //     set
        //     {
        //         if(!String.IsNullOrEmpty(value))
        //         {
        //             name = value;
        //         }
                
        //     }
        // }
        // Auto Property
        // public string Name
        // {
        //     get; 
        //     set;
        // }

        //field
        // private string Name; 

        public const string CATEGORY = "Science";


     }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_test.task_3
{
    internal class GradeManagement
    {
        private List<int> grades = new List<int>();

        public void AddGrade(int grade)
        {
            if (grade < 0 || grade > 100)
            {
                Console.WriteLine("Invalid grade! Please enter a grade between 0 and 100.");
                return;
            }

            grades.Add(grade);
            Console.WriteLine($"Grade {grade} added successfully.");
        }

        public void DisplayGrades()
        {
            if (grades.Count == 0)
            {
                Console.WriteLine("No grades available.");
                return;
            }

            Console.WriteLine("\n--- Student Grades ---");
            Console.WriteLine(string.Join(", ", grades));
        }

        public double CalculateAverage()
        {
            if (grades.Count == 0) return 0;
            return grades.Average();
        }

        public int GetHighestGrade()
        {
            if (grades.Count == 0) return 0;
            return grades.Max();
        }

        public int GetLowestGrade()
        {
            if (grades.Count == 0) return 0;
            return grades.Min();
        }

        public int GetPassCount()
        {
            return grades.Count(g => g >= 50);
        }

        public int GetFailCount()
        {
            return grades.Count(g => g < 50);
        }

        public void DisplayStatistics()
        {
            if (grades.Count == 0)
            {
                Console.WriteLine("No grades available to display statistics.");
                return;
            }

            Console.WriteLine("\n--- Class Statistics ---");
            Console.WriteLine($"Average Grade: {CalculateAverage():F2}");
            Console.WriteLine($"Highest Grade: {GetHighestGrade()}");
            Console.WriteLine($"Lowest Grade: {GetLowestGrade()}");
            Console.WriteLine($"Students Passed: {GetPassCount()}");
            Console.WriteLine($"Students Failed: {GetFailCount()}");
        }
    }

    class Program
    {
        static void Main()
        {
            GradeManagement gradeManager = new GradeManagement();

            while (true)
            {
                Console.WriteLine("\n--- Grade Management System ---");
                Console.WriteLine("1. Add Grade");
                Console.WriteLine("2. Display All Grades");
                Console.WriteLine("3. Display Class Statistics");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter grade (0-100): ");
                        if (int.TryParse(Console.ReadLine(), out int grade))
                        {
                            gradeManager.AddGrade(grade);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input! Please enter a numeric grade.");
                        }
                        break;

                    case "2":
                        gradeManager.DisplayGrades();
                        break;

                    case "3":
                        gradeManager.DisplayStatistics();
                        break;

                    case "4":
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }
}
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentsGrade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> students = 
                new Dictionary<string, List<decimal>>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] studentInfo= input.Split(" ");
                string studentName = studentInfo[0];
                decimal grade = decimal.Parse(studentInfo[1]);
                if (!students.ContainsKey(studentName))
                {
                    students.Add(studentName, new List<decimal>());
                    students[studentName].Add(grade);
                }
                else
                {
                    students[studentName].Add(grade);
                }
            }
            foreach (var student in students)
            {
                Console.Write($"{student.Key} -> ");
                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.Write($"(avg: {student.Value.Average():f2})");
                Console.WriteLine();
            }
            
            }
        }
    }


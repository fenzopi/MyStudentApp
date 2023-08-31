using System;
using System.Collections.Generic;

namespace MyStudentApp
{
    public class Student
    {
        private string v1;
        private string v2;

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }
        public List<double> Grades { get; set; }


        public Student(string name, string surname, string pesel)
        {
            if (!PeselValidator.ValidatePesel(pesel))
            {
                throw new ArgumentException("Niepoprawny numer PESEL.");
            }

            Name = name;
            Surname = surname;
            Pesel = pesel;
            Grades = new List<double>();
        }

        public Student(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                Grades.Add(grade);
            }
            else
            {
                throw new ArgumentException("Ocena musi być liczbą od 0 do 100.");
            }
        }

        public double CalculateAverageGrade()
        {
            if (Grades.Count == 0)
            {
                return 0;
            }

            return Grades.Average();
        }

        public double GetMaxGrade()
        {
            return Grades.Count == 0 ? 0 : Grades.Max();
        }

        public double GetMinGrade()
        {
            return Grades.Count == 0 ? 0 : Grades.Min();
        }

       
    }
}

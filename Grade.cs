using System;
using System.Collections.Generic;
using System.Linq;

namespace MyStudentApp
{
    public class Grade : IStatistics
{
    private List<Student> students;

    public Grade()
    {
        students = new List<Student>();
    }

    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public void AddGradeToStudent(int studentIndex, double grade)
    {
        if (studentIndex >= 0 && studentIndex < students.Count)
        {
            students[studentIndex].AddGrade(grade);
        }
        else
        {
            Console.WriteLine("Nieprawidłowy indeks studenta.");
        }
    }

    public double CalculateClassAverage()
    {
        if (students.Count == 0)
        {
            return 0;
        }

        double totalGrades = students.Sum(student => student.CalculateAverageGrade());
        return totalGrades / students.Count;
    }

    public Student GetStudentWithHighestAverage()
    {
        if (students.Count == 0)
        {
            return null;
        }

        return students.OrderByDescending(student => student.CalculateAverageGrade()).First();
    }

    public Student GetStudentWithLowestAverage()
    {
        if (students.Count == 0)
        {
            return null;
        }

        return students.OrderBy(student => student.CalculateAverageGrade()).First();
    }

    public int GetStudentCount()
    {
        return students.Count;
    }
}


}



using System;
using System.Data;
using System.Data.SQLite;

namespace MyStudentApp
{
    class Program
    

    {
        public interface IStudentFactory
        {
            Student CreateStudent(string name, string surname, string pesel);
        }

        public class StudentFactory : IStudentFactory
        {
            public Student CreateStudent(string name, string surname, string pesel)
            {
                if (!PeselValidator.ValidatePesel(pesel))
                {
                    Console.WriteLine("Niepoprawny numer PESEL.");
                    return null;
                }

                return new Student(name, surname, pesel);
            }
        }
    

    static void Main(string[] args)
        {
            string dbFilePath = "students.db"; // Ścieżka do pliku bazy danych SQLite
            string connectionString = $"Data Source={dbFilePath};Version=3;";
            SqliteDatabaseManager dbManager = new SqliteDatabaseManager(connectionString);

            Grade grade = new Grade();

            while (true)
            {
                Console.WriteLine("Wybierz opcję:");
                Console.WriteLine("1. Dodaj studenta");
                Console.WriteLine("2. Dodaj ocenę dla studenta");
                Console.WriteLine("3. Oblicz średnią ocen w klasie");
                Console.WriteLine("4. Znajdź studenta z najwyższą średnią");
                Console.WriteLine("5. Znajdź studenta z najniższą średnią");
                Console.WriteLine("6. Wyjdź");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent(grade, dbManager, new StudentFactory());

                        break;

                    case "2":
                        AddGradeToStudent(grade);
                        break;

                    case "3":
                        CalculateClassAverage(grade);
                        break;

                    case "4":
                        GetStudentWithHighestAverage(grade);
                        break;

                    case "5":
                        GetStudentWithLowestAverage(grade);
                        break;

                    case "6":
                        Console.WriteLine("Koniec programu.");
                        return;

                    default:
                        Console.WriteLine("Nieprawidłowa opcja. Wybierz ponownie.");
                        break;
                }
            }
        }

        static void AddStudent(Grade grade, SqliteDatabaseManager dbManager, IStudentFactory studentFactory)
        {
            Console.Write("Podaj imię studenta: ");
            string name = Console.ReadLine();
            Console.Write("Podaj nazwisko studenta: ");
            string surname = Console.ReadLine();
            Console.Write("Podaj numer PESEL studenta: ");
            string pesel = Console.ReadLine();

            Student student = studentFactory.CreateStudent(name, surname, pesel);
            if (student != null)
            {
                grade.AddStudent(student);

                // Inicjalizacja bazy danych
                dbManager.InitializeDatabase();

                // Zapisanie studenta do bazy danych
                dbManager.SaveStudentToDatabase(student.Name, student.Surname, student.Grades);

                Console.WriteLine("Dodano studenta i zapisano w bazie danych.");
            }
        }


        static void AddGradeToStudent(Grade grade)
        {
            Console.Write("Podaj indeks studenta, któremu chcesz dodać ocenę: ");
            int studentIndex = int.Parse(Console.ReadLine());

            if (studentIndex >= 0 && studentIndex < grade.GetStudentCount())
            {
                Console.Write("Podaj ocenę: ");
                double gradeValue = double.Parse(Console.ReadLine());

                grade.AddGradeToStudent(studentIndex, gradeValue);
                Console.WriteLine("Dodano ocenę.");
            }
            else
            {
                Console.WriteLine("Nieprawidłowy indeks studenta.");
            }
        }

        static void CalculateClassAverage(Grade grade)
        {
            double classAverage = grade.CalculateClassAverage();
            Console.WriteLine($"Średnia ocen w klasie: {classAverage}");
        }

        static void GetStudentWithHighestAverage(Grade grade)
        {
            Student highestAverageStudent = grade.GetStudentWithHighestAverage();
            if (highestAverageStudent != null)
            {
                Console.WriteLine($"Student z najwyższą średnią: {highestAverageStudent.Name} {highestAverageStudent.Surname}");
            }
            else
            {
                Console.WriteLine("Brak studentów w klasie.");
            }
        }

        static void GetStudentWithLowestAverage(Grade grade)
        {
            Student lowestAverageStudent = grade.GetStudentWithLowestAverage();
            if (lowestAverageStudent != null)
            {
                Console.WriteLine($"Student z najniższą średnią: {lowestAverageStudent.Name} {lowestAverageStudent.Surname}");
            }
            else
            {
                Console.WriteLine("Brak studentów w klasie.");
            }
        }
    }
}

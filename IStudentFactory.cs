using System;

namespace MyStudentApp
{
    public interface IStudentFactory
    {
        Student CreateStudent(string name, string surname, string pesel);
    }

    public class StudentFactory : IStudentFactory
    {
        public virtual Student CreateStudent(string name, string surname, string pesel)
        {
            if (!PeselValidator.ValidatePesel(pesel))
            {
                Console.WriteLine("Niepoprawny numer PESEL.");
                return null;
            }

            return new Student(name, surname, pesel);
        }
    }

    public class CustomStudentFactory : StudentFactory
    {
        public override Student CreateStudent(string name, string surname, string pesel)
        {
            // Tu możesz umieścić swoje własne reguły lub modyfikacje tworzenia studenta
            return base.CreateStudent(name, surname, pesel);
        }
    }
}

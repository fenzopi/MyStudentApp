using MyStudentApp;

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
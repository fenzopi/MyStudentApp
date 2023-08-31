using System;

namespace MyStudentApp
{
    public static class PeselValidator
    {
        public static bool ValidatePesel(string pesel)
        {
            if (pesel.Length != 11 || !IsNumeric(pesel))
            {
                return false;
            }

            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3, 1 };
            int sum = 0;

            for (int i = 0; i < 11; i++)
            {
                try
                {
                    int digit = int.Parse(pesel[i].ToString());
                    sum += (digit * weights[i]) % 10;
                }
                catch (FormatException)
                {
                    // Obsługa błędu parsowania - znak nie jest liczbą
                    return false;
                }
                catch (Exception ex)
                {
                    // Obsługa innych błędów
                    Console.WriteLine("Wystąpił nieoczekiwany błąd: " + ex.Message);
                    return false;
                }
            }

            return sum % 10 == 0;
        }

        private static bool IsNumeric(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}

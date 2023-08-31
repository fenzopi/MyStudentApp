using System.Data.SQLite;
using System.IO;

namespace MyStudentApp
{
    internal class SqliteDatabaseManager
    {
        private string connectionString;

        public SqliteDatabaseManager(string connectionString)
        {
            this.connectionString = connectionString;
            InitializeDatabase();
        }

        public void InitializeDatabase()
        {
            bool isNewDatabase = !File.Exists(connectionString); // Sprawdź, czy plik bazy istnieje

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = "CREATE TABLE IF NOT EXISTS Students (Name TEXT, Surname TEXT, Grades TEXT)";
                    command.ExecuteNonQuery();
                }
            }

            if (isNewDatabase)
            {
                // Tworzenie nowej bazy, nadpisanie istniejącego pliku
                File.WriteAllBytes(connectionString, new byte[0]);
            }
        }

        public void SaveStudentToDatabase(string name, string surname, List<double> grades)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                string query = "INSERT INTO Students (Name, Surname, Grades) VALUES (@Name, @Surname, @Grades)";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Surname", surname);
                    command.Parameters.AddWithValue("@Grades", string.Join(",", grades));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

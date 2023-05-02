using System.Data.SqlClient;

namespace AdoNetTest1
{
    internal class Program
    {
        const string connectionString = "Data Source=localhost;Initial Catalog=BookStoreDB;Integrated Security=True";

        static void Main(string[] args)
        {
            string sqlExpression = "SELECT Books.Name as BooksName, Books.Year as Year, Publisher.Name as PublisherName FROM Books ";

            sqlExpression += "Inner Join Publisher On Books.PublisherID = Publisher.Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlExpression, connection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"'{reader["BooksName"]}'; {reader["PublisherName"]}; {reader["Year"]}");
                    }
                }
            }
        }
    }
}
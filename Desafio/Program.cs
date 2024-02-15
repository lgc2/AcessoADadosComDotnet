using Blog.Screens;
using Blog.Screens.TagScreens;
using Blog.Screens.UserScreens;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=127.0.0.1,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=true";

        static void Main(string[] args)
        {
            Database.Connection = new SqlConnection(CONNECTION_STRING);
            Database.Connection.Open();

            MainMenuScreen.Load();

            Console.ReadKey();
            Database.Connection.Close();
        }
    }
}
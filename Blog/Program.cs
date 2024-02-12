using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=127.0.0.1,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=true";

        static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();

            ReadUsers(connection);
            ReadUser(connection, 3);

            /*
            var newUser = new User()
            {
                Name = "lgc2_2",
                Email = "lgc2.2@balta.io",
                PasswordHash = "HASH123456",
                Bio = "Equipe recente do balta.io",
                Image = "https://...",
                Slug = "equipe-recente-balta2"
            };
            CreateUser(connection, newUser);
            */

            /*
            var newUser = new User()
            {
                Id = 5,
                Name = "lgc2_2_2",
                Email = "lgc2.2.2@balta.io",
                PasswordHash = "HASH123456789",
                Bio = "Equipe recente do balta.io",
                Image = "https://...",
                Slug = "equipe-recente-balta2-2"
            };
            UpdateUser(connection, newUser);
            */

            /*
            var newUser = new User()
            {
                Id = 5
            };
            DeleteUser(connection, newUser);
            */

            // DeleteUser(connection, 4);

            ReadRoles(connection);
            ReadTags(connection);

            connection.Close();
        }

        static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var items = repository.Get();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }

        static void ReadUser(SqlConnection connection, int userId)
        {
            var repository = new Repository<User>(connection);
            var user = repository.Get(userId);

            Console.WriteLine($"Get by id: {user.Name}");
        }

        static void CreateUser(SqlConnection connection, User user)
        {
            var repository = new Repository<User>(connection);
            var insertId = repository.Create(user);

            Console.WriteLine($"Id of insertion: {insertId}");
        }

        static void UpdateUser(SqlConnection connection, User user)
        {
            var repository = new Repository<User>(connection);
            var wasUpdated = repository.Update(user);

            Console.WriteLine($"Was it updated? {wasUpdated}");
        }

        static void DeleteUser(SqlConnection connection, User user)
        {
            var repository = new Repository<User>(connection);
            var wasDeleted = repository.Delete(user);

            Console.WriteLine($"Was it deleted? {wasDeleted}");
        }

        static void DeleteUser(SqlConnection connection, int userId)
        {
            var repository = new Repository<User>(connection);
            var wasDeleted = repository.Delete(userId);

            Console.WriteLine($"Was it deleted? {wasDeleted}");
        }

        static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var items = repository.Get();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }

        static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var items = repository.Get();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }
    }
}
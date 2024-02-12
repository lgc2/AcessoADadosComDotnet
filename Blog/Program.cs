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
            ReadRoles(connection);
            // ReadUser(2);
            // CreateUser();
            // UpdateUser();
            // DeleteUser(2);

            connection.Close();
        }

        static void ReadUsers(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var users = repository.Get();

            foreach (var user in users)
                Console.WriteLine(user.Name);
        }

        static void ReadRoles(SqlConnection connection)
        {
            var repository = new RoleRepository(connection);
            var roles = repository.Get();

            foreach (var role in roles)
                Console.WriteLine(role.Name);
        }

        // static void ReadUser(int userId)
        // {
        //     using (var connection = new SqlConnection(CONNECTION_STRING))
        //     {
        //         var user = connection.Get<User>(userId);

        //         Console.WriteLine($"Get user: {user.Name}");
        //     }
        // }

        // static void CreateUser()
        // {
        //     var user = new User()
        //     {
        //         Bio = "Equipe balta.io",
        //         Email = "hello@balta.io",
        //         Image = "https://...",
        //         Name = "Equipe balta.io",
        //         PasswordHash = "HASH",
        //         Slug = "equipe-balta"
        //     };

        //     using (var connection = new SqlConnection(CONNECTION_STRING))
        //     {
        //         connection.Insert<User>(user);
        //         Console.WriteLine("Cadastro realizado com sucesso!");
        //     }
        // }

        // static void UpdateUser()
        // {
        //     var user = new User()
        //     {
        //         Id = 2,
        //         Bio = "Equipe | balta.io",
        //         Email = "hellooo@balta.io",
        //         Image = "https://...",
        //         Name = "Equipe de suporte balta.io",
        //         PasswordHash = "HASH",
        //         Slug = "equipe-suporte-balta"
        //     };

        //     using (var connection = new SqlConnection(CONNECTION_STRING))
        //     {
        //         connection.Update<User>(user);
        //         Console.WriteLine("Cadastro editado com sucesso!");
        //     }
        // }

        // static void DeleteUser(int userId)
        // {
        //     using (var connection = new SqlConnection(CONNECTION_STRING))
        //     {
        //         var user = connection.Get<User>(userId);
        //         connection.Delete<User>(user);

        //         Console.WriteLine("Exclusão realizada com sucesso!");
        //     }
        // }
    }
}
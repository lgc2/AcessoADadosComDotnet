using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class CreateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Novo usuário");
            Console.WriteLine("------------");
            Console.WriteLine();

            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Email: ");
            var email = Console.ReadLine();

            var passwordHash = Guid.NewGuid();

            Console.Write("Bio: ");
            var bio = Console.ReadLine();

            Console.Write("URL da imagem: ");
            var image = Console.ReadLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Create(new User()
            {
                Name = name,
                Email = email,
                PasswordHash = passwordHash.ToString(),
                Bio = bio,
                Image = image,
                Slug = slug
            });
            Console.ReadKey();

            MenuUserScreen.Load();
        }

        private static void Create(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                var userId = repository.Create(user);
                Console.WriteLine($"id do usuário criado {userId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel inserir o usuário.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
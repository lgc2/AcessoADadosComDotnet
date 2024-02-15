using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens
{
    public static class CreateRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Novo perfil");
            Console.WriteLine("-----------");
            Console.WriteLine();

            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Create(new Role() { Name = name, Slug = slug });
            Console.ReadKey();

            MenuRoleScreen.Load();
        }

        private static void Create(Role role)
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                var roleId = repository.Create(role);
                Console.WriteLine($"id do perfil criado: {roleId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel inserir o perfil.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
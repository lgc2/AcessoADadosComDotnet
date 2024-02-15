using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class ListUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de usuários");
            Console.WriteLine("-----------------");
            List();
            Console.ReadKey();

            MenuUserScreen.Load();
        }

        private static void List()
        {
            var repository = new UserRepository(Database.Connection);
            var users = repository.GetWithRoles();

            foreach (var user in users)
            {
                Console.WriteLine();
                Console.Write($"Nome: {user.Name}, Email: {user.Email}");
                foreach (var role in user.Roles)
                {
                    Console.Write($", Perfil: {role.Name}");
                }
            }
        }
    }
}
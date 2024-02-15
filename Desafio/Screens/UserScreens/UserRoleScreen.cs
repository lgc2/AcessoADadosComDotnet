using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class UserRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Vincular um usuário a um perfil");
            Console.WriteLine("-------------------------------");
            Console.WriteLine();

            Console.Write("Id do usuário: ");
            var userId = Console.ReadLine();

            Console.Write("Id do perfil: ");
            var roleId = Console.ReadLine();

            UserRoleLink(int.Parse(userId), int.Parse(roleId));

            Console.ReadKey();
            MenuUserScreen.Load();
        }

        private static void UserRoleLink(int userId, int roleId)
        {
            try
            {
                var repository = new UserRepository(Database.Connection);
                var row = repository.UserRoleLink(userId, roleId);

                Console.WriteLine($"Número de linha(s) inserida(s): {row}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel vincular o usuário ao perfil.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
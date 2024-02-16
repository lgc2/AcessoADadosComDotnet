using Blog.Screens.CategoryScreens;
using Blog.Screens.PostScreens;
using Blog.Screens.RoleScreens;
using Blog.Screens.TagScreens;
using Blog.Screens.UserScreens;

namespace Blog.Screens
{
    public static class MainMenuScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Meu Blog");
            Console.WriteLine("--------------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1- Gestão de usuário");
            Console.WriteLine("2- Gestão de perfil");
            Console.WriteLine("3- Gestão de categoria");
            Console.WriteLine("4- Gestão de tag");
            Console.WriteLine("5- Gestão de post");
            Console.WriteLine("6- Vincular post/tag");
            Console.WriteLine("7- Relatórios");
            Console.WriteLine();
            Console.WriteLine("0- Sair");
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 0:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                case 1:
                    MenuUserScreen.Load();
                    break;
                case 2:
                    MenuRoleScreen.Load();
                    break;
                case 3:
                    MenuCategoryScreen.Load();
                    break;
                case 4:
                    MenuTagScreen.Load();
                    break;
                case 5:
                    MenuPostScreen.Load();
                    break;
                case 6:
                    // .Load();
                    break;
                case 7:
                    // .Load();
                    break;
                default: Load(); break;
            }
        }
    }
}
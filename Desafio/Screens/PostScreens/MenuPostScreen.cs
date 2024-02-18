namespace Blog.Screens.PostScreens
{
    public static class MenuPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de posts");
            Console.WriteLine("--------------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1- Listar posts");
            Console.WriteLine("2- Listar posts de uma categoria");
            Console.WriteLine("3- Cadastrar post");
            Console.WriteLine("4- Atualizar post");
            Console.WriteLine("5- Excluir post");
            Console.WriteLine("6- Vincular um post a uma tag");
            Console.WriteLine();
            Console.WriteLine("7- Voltar ao Menu Principal");
            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ListPostScreen.Load();
                    break;
                case 2:
                    ListPostsByCategoryNameScreen.Load();
                    break;
                case 3:
                    CreatePostScreen.Load();
                    break;
                case 4:
                    // UpdatePostScreen.Load();
                    break;
                case 5:
                    // DeletePostScreen.Load();
                    break;
                case 6:
                    PostTagScreen.Load();
                    break;
                case 7:
                    MainMenuScreen.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}
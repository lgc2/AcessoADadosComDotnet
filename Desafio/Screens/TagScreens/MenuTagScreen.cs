namespace Blog.Screens.TagScreens
{
    public static class MenuTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de tags");
            Console.WriteLine("--------------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1- Listar tags");
            Console.WriteLine("2- Cadastrar tag");
            Console.WriteLine("3- Atualizar tag");
            Console.WriteLine("4- Excluir tag");
            Console.WriteLine();
            Console.WriteLine("5- Voltar ao Menu Principal");
            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ListTagScreen.Load();
                    break;
                case 2:
                    CreateTagScreen.Load();
                    break;
                case 3:
                    UpdateTagScreen.Load();
                    break;
                case 4:
                    DeleteTagScreen.Load();
                    break;
                case 5:
                    MainMenuScreen.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}
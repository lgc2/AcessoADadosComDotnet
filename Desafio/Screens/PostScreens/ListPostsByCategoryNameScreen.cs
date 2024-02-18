using Blog.Repositories;

namespace Blog.Screens.PostScreens
{
    public static class ListPostsByCategoryNameScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de posts pela categoria");
            Console.WriteLine("-----------------------------");
            Console.WriteLine();

            Console.WriteLine("Digite o nome da categoria que se deseja buscar os posts:");
            var categoryName = Console.ReadLine();

            List(categoryName);
            Console.ReadKey();

            MenuPostScreen.Load();
        }

        private static void List(string categoryName)
        {
            var repository = new PostRepository(Database.Connection);
            var categoryPosts = repository.GetPostsByCategoryName(categoryName);

            if (categoryPosts.Any())
            {
                foreach (var item in categoryPosts)
                {
                    Console.WriteLine($"{item.Id} - {item.Title}");
                }
            }
            else
            {
                Console.WriteLine($"Não foram encontrados posts para {categoryName}");
            }
        }
    }
}
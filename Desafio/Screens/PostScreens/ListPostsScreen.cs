using Blog.Repositories;

namespace Blog.Screens.PostScreens
{
    public static class ListPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de posts com sua categoria");
            Console.WriteLine("--------------------------------");
            ListWithCategory();
            Console.ReadKey();

            MenuPostScreen.Load();
        }

        private static void ListWithCategory()
        {
            var repository = new PostRepository(Database.Connection);
            var posts = repository.GetWithCategory();

            foreach (var item in posts)
            {
                Console.WriteLine($"{item.Id} - {item.Title}, Categoria: {item.Category.Id}, {item.Category.Name}, {item.Category.Slug}");
            }
        }
    }
}
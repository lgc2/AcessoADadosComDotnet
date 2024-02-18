using Blog.Repositories;

namespace Blog.Screens.CategoryScreens
{
    public static class ListCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de categorias");
            Console.WriteLine("-------------------");
            List();
            Console.ReadKey();

            MenuCategoryScreen.Load();
        }

        private static void List()
        {
            var repository = new CategoryRepository(Database.Connection);
            var categories = repository.GetWithPostsQuantity();

            foreach (var item in categories)
            {
                Console.WriteLine($"{item.Id} - {item.Name} - {item.Slug} - Quantidade de posts: {item.PostsQuantity}");
            }
        }
    }
}
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
    public static class ListTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de tags");
            Console.WriteLine("-------------");
            List();
            Console.ReadKey();

            MenuTagScreen.Load();
        }

        private static void List()
        {
            var repository = new TagRepository(Database.Connection);
            var tags = repository.GetWithPostsQuantity();

            foreach (var item in tags)
            {
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug}) - Quantidade de posts: {item.PostsQuantity}");
            }
        }
    }
}
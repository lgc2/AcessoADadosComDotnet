using Blog.Repositories;

namespace Blog.Screens.PostScreens
{
    public static class ListPostsWithTagsScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de posts com suas tags");
            Console.WriteLine("----------------------------");
            Console.WriteLine();

            List();
            Console.ReadKey();

            MenuPostScreen.Load();
        }

        private static void List()
        {
            var repository = new PostRepository(Database.Connection);
            var postsWithTags = repository.GetWithTags();

            foreach (var post in postsWithTags)
            {
                Console.WriteLine();
                Console.Write($"{post.Id} - {post.Title}");
                foreach (var tag in post.Tags)
                {
                    Console.Write($", Tag: [{tag.Id}] {tag.Name}");
                }
            }
            Console.WriteLine();
        }
    }
}
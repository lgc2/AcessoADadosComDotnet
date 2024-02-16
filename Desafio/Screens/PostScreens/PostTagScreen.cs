using Blog.Repositories;

namespace Blog.Screens.PostScreens
{
    public static class PostTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Vincular um post a uma tag");
            Console.WriteLine("--------------------------");
            Console.WriteLine();

            Console.Write("Id do post: ");
            var postId = Console.ReadLine();

            Console.Write("Id da tag: ");
            var tagId = Console.ReadLine();

            PostTagLink(int.Parse(postId), int.Parse(tagId));

            Console.ReadKey();
            MenuPostScreen.Load();
        }

        private static void PostTagLink(int postId, int tagId)
        {
            try
            {
                var repository = new PostRepository(Database.Connection);
                var row = repository.PostTagLink(postId, tagId);

                Console.WriteLine($"Número de linha(s) inserida(s): {row}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel vincular o post a uma tag.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
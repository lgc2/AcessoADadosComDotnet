using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.PostScreens
{
    public static class CreatePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Novo post");
            Console.WriteLine("---------");
            Console.WriteLine();

            Console.Write("Id da categoria: ");
            var categoryId = Console.ReadLine();

            Console.Write("Id do autor: ");
            var authorId = Console.ReadLine();

            Console.Write("Título: ");
            var title = Console.ReadLine();

            Console.Write("Resumo: ");
            var summary = Console.ReadLine();

            Console.Write("Texto do post: ");
            var body = Console.ReadLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            var createDate = DateTime.UtcNow.AddHours(-3);

            var lastUpdateDate = DateTime.UtcNow.AddHours(-3);

            Create(new Post()
            {
                CategoryId = int.Parse(categoryId),
                AuthorId = int.Parse(authorId),
                Title = title,
                Summary = summary,
                Body = body,
                Slug = slug,
                CreateDate = createDate,
                LastUpdateDate = lastUpdateDate
            });
            Console.ReadKey();

            MenuPostScreen.Load();
        }

        private static void Create(Post post)
        {
            try
            {
                var repository = new Repository<Post>(Database.Connection);
                var postId = repository.Create(post);
                Console.WriteLine($"id do post criado {postId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel inserir o post.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
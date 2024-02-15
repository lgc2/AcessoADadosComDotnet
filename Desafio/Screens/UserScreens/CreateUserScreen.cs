using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class CreateUserScreen
    {
        public static void Load()
        {
            // Console.Clear();
            // Console.WriteLine("Nova tag");
            // Console.WriteLine("--------");
            // Console.WriteLine();

            // Console.Write("Nome: ");
            // var name = Console.ReadLine();

            // Console.Write("Slug: ");
            // var slug = Console.ReadLine();

            // Create(new Tag() { Name = name, Slug = slug });
            // Console.ReadKey();

            // MenuTagScreen.Load();
        }

        private static void Create(Tag tag)
        {
            //     try
            //     {
            //         var repository = new Repository<Tag>(Database.Connection);
            //         var tagId = repository.Create(tag);
            //         Console.WriteLine($"id da tag criada: {tagId}");
            //     }
            //     catch (Exception ex)
            //     {
            //         Console.WriteLine("Não foi possivel inserir a tag.");
            //         Console.WriteLine(ex.Message);
            //     }
        }
    }
}
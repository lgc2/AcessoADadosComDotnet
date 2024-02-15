using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class UpdateUserScreen
    {
        public static void Load()
        {
            // Console.Clear();
            // Console.WriteLine("Atualizando uma tag");
            // Console.WriteLine("-------------------");
            // Console.WriteLine();

            // Console.Write("Id: ");
            // var id = Console.ReadLine();

            // Console.Write("Nome: ");
            // var name = Console.ReadLine();

            // Console.Write("Slug: ");
            // var slug = Console.ReadLine();

            // Update(new Tag() { Id = int.Parse(id), Name = name, Slug = slug });
            // Console.ReadKey();

            // MenuTagScreen.Load();
        }

        private static void Update(Tag tag)
        {
            // try
            // {
            //     var repository = new Repository<Tag>(Database.Connection);
            //     var wasItSuccessful = repository.Update(tag);

            //     Console.WriteLine("Tag atualizada com sucesso");
            // }
            // catch (Exception ex)
            // {
            //     Console.WriteLine("Não foi possivel atualizar a tag.");
            //     Console.WriteLine(ex.Message);
            // }
        }
    }
}
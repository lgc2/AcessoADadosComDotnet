using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class DeleteUserScreen
    {
        public static void Load()
        {
            // Console.Clear();
            // Console.WriteLine("Excluir uma tag");
            // Console.WriteLine("---------------");
            // Console.WriteLine();

            // Console.Write("Id da tag que deseja excluir: ");
            // var id = Console.ReadLine();

            // Delete(int.Parse(id));
            // Console.ReadKey();

            // MenuTagScreen.Load();
        }

        private static void Delete(int id)
        {
            // try
            // {
            //     var repository = new Repository<Tag>(Database.Connection);
            //     var wasItSuccessful = repository.Delete(id);

            //     Console.WriteLine("Tag excluída com sucesso");
            // }
            // catch (Exception ex)
            // {
            //     Console.WriteLine("Não foi possivel excluir a tag.");
            //     Console.WriteLine(ex.Message);
            // }
        }
    }
}
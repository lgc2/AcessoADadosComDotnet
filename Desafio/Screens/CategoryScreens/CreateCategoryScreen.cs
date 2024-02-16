using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreens
{
    public static class CreateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Nova categoria");
            Console.WriteLine("------------");
            Console.WriteLine();

            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Create(new Category()
            {
                Name = name,
                Slug = slug
            });
            Console.ReadKey();

            MenuCategoryScreen.Load();
        }

        private static void Create(Category category)
        {
            try
            {
                var repository = new Repository<Category>(Database.Connection);
                var categoryId = repository.Create(category);
                Console.WriteLine($"id da categoria criada {categoryId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel inserir a categoria.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
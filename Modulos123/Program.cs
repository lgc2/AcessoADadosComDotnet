using BaltaDataAccess.Model;
using Dapper;
using Microsoft.Data.SqlClient;

const string connectionString = "Server=127.0.0.1,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=true";

using (var connection = new SqlConnection(connectionString))
{
    // CreateCategory(connection);
    // CreateManyCategory(connection);
    // UpdateCategory(connection);
    ListCategories(connection);
    GetCategory(connection, "Backend");
    // DeleteCategory(connection, "Amazon AWS");
    // ExecuteProcedure(connection, new Guid("429d84eb-979c-4ee9-a8d3-b7a438d92836"));
}

static void GetCategory(SqlConnection connection, string categoryTitle)
{
    var category = connection.QueryFirstOrDefault<Category>("SELECT [Id], [Title] FROM [Category] WHERE [Title]=@title", new
    {
        title = categoryTitle
    });
    Console.WriteLine($"{category.Id} | {category.Title}");
}

static void ListCategories(SqlConnection connection)
{
    var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category] ORDER BY [Order] ASC");
    foreach (var item in categories)
    {
        Console.WriteLine($"{item.Id} | {item.Title}");
    }
}

static void CreateCategory(SqlConnection connection)
{
    var category = new Category();
    category.Id = Guid.NewGuid();
    category.Title = "Amazon AWS";
    category.Url = "amazon";
    category.Description = "Categoria destinada a serviços da AWS";
    category.Order = 8;
    category.Summary = "AWS Cloud";
    category.Featured = false;

    var insertSql = @"INSERT INTO
    [Category]
    VALUES(
        @Id,
        @Title,
        @Url,
        @Summary,
        @Order,
        @Description,
        @Featured
    )";

    var rows = connection.Execute(insertSql, new
    {
        category.Id,
        category.Title,
        category.Url,
        category.Summary,
        category.Order,
        category.Description,
        category.Featured
    });

    Console.WriteLine($"{rows} linhas inseridas");
}

static void CreateManyCategory(SqlConnection connection)
{
    var category = new Category();
    category.Id = Guid.NewGuid();
    category.Title = "Amazon AWS";
    category.Url = "amazon";
    category.Description = "Categoria destinada a serviços da AWS";
    category.Order = 8;
    category.Summary = "AWS Cloud";
    category.Featured = false;

    var category2 = new Category();
    category2.Id = Guid.NewGuid();
    category2.Title = "Categoria Nova";
    category2.Url = "categoria-nova";
    category2.Description = "Categoria nova";
    category2.Order = 9;
    category2.Summary = "Categoria";
    category2.Featured = true;

    var insertSql = @"INSERT INTO
    [Category]
    VALUES(
        @Id,
        @Title,
        @Url,
        @Summary,
        @Order,
        @Description,
        @Featured
    )";

    var rows = connection.Execute(insertSql, new[]{
    new
    {
        category.Id,
        category.Title,
        category.Url,
        category.Summary,
        category.Order,
        category.Description,
        category.Featured
    },
    new
    {
        category2.Id,
        category2.Title,
        category2.Url,
        category2.Summary,
        category2.Order,
        category2.Description,
        category2.Featured
    }
});

    Console.WriteLine($"{rows} linhas inseridas");
}

static void UpdateCategory(SqlConnection connection)
{
    var updateSql = "UPDATE [Category] SET [Title]=@title WHERE [Id]=@id";
    var rows = connection.Execute(updateSql, new
    {
        title = "Frontend 2021",
        id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4")
    });

    Console.WriteLine($"{rows} registros atualizados");
}

static void DeleteCategory(SqlConnection connection, string categoryTitle)
{
    var deleteSql = "DELETE FROM [Category] WHERE [Title]=@title";
    var row = connection.Execute(deleteSql, new
    {
        title = categoryTitle
    });

    Console.WriteLine($"{row} linha removida");
}

static void ExecuteProcedure(SqlConnection connection, Guid studentId)
{
    var procedure = "[spDeleteStudent]";
    var pars = new { StudentId = studentId };
    var affectedRows = connection.Execute(procedure, pars, commandType: System.Data.CommandType.StoredProcedure);

    Console.WriteLine($"{affectedRows} linhas afetadas");
}
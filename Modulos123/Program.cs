using BaltaDataAccess.Model;
using Dapper;
using Microsoft.Data.SqlClient;

const string connectionString = "Server=127.0.0.1,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=true";

using (var connection = new SqlConnection(connectionString))
{
    // CreateCategory(connection);
    // CreateManyCategory(connection);
    // UpdateCategory(connection);
    // ListCategories(connection);
    // GetCategory(connection, "Backend");
    // DeleteCategory(connection, "Amazon AWS");
    // ExecuteProcedure(connection, new Guid("429d84eb-979c-4ee9-a8d3-b7a438d92836"));
    // ExecuteReadProcedure(connection, new Guid("09ce0b7b-cfca-497b-92c0-3290ad9d5142"));
    // ExecuteScalar(connection);
    // ReadView(connection);
    // OneToOne(connection);
    // OneToMany(connection);
    // QueryMultiple(connection);
    // SelectIn(connection);
    // SelectLike(connection, "%backen%");
    Transaction(connection);
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

static void ExecuteReadProcedure(SqlConnection connection, Guid categoryId)
{
    var procedure = "[spGetCoursesByCategory]";
    var pars = new { CategoryId = categoryId };
    var courses = connection.Query(procedure, pars, commandType: System.Data.CommandType.StoredProcedure);

    // como não criamos a classe Course, os itens da lista não serão tipados, estarão como dynamic (lista do tipo dinâmico)
    var row = 0;
    foreach (var item in courses)
    {
        row++;
        Console.WriteLine($"{row}- {item.Id} | {item.Title}");
    }
}

static void ExecuteScalar(SqlConnection connection)
{
    var category = new Category();
    category.Title = "Amazon AWS (Execute Scalar)";
    category.Url = "execute-scalar-example";
    category.Description = "Categoria destinada a serviços da AWS (Execute Scalar)";
    category.Order = 8;
    category.Summary = "AWS Cloud (Execute Scalar)";
    category.Featured = false;

    var insertSql = @"
    INSERT INTO
        [Category]
    OUTPUT inserted.[Id]
    VALUES(
        NEWID(),
        @Title,
        @Url,
        @Summary,
        @Order,
        @Description,
        @Featured)
    ";

    var id = connection.ExecuteScalar<Guid>(insertSql, new
    {
        category.Id,
        category.Title,
        category.Url,
        category.Summary,
        category.Order,
        category.Description,
        category.Featured
    });

    Console.WriteLine($"A categoria inserida foi: {id}");
}

static void ReadView(SqlConnection connection)
{
    var sql = "SELECT * FROM [vwCourses]";
    var courses = connection.Query(sql);
    foreach (var item in courses)
    {
        Console.WriteLine($"{item.Id} | {item.Title}");
    }
}

static void OneToOne(SqlConnection connection)
{
    var sql = @"
    SELECT
        *
    FROM
        [CareerItem]
        inner join [Course] ON [CareerItem].[CourseId] = [Course].[Id]";

    var items = connection.Query<CareerItem, Course, CareerItem>(
        sql,
        (careerItem, course) =>
        {
            careerItem.Course = course;
            return careerItem;
        }, splitOn: "Id");
    foreach (var item in items)
    {
        Console.WriteLine($"{item.Title} - Curso: {item.Course.Title}");
    }
}

static void OneToMany(SqlConnection connection)
{
    var sql = @"
    SELECT
        [Career].[Id],
        [Career].[Title],
        [CareerItem].[CareerId],
        [CareerItem].[Title]
    FROM
        [Career]
        INNER JOIN
            [CareerItem] ON [Career].[Id] = [CareerItem].[CareerId]
    ORDER BY
        [Career].[Title]";

    var careers = new List<Career>();
    var items = connection.Query<Career, CareerItem, Career>(
        sql,
        (career, careerItem) =>
        {
            var car = careers.Where(x => x.Id == career.Id).FirstOrDefault();
            if (car == null)
            {
                car = career;
                car.Items.Add(careerItem);
                careers.Add(car);
            }
            else
            {
                car.Items.Add(careerItem);
            }
            return career;
        }, splitOn: "CareerId");
    foreach (var career in careers)
    {
        Console.WriteLine($"{career.Title}");
        foreach (var item in career.Items)
        {
            Console.WriteLine($" - {item.Title}");
        }
    }
}

static void QueryMultiple(SqlConnection connection)
{
    var sql = "SELECT * FROM [Category]; SELECT * FROM [Course]";

    using (var multi = connection.QueryMultiple(sql))
    {
        var categories = multi.Read<Category>();
        var courses = multi.Read<Course>();

        foreach (var category in categories)
        {
            Console.WriteLine(category.Title);
        }
        foreach (var course in courses)
        {
            Console.WriteLine(course.Title);
        }
    }
}

static void SelectIn(SqlConnection connection)
{
    var sql = @"
    SELECT *
    FROM
        [Career]
    WHERE [Id] IN @Id";

    var items = connection.Query<Career>(sql, new
    {
        Id = new[]{
        "01ae8a85-b4e8-4194-a0f1-1c6190af54cb",
        "e6730d1c-6870-4df3-ae68-438624e04c72"
        }
    });

    foreach (var item in items)
    {
        Console.WriteLine(item.Title);
    }
}

static void SelectLike(SqlConnection connection, string titleLike)
{
    var sql = @"
    SELECT *
    FROM
        [Career]
    WHERE [Title] LIKE @expression";

    var items = connection.Query<Career>(sql, new
    {
        expression = titleLike
        // ou expression = $"%{titleLike}%"
    });

    foreach (var item in items)
    {
        Console.WriteLine(item.Title);
    }
}

static void Transaction(SqlConnection connection)
{
    var category = new Category();
    category.Id = Guid.NewGuid();
    category.Title = "Categoria que não quero salvar";
    category.Url = "amazon";
    category.Description = "Categoria destinada a serviços da AWS";
    category.Order = 9;
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

    connection.Open();
    using (var transaction = connection.BeginTransaction())
    {
        var rows = connection.Execute(insertSql, new
        {
            category.Id,
            category.Title,
            category.Url,
            category.Summary,
            category.Order,
            category.Description,
            category.Featured
        }, transaction);

        transaction.Commit();
        // transaction.Rollback();

        Console.WriteLine($"{rows} linhas inseridas");
    }
}
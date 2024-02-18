using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(SqlConnection connection) : base(connection)
            => _connection = connection;

        private readonly SqlConnection _connection;

        public IEnumerable<Category> GetWithPostsQuantity()
        {
            var query = @"
           SELECT
                [Category].*,
                COUNT([Post].[Id]) AS [PostsQuantity]
            FROM
                [Category]
            LEFT JOIN
                [Post] ON [Category].[Id] = [Post].[CategoryId]
            GROUP BY
                [Category].[Id], [Category].[Name], [Category].[Slug]";

            return _connection.Query<Category>(query);
        }
    }
}
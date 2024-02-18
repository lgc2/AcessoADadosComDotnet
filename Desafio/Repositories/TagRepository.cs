using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class TagRepository : Repository<Tag>
    {
        public TagRepository(SqlConnection connection) : base(connection)
            => _connection = connection;

        private readonly SqlConnection _connection;

        public IEnumerable<Tag> GetWithPostsQuantity()
        {
            var query = @"
                SELECT
                    [Tag].*,
                    COUNT([PostTag].[TagId]) AS PostsQuantity
                FROM
                    [Tag]
                LEFT JOIN
                    [PostTag] ON [Tag].[Id] = [PostTag].[TagId]
                GROUP BY
                    [Tag].[Id], [Tag].[Name], [Tag].[Slug]";

            return _connection.Query<Tag>(query);
        }
    }
}
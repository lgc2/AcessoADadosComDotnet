using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class PostRepository : Repository<Post>
    {
        public PostRepository(SqlConnection connection) : base(connection)
            => _connection = connection;

        private readonly SqlConnection _connection;

        public int PostTagLink(int postId, int tagId)
        {
            var sql = @"
            INSERT INTO [PostTag] ([PostId], [TagId])
            VALUES (@PostId, @TagId)";

            return _connection.Execute(sql, new
            {
                PostId = postId,
                TagId = tagId
            });
        }

        public IEnumerable<Post> GetPostsByCategoryName(string categoryName)
        {
            var query = @"
                SELECT
                    [Post].*
                FROM
                    [Post]
                INNER JOIN
                    [Category] ON [Post].[CategoryId] = [Category].[Id]
                WHERE [Category].[Name] = @CategoryName
                ORDER BY
                    [Post].[Id] ASC";

            return _connection.Query<Post>(query, new
            {
                CategoryName = categoryName
            });
        }
    }
}
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

        public IEnumerable<Post> GetWithCategory()
        {
            var query = @"
            SELECT
                *
            FROM
                [Post]
            INNER JOIN
                [Category] ON [Post].[CategoryId] = [Category].[Id]
            ORDER BY
                [Post].[Id] ASC,
                [Post].[CategoryId] ASC,
                [Post].[AuthorId] ASC";

            return _connection.Query<Post, Category, Post>(
                query,
                (post, category) =>
                {
                    post.Category = category;
                    return post;
                }, splitOn: "Id");
        }

        public IEnumerable<Post> GetWithTags()
        {
            var query = @"
            SELECT
                [Post].*,
                [Tag].*
            FROM
                [Post]
                LEFT JOIN
                    [PostTag] ON [Post].[Id] = [PostTag].[PostId]
                LEFT JOIN
                    [Tag] ON [PostTag].[TagId] = [Tag].[Id]
            ORDER BY
                [Post].[Id] ASC,
                [Post].[CategoryId] ASC,
                [Post].[AuthorId] ASC";

            var posts = new List<Post>();

            var items = _connection.Query<Post, Tag, Post>(
                query,
                (post, tag) =>
                {
                    var pst = posts.FirstOrDefault(x => x.Id == post.Id);
                    if (pst == null)
                    {
                        pst = post;

                        if (tag != null)
                            pst.Tags.Add(tag);

                        posts.Add(pst);
                    }
                    else
                        pst.Tags.Add(tag);

                    return post;
                }, splitOn: "Id");

            return posts;
        }
    }
}
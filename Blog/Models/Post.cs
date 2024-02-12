using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[Post]")]
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }

        // public int CategoryId { get; set; }
    }
}
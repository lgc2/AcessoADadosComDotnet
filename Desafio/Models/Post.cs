using Dapper.Contrib.Extensions;

namespace Desafio.Models
{
    [Table("[Post]")]
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }

        // public int CategoryId { get; set; }
    }
}
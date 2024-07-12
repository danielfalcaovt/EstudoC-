using Blog.Models;
using Blog.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Data
{
    public class PostController
    {
        public void CreatePost(SqlConnection connection)
        {
            var post = new Post();
            var fields = new[] {
                "Title",
                "Summary",
                "Body",
                "Slug"
            };
            foreach (var field in fields)
            {
                Console.WriteLine($"{field}:");
                var value = Console.ReadLine();
                var property = typeof(Post).GetProperty(field);
                if (property != null)
                {
                    property.SetValue(post, value);
                }
                else
                {
                    Console.WriteLine(property);
                };
            }
            Console.WriteLine("CategoryId:");
            post.CategoryId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("AuthorId:");
            post.AuthorId = Convert.ToInt32(Console.ReadLine());
            post.CreateDate = DateTime.Now;
            post.LastUpdateDate = DateTime.Now;
            var repository = new Repository<Post>(connection);
            repository.Create(post);
        }
    
        public void VincularPost(SqlConnection connection)
        {
            var postTag = new PostTag();
            var fields = new[] {
                "PostId",
                "TagId"
            };
            foreach (var field in fields)
            {
                Console.WriteLine($"{field}:");
                var value = Convert.ToInt32(Console.ReadLine());
                var property = typeof(PostTag).GetProperty(field);
                if (property != null)
                {
                    property.SetValue(postTag, value);
                }
                else
                {
                    Console.WriteLine(property);
                };
            }
            var sql = "INSERT INTO [PostTag] VALUES(@PostId, @TagId)";
            connection.Execute(sql, new {
                PostId = postTag.PostId,
                TagId = postTag.TagId
            });
        }
    }
}
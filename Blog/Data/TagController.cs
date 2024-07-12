using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Data
{
    public class TagController
    {
        public void CreateTag(SqlConnection connection)
        {
            var tag = new Tag();
            var fields = new[] {
                "Name",
                "Slug"
            };
            foreach (var field in fields)
            {
                Console.WriteLine($"{field}:");
                var value = Console.ReadLine();
                var property = typeof(Tag).GetProperty(field);
                if (property != null)
                {
                    property.SetValue(tag, value);
                }
                else
                {
                    Console.WriteLine(property);
                };
            }
            var repository = new Repository<Tag>(connection);
            repository.Create(tag);
        }
    }
}
using Blog.Models;
using Blog.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Data
{
    public class CategoryController
    {
        public void CreateCategory(SqlConnection connection)
        {
            var category = new Category();
            var fields = new[] {
                "Name",
                "Slug"
            };
            foreach (var field in fields)
            {
                Console.WriteLine($"{field}:");
                var value = Console.ReadLine();
                var property = typeof(Category).GetProperty(field);
                if (property != null)
                {
                    property.SetValue(category, value);
                }
                else
                {
                    Console.WriteLine(property);
                };
            }
            var repository = new Repository<Category>(connection);
            repository.Create(category);
        }
        public void ListCategories(SqlConnection connection)
        {
            var repository = new Repository<Category>(connection);
            var sql = @"
                SELECT Category.Name, COUNT([Post].[CategoryId]) AS Posts FROM [Category]
                INNER JOIN [Post] ON [Category].[Id] = [Post].[CategoryId]
                GROUP BY [Category].[Name]";
            var categories = connection.Query(sql);
            foreach (var category in categories)
            {
                Console.WriteLine($"{category.Name} - {category.Posts}");
            }
        }
    }

}
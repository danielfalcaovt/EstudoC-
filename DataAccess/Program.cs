using Microsoft.Data.SqlClient;
using Dapper;
using DataAccess.Models;

namespace DataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost, 1433;Database=balta;User ID=sa;Password=Brbr109br@;Trusted_Connection=False; TrustServerCertificate=True;";
            using (var connection = new SqlConnection(connectionString))
            {
                /* ListCategories(connection); */
                /* CreateCategory(connection); */
                /* UpdateCategory(connection); */
                /* DeleteCategory(connection); */
                /* CreateManyCategories(connection); */
                ExecuteProcedure procedures = new ExecuteProcedure(connection);
                /* procedures.spDeleteStudent(); */
                procedures.spGetCoursesByCategory();
            }
        }

        static void ListCategories(SqlConnection connection)
        {
            var categories = connection.Query<Category>("SELECT * FROM [Category]");
            foreach (var category in categories)
            {
                Console.WriteLine(category.Id);
                Console.WriteLine(category.Title);
            }
        }

        static void CreateCategory(SqlConnection connection)
        {
            Category category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Frontend";
            category.Url = "mobile";
            category.Summary = "Teste";
            category.Order = 5;
            category.Description = "jaisdjasd";
            category.Featured = false;

            var InsertSql = "INSERT INTO [Category] VALUES (@id, @title, @url, @summary, @order, @description, @featured)";
            var rows = connection.Execute(InsertSql, new {
                id = category.Id,
                title = category.Title,
                url = category.Url,
                summary = category.Summary,
                order = category.Order,
                description = category.Description,
                featured = category.Featured
            });
            Console.WriteLine(category.AffectedRowsHelper(rows));
        }
        static void UpdateCategory(SqlConnection connection)
        {
            Category category = new Category();
            category.Id = new Guid("b621253e-24de-479b-b5ec-5c5ea967883a");
            category.Title = "Frontend";
            category.Url = "mobile";
            category.Summary = "monkey";
            category.Order = 5;
            category.Description = "jaisdjasd";
            category.Featured = false;

            string UpdateSql = "UPDATE [Category] SET [Title] = @title, [Url]= @url, [Summary] = @summary, [Order] = @order, [Featured] = @featured WHERE [Id] = @id";
            var rows = connection.Execute(UpdateSql, new {
                id = category.Id,
                title = category.Title,
                url = category.Url,
                summary = category.Summary,
                order = category.Order,
                featured = category.Featured
            });
            Console.WriteLine($"{rows} registros afetados.");
        }
        static void DeleteCategory(SqlConnection connection)
        {
            string SqlDelete = "DELETE FROM [Category] WHERE [Id] = @id";
            var rows = connection.Execute(SqlDelete, new {
                id = "b621253e-24de-479b-b5ec-5c5ea967883a"
            });
        Console.WriteLine(new Category().AffectedRowsHelper(rows));
        }
        static void CreateManyCategories(SqlConnection connection)
        {
            Category category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Frontend";
            category.Url = "mobile";
            category.Summary = "Teste";
            category.Order = 5;
            category.Description = "jaisdjasd";
            category.Featured = false;
            
            Category category2 = new Category();
            category2.Id = Guid.NewGuid();
            category2.Title = "Frontend";
            category2.Url = "mobile";
            category2.Summary = "Teste";
            category2.Order = 5;
            category2.Description = "jaisdjasd";
            category2.Featured = false;

            var InsertSql = "INSERT INTO [Category] VALUES (@id, @title, @url, @summary, @order, @description, @featured)";
            var rows = connection.Execute(InsertSql, new[] {
                new 
                {
                id = category.Id,
                title = category.Title,
                url = category.Url,
                summary = category.Summary,
                order = category.Order,
                description = category.Description,
                featured = category.Featured
                },
                new
                {
                id = category2.Id,
                title = category2.Title,
                url = category2.Url,
                summary = category2.Summary,
                order = category2.Order,
                description = category2.Description,
                featured = category2.Featured
                }
            });
            Console.WriteLine(category.AffectedRowsHelper(rows));
        }
        public class ExecuteProcedure
        {
            public string procedure { get; set; }
            public SqlConnection Connection { get; set; }
            public ExecuteProcedure(SqlConnection connection)
            {
                Connection = connection;
            }
            public void spDeleteStudent()
            {
                procedure = "spDeleteStudent";
                var rows = this.Connection.Execute(
                    procedure, 
                    new { StudentId = "de6d3b13-7446-426d-8669-ce10846339b7" },
                    commandType: System.Data.CommandType.StoredProcedure
                );
                Console.WriteLine(new Category().AffectedRowsHelper(rows));
            }
            public void spGetCoursesByCategory()
            {
                procedure = "spGetCoursesByCategory";
                var courses = this.Connection.Query<Course>(
                    procedure,
                    new { CategoryId = "b4c5af73-7e02-4ff7-951c-f69ee1729cac" },
                    commandType: System.Data.CommandType.StoredProcedure
                );
                foreach (var course in courses)
                {
                    Console.WriteLine($"{course.CategoryId} - {course.Title}");
                }
            }
        }
    }
}
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
                /* ExecuteProcedure procedures = new ExecuteProcedure(connection); */
                /* procedures.spDeleteStudent(); */
                /* procedures.spGetCoursesByCategory(); */
                /* ExecuteScalar(connection); */
                /* ReadView(connection); */
                /* ListCoursesByCategories(connection); */
                /* OneToMany(connection); */
                /* LikeIn(connection); */
                Transaction(connection);
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

        static void ExecuteScalar(SqlConnection connection)
        {
            Category category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Frontend";
            category.Url = "mobile";
            category.Summary = "Teste";
            category.Order = 5;
            category.Description = "jaisdjasd";
            category.Featured = false;

            var InsertSql = "INSERT INTO [Category] OUTPUT inserted.[Id] VALUES (NEWID(), @title, @url, @summary, @order, @description, @featured)";
            var id = connection.ExecuteScalar<Guid>(InsertSql, new {
                title = category.Title,
                url = category.Url,
                summary = category.Summary,
                order = category.Order,
                description = category.Description,
                featured = category.Featured
            });
            Console.WriteLine(id);
        }

        static void ReadView(SqlConnection connection)
        {
            var categories = connection.Query<Course>("SELECT * FROM [vwCourses]");
            foreach (var category in categories)
            {
                Console.WriteLine(category.Id);
            }
        }
    
        static void ListCoursesByCategories(SqlConnection connection)
        {
            var sql = @"
                        SELECT * FROM [CareerItem]
                        INNER JOIN [Course] ON
                        [CareerItem].[CourseId] = [Course].[Id]
                        ";
            var result = connection.Query<CareerItem, Course, CareerItem>(
                sql, 
                (careerItem, course) => {
                    careerItem.Course = course;
                    return careerItem;
                    }, 
                splitOn: "Id"
                );
            foreach (var careerItem in result)
            {
                Console.WriteLine(careerItem.Title);
                Console.WriteLine(careerItem.Course.Title);
            }
        }
        static void OneToMany(SqlConnection connection)
        {
            var sql = @"
                    SELECT * FROM [Career]
                    INNER JOIN [CareerItem] ON
                    [CareerItem].[CareerId] = [Career].[Id]
                    ORDER BY [Career].[Title] ASC
            ";
            string oldResult = "";
            int count = 0;
            var careers = new List<Career>();
            Career oldCareer = new Career();
            var result = connection.Query<Career, CareerItem, Career>(
                sql,
                (career, item) => {
                    var car = careers.Where(x => x.Id == career.Id).FirstOrDefault(); // PROCURA CARREIRA COM ID IGUAL NO NOVO ARRAY
                    if (car == null) // CASO CARREIRA NAO SEJA ENCONTRADA
                    {
                        car = career; // OLD CARREIRA RECEBE CARREIRA NOVA
                        car.Items.Add(item); // ADICIONA O ITEM DESSA CARREIRA NELA
                        careers.Add(car); // ADICIONA O CARRERITEM AO CARREIRAS
                    }
                    else // CASO CARREIRA SEJA ENCONTRADA
                    {
                        car.Items.Add(item); // ADICIONA NAQUELA CARREIRA UM NOVO ITEM
                    }
                    return career;
                },
                splitOn: "CareerId"
                );
                foreach (var career in careers)
                {
                    Console.WriteLine($"{career.Title}");
                    foreach (var cItem in career.Items)
                    {
                        Console.WriteLine($"- {cItem.Title}");
                    }
                }
        }
    
        static void LikeIn(SqlConnection connection)
        {
            var query = "SELECT TOP 10 * FROM [Course] WHERE [Id] IN @Id";
            var result = connection.Query<Course>(query, new {
                Id = new[] {
                    "5c349848-e717-9a7d-1241-0e6500000000",
                    "5e4bf896-7c21-3e47-b9da-208300000000"
                }
            });
            foreach (var item in result)
            {
                Console.WriteLine(item.Title);
            }
        }

        static void Transaction(SqlConnection connection)
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
            connection.Open();
            using (var transaction = connection.BeginTransaction())
            {
                var rows = connection.Execute(InsertSql, new {
                    id = category.Id,
                    title = category.Title,
                    url = category.Url,
                    summary = category.Summary,
                    order = category.Order,
                    description = category.Description,
                    featured = category.Featured
                }, transaction);
                Console.WriteLine($"{rows} Linhas Afetadas KKK");
                transaction.Rollback();
            }
        }
    }
}
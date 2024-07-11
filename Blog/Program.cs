using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Blog.Models;
using Blog.Repositories;

namespace Blog
{
    class Program
    {
        static private string connectionString = "Server=localhost,1433;Database=Blog;User ID=sa;Password=password;Trusted_Connection=False; TrustServerCertificate=True;";
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                ReadUser(connection);
            }            
        }
        static void ReadUser(SqlConnection connection)
        {
            var repository = new UserRepository();
            var result = repository.Get(connection);
            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
            }
        }
        static void InsertUser(SqlConnection connection)
        {
            var user = new User()
            {
                Name = "Pedroca",
                Bio = "OmGiTsSoPrEtTy",
                Email = "Hello, i'm at you door again",
                PasswordHash="ASD",
                Image="YAY",
                Slug="YAY"
            };
            var result = connection.Insert<User>(user);
            Console.WriteLine($"{result} affected rows");
        }
        static void UpdateUser(SqlConnection connection)
        {
            var user = new User()
            {
                Id = 1,
                Name = "Pedroca",
                Bio = "OmGiTsSoPrEtTy",
                Email = "Hello, i'm at you door again",
                PasswordHash="ASD",
                Image="YAY",
                Slug="YAY"
            };
            var result = connection.Update<User>(user);
            Console.WriteLine($"{result} affected rows");
        }
        static void DeleteUser(SqlConnection connection)
        {
            var user = connection.Get<User>(1);
            var result = connection.Delete(user);
            Console.WriteLine($"{result} affected rows");
        }
    }
}
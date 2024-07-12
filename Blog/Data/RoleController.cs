using Blog.Models;
using Blog.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Data
{
    public class RoleController
    {
        public void CreateRole(SqlConnection connection)
        {
            var role = new Role();
            var fields = new[] {
                "Name",
                "Slug"
            };
            foreach (var field in fields)
            {
                Console.WriteLine($"{field}:");
                var value = Console.ReadLine();
                var property = typeof(Role).GetProperty(field);
                if (property != null)
                {
                    property.SetValue(role, value);
                }
                else
                {
                    Console.WriteLine(property);
                };
            }
            var repository = new Repository<Role>(connection);
            repository.Create(role);
        }
    
        public void VincularRole(SqlConnection connection)
        {
            var userRole = new UserRole();
            var fields = new[] {
                "UserId",
                "RoleId"
            };
            foreach (var field in fields)
            {
                Console.WriteLine($"{field}:");
                var value = Convert.ToInt32(Console.ReadLine());
                var property = typeof(UserRole).GetProperty(field);
                if (property != null)
                {
                    property.SetValue(userRole, value);
                }
                else
                {
                    Console.WriteLine(property);
                };
            }
            var sql = "INSERT INTO [UserRole] VALUES(@UserId, @RoleId)";
            connection.Execute(sql, new {
                UserId = userRole.UserId,
                RoleId = userRole.RoleId
            });
        }
    }
}
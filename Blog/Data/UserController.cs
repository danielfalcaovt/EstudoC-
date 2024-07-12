using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Data
{
    public class UserController
    {
        public void CreateUser(SqlConnection connection)
        {
            var user = new User();
            var fields = new[] {
                "Name",
                "Email",
                "PasswordHash",
                "Bio",
                "Image",
                "Slug"
            };
            foreach (var field in fields)
            {
                Console.WriteLine($"{field}:");
                var value = Console.ReadLine();
                var property = typeof(User).GetProperty(field);
                if (property != null)
                {
                    property.SetValue(user, value);
                }
                else
                {
                    Console.WriteLine(property);
                };
            }
            var repository = new Repository<User>(connection);
            repository.Create(user);
        }
    
        public void ListUsers(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var users = repository.GetUserWithRoles();
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Name} {user.Email} ");
                foreach (var role in user.Roles)
                {
                    Console.Write($"{role.Name}, ");
                }
            }
        }
    }
}
using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository : Repository<User>
    {
        public SqlConnection _connection { get; set; }

        public UserRepository(SqlConnection connection)
        :base(connection)
            => _connection = connection;

        public IList<User> GetUserWithRoles() 
        {
            var sql = @"SELECT [User].*, [Role].* FROM [User]
                        LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id] 
                        LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";

            var users = new List<User>();
            _connection.Query<User, Role, User>(sql, (user, role) => {
                var usr = users.FirstOrDefault(x => x.Id == user.Id);
                if (usr == null)
                {
                    usr = user;
                    if (role != null)
                    {
                        usr.Roles.Add(role);
                    }
                    users.Add(usr);
                }
                else
                {
                    usr.Roles.Add(role);
                }
                return user;
            }, splitOn: "Id");
            return users;   
        }
    }
}
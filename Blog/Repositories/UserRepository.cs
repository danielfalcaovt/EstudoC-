using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository
    {
        public IEnumerable<User> Get(SqlConnection connection)
        {
            return connection.GetAll<User>();

        }
    }
}
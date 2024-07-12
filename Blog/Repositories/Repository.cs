using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class Repository<T> where T : Model
    {
        public SqlConnection _connection { get; set; }

        public Repository(SqlConnection connection)
            => _connection = connection;

        public IEnumerable<T> GetAll()
            => _connection.GetAll<T>();

        public T Get(int Id)
            => _connection.Get<T>(Id);

        public void Create(T models)
        {
            models.Id = 0;
            _connection.Insert<T>(models);
        }

        public void Update(T models)
        {
            if (models.Id != 0)
            {
                _connection.Update<T>(models);
            }
        }
        
        public void Delete(T models)
        {
            if (models.Id != 0)
            {
                _connection.Delete<T>(models);
            }
        }

        public void Delete(int Id)
        {
            if (Id != 0)
            {
                var models = _connection.Get<T>(Id);
                _connection.Delete<T>(models);
            }
        }
    }
}
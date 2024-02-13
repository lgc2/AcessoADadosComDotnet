using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Desafio.Repositories
{
    public class Repository<T> where T : class
    {
        public Repository(SqlConnection connection)
            => _connection = connection;

        private readonly SqlConnection _connection;

        public IEnumerable<T> Get()
            => _connection.GetAll<T>();

        public T Get(int id)
            => _connection.Get<T>(id);

        public long Create(T model)
            => _connection.Insert<T>(model);

        public bool Update(T model)
            => _connection.Update<T>(model);

        public bool Delete(T model)
            => _connection.Delete<T>(model);

        public bool Delete(int id)
        {
            var model = _connection.Get<T>(id);
            return _connection.Delete<T>(model);
        }
    }
}
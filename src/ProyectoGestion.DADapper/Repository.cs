using System.Collections.Generic;
using ProyectoGestion.Repository;
using Dapper.Contrib.Extensions;
using System.Data.SqlClient;

namespace ProyectoGestion.DADapper
{
    public class Repository<I>: IRepository<I> where I:class
    {
        protected readonly string _connectionString;
        public Repository(string connectionString) {
            SqlMapperExtensions.TableNameMapper = (type) =>
            {
                return $"{type.Name}";
            };
            _connectionString = connectionString;
        }
        public int Delete(I entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Delete(entity) ? 1 : 0;
            }
        }
        public I GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Get<I>(id);
            }
        }
        public IEnumerable<I> GetList()
        {
            using (var connection = new SqlConnection(_connectionString))
            {return connection.GetAll<I>();}
        }
        public int Insert(I entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return (int)connection.Insert(entity);
            }
        }
        public int Update(I entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Update(entity) ? 1 : 0 ;
            }
        }
    }
}

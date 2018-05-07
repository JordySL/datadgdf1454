using Dapper;
using ProyectoGestion.Models;
using ProyectoGestion.Repository;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoGestion.DADapper
{
    public class UserRepository : Repository<Users>, IUserRepository
    {
        public UserRepository(string connectionString) : base(connectionString){ }
        public IEnumerable<Users> Autenticacion(string nombre,string clave)
        {
            var auten = new
            {
                nom = nombre,
                cla = clave
            };
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Users>("Autenticacion", auten, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

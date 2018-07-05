using Dapper;
using ProyectoGestion.Models.Entity;
using ProyectoGestion.Repository;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ProyectoGestion.DADapper
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(string connectionString) : base(connectionString)
        {
        }
        public List<Usuario> GetList()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "select * from Usuario";
                List<Usuario> datalist = SqlMapper.Query<Usuario>(connection, sql).ToList();
                return datalist.ToList();
            }
        }
    }
}

using Dapper;
using ProyectoGestion.Models.Entity;
using ProyectoGestion.Repository;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ProyectoGestion.DADapper
{
    public class UserAccountRepository : Repository<UserAccount>, IUserAccountRepository
    {
        public UserAccountRepository(string connectionString) : base(connectionString)
        {
        }
        public List<UserAccount> GetList()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "select * from UserAccount";
                List<UserAccount> datalist = SqlMapper.Query<UserAccount>(connection, sql).ToList();
                return datalist.ToList();
            }

        }
    }
}

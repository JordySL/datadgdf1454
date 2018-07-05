using Dapper;
using ProyectoGestion.Models.EntityForm;
using ProyectoGestion.Repository;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ProyectoGestion.DADapper
{
    public class UserAccountPhotoRepository : Repository<UserAccountPhoto>, IUserAccountPhotoRepository
    {
        public UserAccountPhotoRepository(string connectionString) : base(connectionString)
        {
        }
        public List<UserAccountPhoto> GetList()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "select * from UserAccountPhoto";
                List<UserAccountPhoto> datalist = SqlMapper.Query<UserAccountPhoto>(connection, sql).ToList();
                return datalist.ToList();
            }

        }
    }
}

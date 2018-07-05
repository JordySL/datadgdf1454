using Dapper;
using ProyectoGestion.Models.Entity;
using ProyectoGestion.Models.EntityForm;
using ProyectoGestion.Repository;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ProyectoGestion.DADapper
{
    public class UserPhotoRepository : Repository<UserPhoto>, IUserPhotoRepository
    {
        public UserPhotoRepository(string connectionString) : base(connectionString)
        {
        }
        public List<UserPhoto> GetList()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "select * from UserPhoto";
                List<UserPhoto> datalist = SqlMapper.Query<UserPhoto>(connection, sql).ToList();
                return datalist.ToList();
            }
        }
    }
}

using ProyectoGestion.Models.EntityForm;
using ProyectoGestion.Repository;

namespace ProyectoGestion.DADapper
{
    public class UserAccountPhotoRepository : Repository<UserAccountPhoto>, IUserAccountPhotoRepository
    {
        public UserAccountPhotoRepository(string connectionString) : base(connectionString)
        {
        }
    }
}

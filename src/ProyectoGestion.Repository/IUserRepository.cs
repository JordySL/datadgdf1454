using ProyectoGestion.Models.Entity;
using ProyectoGestion.Models.EntityForm;
using System.Collections.Generic;

namespace ProyectoGestion.Repository
{
    public interface IUserAccountPhotoRepository : IRepository<UserAccountPhoto>
    {
        List<UserAccountPhoto> GetList();
    }
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        List<Usuario> GetList();
    }
    public interface IUserAccountRepository : IRepository<UserAccount>
    {
        List<UserAccount> GetList();
    }
    public interface IUserPhotoRepository : IRepository<UserPhoto>
    {
        List<UserPhoto> GetList();
    }
}

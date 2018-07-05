using ProyectoGestion.Repository;

namespace ProyectoGestion.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserAccountPhotoRepository useraccountphoto { get; }
        IUsuarioRepository usuario { get; }
        IUserAccountRepository useraccount { get; }
        IUserPhotoRepository userphoto { get; }
    }
}

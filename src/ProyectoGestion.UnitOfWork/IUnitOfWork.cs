using ProyectoGestion.Repository;

namespace ProyectoGestion.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserAccountPhotoRepository useraccountphoto { get; }
    }
}

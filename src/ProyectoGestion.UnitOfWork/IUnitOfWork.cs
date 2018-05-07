using ProyectoGestion.Repository;

namespace ProyectoGestion.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository users { get; }
    }
}

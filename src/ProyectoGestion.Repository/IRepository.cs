using System.Collections.Generic;

namespace ProyectoGestion.Repository
{
    public interface IRepository<I> where I :class
    {
        int Insert(I entity);
        int Delete(I entity);
        int Update(I entity);
        IEnumerable<I> GetAll();
        I GetById(int id);
    }
}

using ProyectoGestion.Models;
using System.Collections.Generic;

namespace ProyectoGestion.Repository
{
    public interface IUserRepository : IRepository<Users>
    {
        IEnumerable<Users> Autenticacion(string nombre, string clave);
    }
}

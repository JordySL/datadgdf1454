using System;
using ProyectoGestion.Models;
using ProyectoGestion.Repository;
using ProyectoGestion.UnitOfWork;

namespace ProyectoGestion.DADapper
{
    public class ProyectoGestionUnitOfWork : IUnitOfWork
    {
        public ProyectoGestionUnitOfWork(string connectionString)
        {
            //obj = new ObJRepository (connectionString);
            users = new UserRepository (connectionString);
        }
        //public IObjRepository obj{get;private set;}
        public IUserRepository users { get; private set; }
    }
}

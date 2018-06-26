using ProyectoGestion.Repository;
using ProyectoGestion.UnitOfWork;
using ProyectoGestion.Models.EntityForm;

namespace ProyectoGestion.DADapper
{
    public class ProyectoGestionUnitOfWork : IUnitOfWork
    {
        public ProyectoGestionUnitOfWork(string connectionString)
        {
            //obj = new ObJRepository (connectionString);
            useraccountphoto = new UserAccountPhotoRepository(connectionString);
        }
        public IUserAccountPhotoRepository useraccountphoto
        {
            get; private set;
        }

        //public IObjRepository obj{get;private set;}
    }
}

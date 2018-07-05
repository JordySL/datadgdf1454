using ProyectoGestion.Repository;
using ProyectoGestion.UnitOfWork;
using ProyectoGestion.Models.EntityForm;

namespace ProyectoGestion.DADapper
{
    public class WebUnitOfWork : IUnitOfWork
    {
        public WebUnitOfWork(string connectionString)
        {
            //obj = new ObJRepository (connectionString);
            useraccountphoto = new UserAccountPhotoRepository(connectionString);
            usuario = new UsuarioRepository(connectionString);
            useraccount = new UserAccountRepository(connectionString);
            userphoto = new UserPhotoRepository(connectionString);
        }
        public IUserAccountPhotoRepository useraccountphoto {get; private set;}
        public IUsuarioRepository usuario { get; private set; }
        public IUserAccountRepository useraccount { get; private set; }
        public IUserPhotoRepository userphoto { get; private set; }
        //public IObjRepository obj{get;private set;}
    }
}

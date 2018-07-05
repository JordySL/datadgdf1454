using ProyectoGestion.Models.Entity;
using ProyectoGestion.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGestion.Business
{
    public interface IUsuarioBusiness
    {
        IEnumerable<Usuario> GetAllUsuario();
        List<Usuario> GetListUsuario();
        Usuario GetUsuario(int id);
        int InsertUsuario(Usuario Usuario);
        int DeleteUsuario(Usuario Usuario);
        int UpdateUsuario(Usuario Usuario);

    }
    public class UsuarioBusiness : IUsuarioBusiness
    {
        private readonly IUnitOfWork _unitofWork;
        public UsuarioBusiness(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public int DeleteUsuario(Usuario Usuario)
        {
            return _unitofWork.usuario.Delete(Usuario);
        }
        public IEnumerable<Usuario> GetAllUsuario()
        {
            return _unitofWork.usuario.GetAll();
        }
        public List<Usuario> GetListUsuario()
        {
            return _unitofWork.usuario.GetList();
        }
        public Usuario GetUsuario(int id)
        {
            return _unitofWork.usuario.GetById(id);
        }
        public int InsertUsuario(Usuario Usuario)
        {
            return _unitofWork.usuario.Insert(Usuario);
        }
        public int UpdateUsuario(Usuario Usuario)
        {
            return _unitofWork.usuario.Update(Usuario);
        }
    }
}

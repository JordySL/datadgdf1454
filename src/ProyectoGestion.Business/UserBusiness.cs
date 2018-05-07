using ProyectoGestion.Models;
using System.Collections.Generic;
using ProyectoGestion.UnitOfWork;
using System;

namespace ProyectoGestion.Business
{
    public interface IUserBusiness 
    {
        IEnumerable<Users> GetUsers();
        IEnumerable<Users> Autenticacion(string nombre, string clave);
    }
    public class UserBusiness : IUserBusiness
    {
        private readonly IUnitOfWork _unitofWork;
        public UserBusiness(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public IEnumerable<Users> GetUsers()
        {
            return _unitofWork.users.GetList();
        }
        public IEnumerable<Users> Autenticacion(string nombre, string clave)
        {
            return _unitofWork.users.Autenticacion(nombre, clave);
        }
    }
}

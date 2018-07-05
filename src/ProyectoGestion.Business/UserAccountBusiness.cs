using ProyectoGestion.Models.Entity;
using ProyectoGestion.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGestion.Business
{
    public interface IUserAccountBusiness
    {
        IEnumerable<UserAccount> GetAllUserAccount();
        List<UserAccount> GetListUserAccount();
        UserAccount GetUserAccount(int id);
        int InsertUserAccount(UserAccount UserAccount);
        int DeleteUserAccount(UserAccount UserAccount);
        int UpdateUserAccount(UserAccount UserAccount);

    }
    public class UserAccountBusiness : IUserAccountBusiness
    {
        private readonly IUnitOfWork _unitofWork;
        public UserAccountBusiness(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public int DeleteUserAccount(UserAccount UserAccount)
        {
            return _unitofWork.useraccount.Delete(UserAccount);
        }

        public IEnumerable<UserAccount> GetAllUserAccount()
        {
            return _unitofWork.useraccount.GetAll();
        }

        public List<UserAccount> GetListUserAccount()
        {
            return _unitofWork.useraccount.GetList();
        }

        public UserAccount GetUserAccount(int id)
        {
            return _unitofWork.useraccount.GetById(id);
        }

        public int InsertUserAccount(UserAccount UserAccount)
        {
            return _unitofWork.useraccount.Insert(UserAccount);
        }

        public int UpdateUserAccount(UserAccount UserAccount)
        {
            return _unitofWork.useraccount.Update(UserAccount);
        }
    }
}

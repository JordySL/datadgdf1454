using System.Collections.Generic;
using ProyectoGestion.UnitOfWork;
using ProyectoGestion.Models.EntityForm;
using ProyectoGestion.Models.Entity;
using System;

namespace ProyectoGestion.Business
{
    public interface IUserAccountPhotoBusiness
    {
        IEnumerable<UserAccountPhoto> GetAllUserAccountPhoto();
        List<UserAccountPhoto> GetListUserAccountPhoto();
        UserAccountPhoto GetUserAccountPhoto(int id);
        int InsertUserAccountPhoto(UserAccountPhoto UserAccountPhoto);
        int DeleteUserAccountPhoto(UserAccountPhoto UserAccountPhoto);
        int UpdateUserAccountPhoto(UserAccountPhoto UserAccountPhoto);

    }
    public class UserAccountPhotoBusiness : IUserAccountPhotoBusiness
    {
        private readonly IUnitOfWork _unitofWork;
        public UserAccountPhotoBusiness(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public int DeleteUserAccountPhoto(UserAccountPhoto UserAccountPhoto)
        {
            return _unitofWork.useraccountphoto.Delete(UserAccountPhoto);
        }

        public IEnumerable<UserAccountPhoto> GetAllUserAccountPhoto()
        {
            return _unitofWork.useraccountphoto.GetAll();
        }

        public List<UserAccountPhoto> GetListUserAccountPhoto()
        {
            return _unitofWork.useraccountphoto.GetList();
        }

        public UserAccountPhoto GetUserAccountPhoto(int id)
        {
            return _unitofWork.useraccountphoto.GetById(id);
        }

        public int InsertUserAccountPhoto(UserAccountPhoto UserAccountPhoto)
        {
            return _unitofWork.useraccountphoto.Insert(UserAccountPhoto);
        }

        public int UpdateUserAccountPhoto(UserAccountPhoto UserAccountPhoto)
        {
            return _unitofWork.useraccountphoto.Update(UserAccountPhoto);
        }
    }
}

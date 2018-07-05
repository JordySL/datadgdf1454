using ProyectoGestion.Models.Entity;
using ProyectoGestion.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGestion.Business
{
    public interface IUserPhotoBusiness
    {
        IEnumerable<UserPhoto> GetAllUserPhoto();
        List<UserPhoto> GetListUserPhoto();
        UserPhoto GetUserPhoto(int id);
        int InsertUserPhoto(UserPhoto UserPhoto);
        int DeleteUserPhoto(UserPhoto UserPhoto);
        int UpdateUserPhoto(UserPhoto UserPhoto);

    }
    public class UserPhotoBusiness : IUserPhotoBusiness
    {
        private readonly IUnitOfWork _unitofWork;
        public UserPhotoBusiness(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public int DeleteUserPhoto(UserPhoto UserPhoto)
        {
            return _unitofWork.userphoto.Delete(UserPhoto);
        }

        public IEnumerable<UserPhoto> GetAllUserPhoto()
        {
            return _unitofWork.userphoto.GetAll();
        }

        public List<UserPhoto> GetListUserPhoto()
        {
            return _unitofWork.userphoto.GetList();
        }

        public UserPhoto GetUserPhoto(int id)
        {
            return _unitofWork.userphoto.GetById(id);
        }

        public int InsertUserPhoto(UserPhoto UserPhoto)
        {
            return _unitofWork.userphoto.Insert(UserPhoto);
        }


        public int UpdateUserPhoto(UserPhoto UserPhoto)
        {
            return _unitofWork.userphoto.Update(UserPhoto);
        }
    }
}

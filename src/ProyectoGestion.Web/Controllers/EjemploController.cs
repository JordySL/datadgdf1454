using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoGestion.Business;
using ProyectoGestion.Models.Entity;
using ProyectoGestion.Models.EntityForm;
using System.Collections.Generic;

namespace ProyectoGestion.Web.Controllers
{
    public class EjemploController : Controller
    {
        private IUserAccountPhotoBusiness _useraccountphotoBusiness;
        private IUserAccountBusiness _useraccountBusiness;
        private IUserPhotoBusiness _userphotoBusiness;
        private IUsuarioBusiness _usuarioBusiness;
        public EjemploController(IUserAccountPhotoBusiness useraccountphotoBusiness
                                ,IUsuarioBusiness usuarioBusiness
                                ,IUserPhotoBusiness userphotoBusiness
                                ,IUserAccountBusiness useraccountBusiness)
        {
            _useraccountphotoBusiness = useraccountphotoBusiness;
            _usuarioBusiness = usuarioBusiness;
            _userphotoBusiness = userphotoBusiness;
            _useraccountBusiness = useraccountBusiness;
        }
        public ActionResult Index()
        {
            List<Usuario> Usuario = new List<Usuario>();
            List<UserAccount> UserAccount = new List<UserAccount>();
            List<UserPhoto> UserPhoto = new List<UserPhoto>();
            UserAccountPhoto data = new UserAccountPhoto();
            List<UserAccountPhoto> dataList = new List<UserAccountPhoto>();
            Usuario = _usuarioBusiness.GetListUsuario();
            UserAccount = _useraccountBusiness.GetListUserAccount();
            UserPhoto = _userphotoBusiness.GetListUserPhoto();
            
            for (int x = 0; x < UserPhoto.Count; x++)
            {
                data = new UserAccountPhoto();
                data.IDKey = UserPhoto[x].IDKey;
                data.Photo = UserPhoto[x].Photo;
                for (int i = 0; i < Usuario.Count; i++)
                {
                    data.ID = Usuario[i].ID;
                    data.Name = Usuario[i].Name;
                    data.LastName = Usuario[i].LastName;
                    data.UserName = UserAccount[i].UserName;
                    data.Password = UserAccount[i].Password;
                }
                dataList.Add(data);
            }
            return View(dataList);
        }
        public ActionResult Create()
        {
            return View( new UserAccountPhoto());
        }
        public ActionResult Edit(int id)
        {
            Usuario Usuario = new Usuario();
            UserAccount UserAccount = new UserAccount();
            UserPhoto UserPhoto = new UserPhoto();
            UserAccountPhoto data = new UserAccountPhoto();
            List<UserAccountPhoto> dataList = new List<UserAccountPhoto>();
            Usuario = _usuarioBusiness.GetUsuario(id);
            UserAccount = _useraccountBusiness.GetUserAccount(id);
            //UserPhoto = _userphotoBusiness.GetUserPhoto(id);
            data.ID = Usuario.ID;
            data.Name = Usuario.Name;
            data.LastName = Usuario.LastName;
            data.UserName = UserAccount.UserName;
            data.Password = UserAccount.Password;
            return View(data);
        }    
        public ActionResult Delete(int id)
        {
            var data = _useraccountphotoBusiness.GetUserAccountPhoto(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Create(UserAccountPhoto UserAccountPhoto)
        {
            try
            {
                Usuario Usuario = new Usuario();
                UserAccount UserAccount = new UserAccount();
                UserPhoto UserPhoto = new UserPhoto();
                List<UserPhoto> UserPhotoList = new List<UserPhoto>();
                List<UserAccountPhoto> dataList = new List<UserAccountPhoto>();

           for (int x = 0; x < UserAccountPhoto.PhotoList.Count; x++)
                {
                    UserPhoto = new UserPhoto();
                    UserPhoto.Photo = UserAccountPhoto.PhotoList[x];
                    for (int i = 0; i < UserAccountPhoto.UserNameList.Count; i++)
                    {
                        Usuario.ID = UserAccountPhoto.ID;
                        Usuario.Name = UserAccountPhoto.Name;
                        Usuario.LastName = UserAccountPhoto.LastName;
                        UserAccount.UserName = UserAccountPhoto.UserNameList[i];
                        UserAccount.Password = UserAccountPhoto.Password;
                    }
                    UserPhotoList.Add(UserPhoto);
                }
                _usuarioBusiness.InsertUsuario(Usuario);
                _useraccountBusiness.InsertUserAccount(UserAccount);
                _userphotoBusiness.InsertUserPhoto(UserPhoto);              
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Edit(UserAccountPhoto UserAccountPhoto)
        {
            try
            {
                _useraccountphotoBusiness.UpdateUserAccountPhoto(UserAccountPhoto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Delete(UserAccountPhoto UserAccountPhoto)
        {
            try
            {
                _useraccountphotoBusiness.DeleteUserAccountPhoto(UserAccountPhoto);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
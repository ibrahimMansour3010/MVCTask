using Day_5_Assignment.Extensions;
using Day_5_Assignment.Filters;
using Model;
using PagedList;
using PagedList.Mvc;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;
using ViewModels.Users;

namespace Day_5_Assignment.Controllers
{
    public class UserController : Controller
    {
        IUniteOfWork uniteOfWork;
        IMainRepo<User> UserRepo;
        IMainRepo<Token> TokenRepo;
        public UserController(IUniteOfWork uniteOfWork)
        {
            ViewBag.Title = "Index";

            this.uniteOfWork = uniteOfWork;
            UserRepo = this.uniteOfWork.GetUserRepo();
            TokenRepo = this.uniteOfWork.GetTokenRepo();
        }
        // ascending
        static bool flag = true;
        // GET: User
        [HttpGet]
        [UsernameFilter]
        public ActionResult Index(int? PageNumber,string PropertyName)
        {
            ViewBag.Title = "Index";
            if (Session["username"] == null)
                return RedirectToAction("Login");
            int id = (int)Session["userID"];
            IEnumerable<UserViewModel> Users ;
            if(PropertyName == null)
                Users = uniteOfWork.GetUserRepo().GetAll().ToList().Select(i => i.ToModel()).Where(i=> i.ID != id);
            else
            {
                if (flag)
                {
                    Users = uniteOfWork.GetUserRepo().GetAll().OrderByByPropertyName(PropertyName).ToList().Select(i => i.ToModel()).Where(i => i.ID != id);
                    flag = false;
                }
                else
                {
                    Users = uniteOfWork.GetUserRepo().GetAll().OrderByDescendingByPropertyName(PropertyName).ToList().Select(i => i.ToModel()).Where(i => i.ID != id);
                    flag = true;
                }
            }
            return View(Users.ToPagedList(PageNumber ?? 1, 3));
            //return View(Users);
        }
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Title = "Login";
            return View();
        }
        
        [HttpGet]
        public ActionResult Logout()
        {
            Session["username"] = null;
            return RedirectToAction("Login");

        }

        [HttpPost]
        public ActionResult Login(UserLoginModel userLoginModel)
        {
            User SelectedUser = uniteOfWork.GetUserRepo().GetAll().Where(u => u.Username == userLoginModel.Username
            && u.Password == userLoginModel.Password).FirstOrDefault();
            if (SelectedUser == null)
                return View();
            Session["username"] = userLoginModel.Username;
            Session["Firstname"] = SelectedUser.Firstname;
            Session["userID"] = SelectedUser.ID;
            return RedirectToAction("Index");
        }
        [HttpPost]
        [UsernameFilter]
        public ActionResult Add(UserAddModel model)
        {
            uniteOfWork.GetUserRepo().Add(model.ToUser());
            uniteOfWork.save();
            return View();
        }
        
        [HttpGet]
        [UsernameFilter]
        public ActionResult Delete(int id)
        {
            UserRepo.Delete(new User() { ID = id});
            uniteOfWork.save();
            IEnumerable<UserViewModel> Users = uniteOfWork.GetUserRepo().GetAll().ToList().Select(i => i.ToModel()).Where(i => i.ID != id); ;

            return PartialView("_UsersData", Users);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserAddModel userAddModel)
        {
            UserRepo.Add(userAddModel.ToUser());
            TokenRepo.Add(new Token() { User_id = userAddModel.ToUser().ID, Code = Guid.NewGuid().ToString() });
            uniteOfWork.save();
            return Redirect("/User/Login");
        }
        [HttpGet]
        [UsernameFilter]
        public ActionResult Details(int id)
        {
            ViewBag.Title = "Details";
            User user = UserRepo.GetById(id);
            return View(user);
        }
        [HttpGet]
        [UsernameFilter]
        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit";
            User user = UserRepo.GetById(id) ;
            return View(user);
        }
        [HttpPost]
        [UsernameFilter]
        public ActionResult Edit(User user)
        {

            UserRepo.Edit(user) ;
            uniteOfWork.save();
            return Redirect("/User/Index");
        }
        [HttpPost]
        [UsernameFilter]
        public ActionResult Search(UserSearchModel userSearchModel)
        {

            int id = (int)Session["userID"];
            IEnumerable<UserViewModel> Users = uniteOfWork.GetUserRepo().GetAll().Where(i => i.ID != id &&
            ((i.ID == (userSearchModel.ID ?? i.ID))
            && (i.Email == (userSearchModel.Email ?? i.Email))
            && (i.Phone == (userSearchModel.Phone ?? i.Phone)))).ToList().Select(i => i.ToModel());
            return PartialView("_UsersData",Users.ToPagedList(1,3));
        }

    }
}
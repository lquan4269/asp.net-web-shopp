using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;

namespace web.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        Model1 db = new Model1();

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel usr)
        {
        
            if (ModelState.IsValid) // kiểm tra xem mô hình có hợp lệ cho cơ sở dư liệu không
            {
                UserManager mg = new UserManager();
                if (mg.CheckUserName(usr.UserName) && mg.CheckEmail(usr.Email))
                {
                    User user = new User();
                        user.UserName = usr.UserName;
                        user.Email = usr.Email;
                        user.Password = Encrypt.MD5Hash(usr.Password);
                        user.Phone = usr.Phone;
                        user.Adress = usr.Adress;
                    db.Users.Add(user); //thêm mới danh sách trên dataset
                    db.SaveChanges(); //cập nhật vào database
                    return RedirectToAction("Index", "Home");
                    // Success

                }
                else
                {
                    //view regiter nay khong ton tai ten no loi. 
                    ModelState.AddModelError("Register", "UserName is existed");
                    return View(); 
                }
            }
                
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                UserManager mg = new UserManager();
                if (mg.CheckLogin(user.Email, user.Password))
                {
                    //Nên lưu Session thay vì gọi database vì tốn thời gian
                    //Lưu User
                    Session["user"] = user.Email;
                    return RedirectToAction("Index", "Home");
                }
                else {
                    ViewBag.Error = "Please enter your UserName and Password";
                    return View();
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Index","Home");
        }


    }
}
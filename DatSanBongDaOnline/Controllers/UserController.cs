using DatSanBongDaOnline.Areas.Admin.Models;
using DatSanBongDaOnline.Common;
using DatSanBongDaOnline.Controllers;
using DatSanBongDaOnline.Models;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatSanBongDaOnline.Controllers
{
    public class UserController : Controller
    {
        DatSanBongDaDbContext db = new DatSanBongDaDbContext();
        // GET: User
       [HttpGet]       
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {

            return View();
        }
        public ActionResult Logout()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                string sEmail = model.Email;
                string sMatKhau = model.Password;
                khachhang tv = db.khachhangs.SingleOrDefault(n => n.Email == sEmail && n.Password == sMatKhau);
                if (tv != null)
                {
                    Session["TaiKhoan"] = tv;
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập không đúng");
                }
            }
            return View(model);
        }
        public ActionResult Register(khachhang model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.CheckUserName(model.Ten))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var user = new khachhang();
                    user.MaKH = model.MaKH;
                    user.Email = model.Email;
                    user.Password = model.Password;
                    user.Ho = model.Ho;
                    user.Ten = model.Email;
                    user.DiaChi = model.DiaChi;
                    user.SDT = model.SDT;
                    if (!string.IsNullOrEmpty(model.Password))
                    {
                        user.Password = user.Password;
                    }

                    var result = dao.Insert(user);
                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new khachhang();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công.");
                    }
                }
            }
            return View(model);
        }
    }
}

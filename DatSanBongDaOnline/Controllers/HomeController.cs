using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatSanBongDaOnline.Controllers
{
    public class HomeController : Controller
    {
        DatSanBongDaDbContext db = new DatSanBongDaDbContext();
        // GET: Home
        [HttpGet]
        public ActionResult Index( )
        {

            ViewBag.Slides = new SlideDao().ListAll();
            var sanDao = new SanDao();
            ViewBag.NewProducts = sanDao.ListNewProduct();            
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        //Tạo action đăng nhập
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(CustomerLoginModel f)
        {
            //kiểm tra tên đăng nhập và MK
            if (ModelState.IsValid)
            {
                string sEmail = f.Email;
                string sMatKhau = f.Password;
                khachhang tv = db.khachhangs.SingleOrDefault(n => n.Email == sEmail && n.Password == sMatKhau);
                if (tv != null)
                {
                    Session["TaiKhoan"] = tv;
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Username or password incorrect");
                }
            }
            return View(f);
        }
        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index");
        }
        //Đăng ký
        [HttpGet]
        public ActionResult DangKy()
        {
            // setViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(khachhang tv, FormCollection f)
        {
            //Kiểm tra captcha hợp lệ
            if (ModelState.IsValid)
            {
                ViewBag.ThongBao = "Thêm thành công";
                //Thêm khách hàng vào csdl
                db.khachhangs.Add(tv);
                db.SaveChanges();
            }
            else
            {
                ViewBag.ThongBao = "Thêm thất bại";
            }
            return View();
        }
    }
}
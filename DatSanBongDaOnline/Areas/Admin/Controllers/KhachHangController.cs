using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatSanBongDaOnline.Areas.Admin.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: Admin/KhachHang
        public ActionResult Index(string searchString, int page = 1, int pageSize = 4)
        {
            var dao = new KhachHangDao();
            var model = dao.ListAllPaging(searchString,page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int makh)
        {
            var khachhang = new KhachHangDao().ViewDetail(makh);
            return View(khachhang);
        }
        public ActionResult Edit(khachhang khachhang)
        {
            if (ModelState.IsValid)
            {
                var dao = new KhachHangDao();
                if (!string.IsNullOrEmpty(khachhang.Ho))
                {
                    khachhang.Ho = khachhang.Ho;
                }
                var result = dao.Update(khachhang);
                if (result)
                {
                    return RedirectToAction("Index", "KhachHang");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Khách Hàng không thành công");
                }
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult Create(khachhang model)
        {
            if (ModelState.IsValid)
            {
                var dao = new KhachHangDao();
                int idnv = dao.Insert(model);
                if (idnv > 0)
                {
                    return RedirectToAction("Index", "KhachHang");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Khách hàng thành công");
                }
            }
            return View(model);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new KhachHangDao().Delete(id);

            return RedirectToAction("Index");
        }
    }
}
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatSanBongDaOnline.Areas.Admin.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: Admin/NhanVien
        public ActionResult Index(int page = 1, int pageSize = 2)
        {
            var dao = new NhanVienDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int manv)
        {
            var nhanvien = new NhanVienDao().ViewDetail(manv);
            return View(nhanvien);
        }
        [HttpPost]
        public ActionResult Create(NhanVien model)
        {
            if (ModelState.IsValid)
            {
                var dao = new NhanVienDao();
                int idnv = dao.Insert(model);
                if (idnv > 0)
                {
                    return RedirectToAction("Index", "NhanVien");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Nhân viên thành công");
                }
            }
            return View(model);
        }

        public ActionResult Edit(NhanVien nhanvien)
        {
            if (ModelState.IsValid)
            {
                var dao = new NhanVienDao();
                if (!string.IsNullOrEmpty(nhanvien.Ho))
                {
                    nhanvien.Ho = nhanvien.Ho;
                }
                var result = dao.Update(nhanvien);
                if (result)
                {
                    return RedirectToAction("Index", "NhanVien");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Nhân Viên không thành công");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new NhanVienDao().Delete(id);

            return RedirectToAction("Index");
        }


    }
}
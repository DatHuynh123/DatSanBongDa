using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatSanBongDaOnline.Areas.Admin.Controllers
{
    public class ThanhVienController : Controller
    {
        // GET: Admin/ThanhVien
        public ActionResult Index(string searchString, int page = 1, int pageSize = 4)
        {
            var dao = new ThanhVienDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
           
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int matv)
        {
            var thanhvien = new ThanhVienDao().ViewDetail(matv);
            return View(thanhvien);
        }

        [HttpPost]
        public ActionResult Create(ThanhVien model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ThanhVienDao();
                int idnv = dao.Insert(model);
                if (idnv > 0)
                {
                    return RedirectToAction("Index", "ThanhVien");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Thành viên thành công");
                }
            }
            return View(model);
        }
        public ActionResult Edit(ThanhVien thanhvien)
        {
            if (ModelState.IsValid)
            {
                var dao = new ThanhVienDao();
                if (!string.IsNullOrEmpty(thanhvien.Ho))
                {
                    thanhvien.Ho = thanhvien.Ho;
                }
                var result = dao.Update(thanhvien);
                if (result)
                {
                    return RedirectToAction("Index", "ThanhVien");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Thành Viên không thành công");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ThanhVienDao().Delete(id);

            return RedirectToAction("Index");
        }
    }
}
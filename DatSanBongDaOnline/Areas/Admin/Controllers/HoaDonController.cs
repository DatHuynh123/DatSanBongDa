using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatSanBongDaOnline.Areas.Admin.Controllers
{
    public class HoaDonController : Controller
    {
        // GET: Admin/HoaDon
        public ActionResult Index(int page = 1, int pageSize = 2)
        {
            var dao = new HoaDonDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int mahd)
        {
            var hoadon = new HoaDonDao().ViewDetail(mahd);
            return View(hoadon);
        }
        public ActionResult Edit(HoaDon hoadon)
        {
            if (ModelState.IsValid)
            {
                var dao = new HoaDonDao();
                if (!string.IsNullOrEmpty(hoadon.DichVu))
                {
                    hoadon.DichVu = hoadon.DichVu;
                }
                var result = dao.Update(hoadon);
                if (result)
                {
                    return RedirectToAction("Index", "HoaDon");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Hóa Đơn không thành công");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Create(HoaDon model)
        {
            if (ModelState.IsValid)
            {
                var dao = new HoaDonDao();
                int idnv = dao.Insert(model);
                if (idnv > 0)
                {
                    return RedirectToAction("Index", "HoaDon");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm HoaDon thành công");
                }
            }
            return View(model);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new HoaDonDao().Delete(id);

            return RedirectToAction("Index");
        }
    }
}
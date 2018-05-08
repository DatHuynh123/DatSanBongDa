using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatSanBongDaOnline.Areas.Admin.Controllers
{
    public class SanController : Controller
    {
        private DatSanBongDaDbContext db = new DatSanBongDaDbContext();
        // GET: Admin/San
        public ActionResult Index(int page = 1, int pageSize = 2)
        {
            var dao = new SanDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(string masan)
        {
            var san = new SanDao().ViewDetail(masan);
            return View(san);
        }


        public ActionResult Edit(San san)
        {
            if (ModelState.IsValid)
            {
                var dao = new SanDao();
                if (!string.IsNullOrEmpty(san.TenSan))
                {
                    san.TenSan = san.TenSan;
                }
                var result = dao.Update(san);
                if (result)
                {
                    return RedirectToAction("Index", "San");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật San không thành công");
                }
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "MaSan, TenSan,DonGia,IDLoai,MaKM,SoLuong")] San  model)
        {
            if (ModelState.IsValid)
            {
                db.Sans.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSan = new SelectList(db.Sans, "MaSan, TenSan,DonGia,IDLoai,MaKM,SoLuong", model.MaSan);
            return View(model);
        }
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            new SanDao().Delete(id);

            return RedirectToAction("Index");
        }
    }
}
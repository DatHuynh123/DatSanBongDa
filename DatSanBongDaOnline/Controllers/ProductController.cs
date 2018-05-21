using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DatSanBongDaOnline.Controllers
{
    public class ProductController : Controller
    {
        DatSanBongDaDbContext db = new DatSanBongDaDbContext();
        // GET: Product
        [HttpGet]
        public ActionResult Index(int id)
        {
       
            return View();
            
        }

        public JsonResult ListName(string q)
        {
            var data = new SanDao().ListName(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Search(string keyword, int page = 1, int pageSize = 1)
        {
            int totalRecord = 0;
            var model = new SanDao().Search(keyword, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            ViewBag.Keyword = keyword;
            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }

        public ActionResult XemChiTiet(string id)
        {
            var san = new SanDao().ViewDetail(id);
            ViewBag.RelatedProducts = new SanDao().ListRelatedProducts(id);
            return View(san);
          
        }
    }
}
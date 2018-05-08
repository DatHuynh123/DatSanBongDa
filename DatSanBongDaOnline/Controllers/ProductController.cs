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
      
        public ActionResult XemChiTiet(string id)
        {
            var san = new SanDao().ViewDetail(id);
            ViewBag.RelatedProducts = new SanDao().ListRelatedProducts(id);
            return View(san);
          
        }
    }
}
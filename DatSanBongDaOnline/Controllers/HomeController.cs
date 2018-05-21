using DatSanBongDaOnline.Areas.Admin.Models;
using DatSanBongDaOnline.Common;
using DatSanBongDaOnline.Models;
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
        
        [ChildActionOnly]
        [OutputCache(Duration = 3600 * 24)]
        public ActionResult TopMeNu()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return PartialView(list);
        }
        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return PartialView(list);
        }    
    }
}
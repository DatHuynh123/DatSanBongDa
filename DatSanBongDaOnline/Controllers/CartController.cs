using DatSanBongDaOnline.Models;
using System;
using Model.EF;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using DatSanBongDaOnline.Areas.Admin.Controllers;
using Model.Dao;

namespace DatSanBongDaOnline.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;

            }
            return View(list);           
        }
      
        public ActionResult AddItem(string productId, int quantity)
        {
            var product = new SanDao().ViewDetail(productId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.sans.MaSan == productId))
                {

                    foreach (var item in list)
                    {
                        if (item.sans.MaSan == productId)
                        {
                            item.SoLuong += quantity;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.sans = product;
                    item.SoLuong = quantity;
                    list.Add(item);
                }
                //Gán vào session
                Session[CartSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartItem();
                item.sans = product;
                item.SoLuong = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //Gán vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
       


        //Xóa toàn bộ giỏ hàng
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }
        //Xóa item trong giỏ hàng
        public JsonResult Delete(string id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.sans.MaSan == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        //Cập nhập giỏ hàng
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.sans.MaSan == item.sans.MaSan);
                if (jsonItem != null)
                {
                    item.SoLuong = jsonItem.SoLuong;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }


        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult Payment(int mahd,string diachi, string sdt, string nguoidat)
        {
            var order = new HoaDon();
            order.MaHD = mahd;
            order.NgayDa = DateTime.Now;
            order.DiaChi = diachi;            
            order.SDT = sdt;
            order.NguoiDat = nguoidat;
            try
            {
                var id = new HoaDonDao().Insert(order);
                var cart = (List<CartItem>)Session[CartSession];
                var detailDao = new Model.Dao.CTHDDao();                
                foreach (var item in cart)
                {
                    var orderDetail = new CTHD();
                    orderDetail.MaHD = id;
                    orderDetail.MaSan = item.sans.MaSan;
                    orderDetail.GiaSan = item.sans.DonGia;
                    orderDetail.SoLuong = item.SoLuong;
                    detailDao.Insert(orderDetail);


                }

            }
            catch (Exception)
            {
                //ghi log
                return Redirect("/loi-thanh-toan");
            }
            return Redirect("/Cart/Success");
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}
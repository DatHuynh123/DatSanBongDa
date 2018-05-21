using Model.EF;
using Model.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DatSanBongDaOnline.Controllers
{
    internal class SanDao
    {
        DatSanBongDaDbContext db = null;
        public SanDao()
        {
            db = new DatSanBongDaDbContext();
        }
        public San ViewDetail(string id)
        {
            return db.Sans.Find(id);
        }
        public List<San> ListRelatedProducts(string id)
        {
            var san = db.Sans.Find(id);
            return db.Sans.Where(x => x.MaSan != id && x.IDLoai == san.IDLoai).ToList();
        }
        public List<string> ListName(string keyword)
        {
            return db.Sans.Where(x => x.TenSan.Contains(keyword)).Select(x => x.TenSan).ToList();
        }
        public List<ProductViewModels> Search(string keyword, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.Sans.Where(x => x.TenSan == keyword).Count();
            var model = (from a in db.Sans
                         //join b in db.ProductCategories
                         //on a.CategoryID equals b.ID
                         where a.TenSan.Contains(keyword)
                         select new
                         {
                             ProductID = a.MaSan,
                             Images = a.Image,                             
                             ProductName = a.TenSan,
                             Price = a.DonGia,
                             MetaTitle = a.MetaTitle,                                                          
                         }).AsEnumerable().Select(x => new ProductViewModels()
                         {
                             MaSan = x.ProductID,
                             Image = x.Images,
                             TenSan = x.ProductName,
                             MetaTitle = x.MetaTitle,
                             DonGia = x.Price

                         });
            model.OrderByDescending(x => x.MaSan).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }
        //public List<ProductViewModels> ListByCategoryId(string categoryID)
        //{
        //    var model = (from a in db.Sans
        //                     //join b in db.ProductCategories
        //                     //on a.CategoryID equals b.ID
        //                 where a.MaSan == categoryID
        //                 select new
        //                 {
        //                     ProductID = a.MaSan,
        //                     Images = a.Image,
        //                     ProductName = a.TenSan,
        //                     MetaTitle = a.MetaTitle,
        //                     Price = a.DonGia
        //                 }).AsEnumerable().Select(x => new ProductViewModels()
        //                 {
        //                     MaSan = x.ProductID,
        //                     Image = x.Images,
        //                     TenSan = x.ProductName,
        //                     MetaTitle = x.MetaTitle,
        //                     DonGia = x.Price
        //                 });
        //    return model.ToList();
        //}
        public List<San> ListNewProduct()
        {
            return db.Sans.ToList();
        }      
    }
    
}
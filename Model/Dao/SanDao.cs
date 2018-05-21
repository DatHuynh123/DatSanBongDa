using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class SanDao
    {
        DatSanBongDaDbContext db = null;
        public SanDao()
        {
            db = new DatSanBongDaDbContext();
        }
        public string Insert(San san)
        {
            db.Sans.Add(san);
            db.SaveChanges();
            return san.MaSan;
        }
        public IEnumerable<San> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<San> model = db.Sans;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenSan.Contains(searchString) || x.MaSan.Contains(searchString) || x.Image.Contains(searchString));
            }
            return model.OrderByDescending(x => x.MaSan).ToPagedList(page, pageSize);
        }
        public bool Update(San entity)
        {
            try
            {
                var san = db.Sans.Find(entity.MaSan);
                san.TenSan = entity.TenSan;
                san.DonGia = entity.DonGia;
                san.IDLoai = entity.IDLoai;
                san.MaKM = entity.MaKM;
                san.SoLuong = entity.SoLuong;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //logging
                return false;
            }

        }
        public San ViewDetail(string masan)
        {
            return db.Sans.Find(masan);
        }

        public List<San> ListRelatedSans(string masan)
        {
            var product = db.Sans.Find(masan);
            return db.Sans.Where(x => x.MaSan != masan && x.IDLoai == product.IDLoai).ToList();
        }
        public bool Delete(string id)
        {
            try
            {
                var san = db.Sans.Find(id);
                db.Sans.Remove(san);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }

}
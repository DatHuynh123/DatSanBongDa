using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class KhachHangDao
    {
        DatSanBongDaDbContext db = null;
        public KhachHangDao()
        {
            db = new DatSanBongDaDbContext();
        }
        public int Insert(khachhang khachHang)
        {
            db.khachhangs.Add(khachHang);
            db.SaveChanges();
            return khachHang.MaKH;
        }
        public IEnumerable<khachhang> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<khachhang> model = db.khachhangs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Ho.Contains(searchString) || x.Ten.Contains(searchString) || x.DiaChi.Contains(searchString));
            }
            return model.OrderByDescending(x => x.MaKH).ToPagedList(page, pageSize);
        }
        public bool Update(khachhang entity)
        {
            try
            {
                var khachhang = db.khachhangs.Find(entity.MaKH);
                khachhang.Ho = entity.Ho;
                khachhang.Ten = entity.Ten;

                khachhang.Email = entity.Email;
                khachhang.IDKH = entity.IDKH;
                khachhang.DiaChi = entity.DiaChi;
                khachhang.SDT = entity.SDT;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //logging
                return false;
            }

        }
        public khachhang ViewDetail(int makh)
        {
            return db.khachhangs.Find(makh);
        }

        public bool Delete(int id)
        {
            try
            {
                var khachhang = db.khachhangs.Find(id);
                db.khachhangs.Remove(khachhang);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool CheckUserName(string userName)
        {
            return db.khachhangs.Count(x => x.Ten == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.khachhangs.Count(x => x.Email == email) > 0;
        }
    }

}
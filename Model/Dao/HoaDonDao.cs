using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class HoaDonDao
    {
        DatSanBongDaDbContext db = null;
        public HoaDonDao()
        {
            db = new DatSanBongDaDbContext();
        }
        public int Insert(HoaDon hoadon)
        {
            db.HoaDons.Add(hoadon);
            db.SaveChanges();
            return hoadon.MaHD;
        }
        public IEnumerable<HoaDon> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<HoaDon> model = db.HoaDons;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.MaSan.Contains(searchString) || x.DichVu.Contains(searchString) || x.DiaChi.Contains(searchString) || x.NguoiDat.Contains(searchString)
                || x.SDT.Contains(searchString) || x.TrangThai.Contains(searchString));
            }
            return model.OrderByDescending(x => x.MaHD).ToPagedList(page, pageSize);
        }

        public bool Update(HoaDon entity)
        {
            try
            {
                var hoadon = db.HoaDons.Find(entity.MaHD);
                hoadon.MaSan = entity.MaSan;
                hoadon.MaTV = entity.MaTV;
                hoadon.MaNV = entity.MaNV;
                hoadon.NgayDa = entity.NgayDa;
                hoadon.DichVu = entity.DichVu;
                hoadon.DiaChi = entity.DiaChi;
                hoadon.NguoiDat = entity.NguoiDat;
                hoadon.SDT = entity.SDT;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //logging
                return false;
            }

        }
        public HoaDon ViewDetail(int mahd)
        {
            return db.HoaDons.Find(mahd);
        }

        public bool Delete(int id)
        {
            try
            {
                var hoadon = db.HoaDons.Find(id);
                db.HoaDons.Remove(hoadon);
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
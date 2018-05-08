using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatSanBongDaOnline.Areas.Admin.Controllers
{
    internal class ThanhVienDao
    {
        DatSanBongDaDbContext db = null;
        public ThanhVienDao()
        {
            db = new DatSanBongDaDbContext();
        }
        public int Insert(ThanhVien thanhVien)
        {
            db.ThanhViens.Add(thanhVien);
            db.SaveChanges();
            return thanhVien.MaTV;
        }
        public IEnumerable<ThanhVien> ListAllPaging(int page, int pageSize)
        {
            return db.ThanhViens.OrderByDescending(x => x.MaTV).ToPagedList(page, pageSize);
        }
        public bool Update(ThanhVien entity)
        {
            try
            {
                var thanhvien = db.ThanhViens.Find(entity.MaTV);
                thanhvien.Ho = entity.Ho;
                thanhvien.Ten = entity.Ten;
                // nhanvien.MaNV = entity.MaNV;
                // nhanvien.Ten = entity.Ten;
                thanhvien.Email = entity.Email;
                thanhvien.IDTV = entity.IDTV;
                thanhvien.DiaChi = entity.DiaChi;
                thanhvien.SDT = entity.SDT;
                db.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                //logging
                return false;
            }

        }
        public ThanhVien ViewDetail(int matv)
        {
            return db.ThanhViens.Find(matv);
        }
        public bool Delete(int id)
        {
            try
            {
                var thanhvien = db.ThanhViens.Find(id);
                db.ThanhViens.Remove(thanhvien);
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
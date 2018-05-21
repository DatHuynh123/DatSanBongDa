using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class NhanVienDao
    {
        DatSanBongDaDbContext db = null;
        public NhanVienDao()
        {
            db = new DatSanBongDaDbContext();
        }
        public int Insert(NhanVien nhanVien)
        {
            db.NhanViens.Add(nhanVien);
            db.SaveChanges();
            return nhanVien.MaNV;
        }
        public IEnumerable<NhanVien> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<NhanVien> model = db.NhanViens;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Ho.Contains(searchString) || x.Ten.Contains(searchString) || x.DiaChi.Contains(searchString));
            }
            return model.OrderByDescending(x => x.MaNV).ToPagedList(page, pageSize);
        }
        public bool Update(NhanVien entity)
        {
            try
            {
                var nhanvien = db.NhanViens.Find(entity.MaNV);
                nhanvien.Ho = entity.Ho;
                nhanvien.Ten = entity.Ten;
                nhanvien.Email = entity.Email;
                nhanvien.IDNV = entity.IDNV;
                nhanvien.DiaChi = entity.DiaChi;
                nhanvien.SDT = entity.SDT;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //logging
                return false;
            }

        }
        public NhanVien ViewDetail(int manv)
        {
            return db.NhanViens.Find(manv);
        }

        public bool Delete(int id)
        {
            try
            {
                var nhanvien = db.NhanViens.Find(id);
                db.NhanViens.Remove(nhanvien);
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
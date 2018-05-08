using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatSanBongDaOnline.Areas.Admin.Controllers
{    
        internal class HoaDonDao
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
            public IEnumerable<HoaDon> ListAllPaging(int page, int pageSize)
            {
                return db.HoaDons.OrderByDescending(x => x.MaHD).ToPagedList(page, pageSize);
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
                    db.SaveChanges();
                    return true;
                }
                catch (Exception )
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
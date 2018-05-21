using Model.EF;
using System.Linq;

namespace DatSanBongDaOnline.Controllers
{
    internal class UserDao
    {        
            DatSanBongDaDbContext db = null;
        public UserDao()
        {
            db = new DatSanBongDaDbContext();
        }

        public int Insert(khachhang entity)
        {
            db.khachhangs.Add(entity);
            db.SaveChanges();
            return entity.MaKH;
        }
        public khachhang GetById(string tenTK)
        {
            return db.khachhangs.SingleOrDefault(x => x.Email == tenTK);
        }
        public bool Login(string tenTK, string pW)
        {
            var result = db.khachhangs.Count(x => x.Ten == tenTK && x.Password == pW);
            if (result > 0)
            {
                return true;
            }
            else
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
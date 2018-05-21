using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class UserDao
    {
        DatSanBongDaDbContext db = null;
        public UserDao()
        {
            db = new DatSanBongDaDbContext();
        }

        public int Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public User GetById(string tenTK)
        {
            return db.Users.SingleOrDefault(x => x.TenTK == tenTK);
        }
        public bool Login(string tenTK, string pW)
        {
            var result = db.Users.Count(x => x.TenTK == tenTK && x.PW == pW);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

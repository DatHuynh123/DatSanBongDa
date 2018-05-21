using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.Dao
{
    public class CTHDDao
    {

        DatSanBongDaDbContext db = null;
        public CTHDDao()
        {
            db = new DatSanBongDaDbContext();
        }
        public bool Insert(CTHD detail)
        {
            try
            {
                db.CTHDs.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }
    }
}

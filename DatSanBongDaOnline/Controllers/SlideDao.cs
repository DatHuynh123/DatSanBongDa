using Model.EF;
using System.Collections.Generic;
using System.Linq;

namespace DatSanBongDaOnline.Controllers
{
    internal class SlideDao
    {       
            DatSanBongDaDbContext db = null;
        public SlideDao()
        {
            db = new DatSanBongDaDbContext();
        }

        public List<Slide> ListAll()

        {

            return db.Slides.Where(x => x.Status == true).OrderBy(y => y.DisplayOrder).ToList();
        }
    }
    }

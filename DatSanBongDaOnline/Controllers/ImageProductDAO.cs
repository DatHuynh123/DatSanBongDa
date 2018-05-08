using Model.EF;

namespace DatSanBongDaOnline.Controllers
{
    internal class ImageProductDAO
    {        
            DatSanBongDaDbContext db = null;
        public ImageProductDAO()
        {
            db = new DatSanBongDaDbContext();

        }
        public Slide Imagepro(string id)
        {

            return db.Slides.Find(id);
        
    }
    }
}
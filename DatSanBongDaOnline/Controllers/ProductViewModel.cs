namespace DatSanBongDaOnline.Controllers
{
    public class ProductViewModel
    {
        public string MaSan { get; set; }
        public string Image { set; get; }
        public string TenSan { set; get; }
        public decimal? DonGia { set; get; }
        public string MetaTitle { set; get; }
        public int? MaKM { get; set; }
        public int? IDLoai { set; get; }
        public int? SoLuong { set; get; }
        public bool? Hot { set; get; }
    }
}
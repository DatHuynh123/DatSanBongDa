namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("San")]
    public partial class San
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public San()
        {
            BinhLuans = new HashSet<BinhLuan>();
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        [StringLength(10)]
        [DisplayName("Mã Sân:")]
        public string MaSan { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Tên Sân")]
        [StringLength(250, ErrorMessage = "Số kí tự tối đa là 50")]
        [DisplayName("Tên Sân:")]
        public string TenSan { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Số Đơn Giá")]
        [DisplayName("Đơn Giá:")]
        [Range(0, Int32.MaxValue, ErrorMessage = ("Bạn phải nhập số"))]
        public decimal? DonGia { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Số Image")]
        [DisplayName("Image:")]
        [StringLength(250)]
        public string Image { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Số MetaTitle")]
        [DisplayName("MetaTitle:")]
        [StringLength(250)]
        public string MetaTitle { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập ID Loại")]
        [DisplayName("IDLoai:")]
        [Range(0, Int32.MaxValue, ErrorMessage = ("Bạn phải nhập số"))]
        public int? IDLoai { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Hot")]
        [DisplayName("Hot:")]
        public bool? Hot { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Mã Khuyến Mãi ")]
        [DisplayName("Mã Khuyến mãi:")]
        [Range(0, Int32.MaxValue, ErrorMessage = ("Bạn phải nhập số"))]
        public int? MaKM { get; set; }

        [DisplayName("Số Lượng:")]
        public int? SoLuong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public virtual KhuyenMai KhuyenMai { get; set; }
    }
}

namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTHD")]
    public partial class CTHD
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Hóa Đơn:")]
        public int MaHD { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Mã Sân")]
        [DisplayName("Mã Sân:")]
        [StringLength(10)]
        public string MaSan { get; set; }

        [DisplayName("Giá sân:")]
        public decimal? GiaSan { get; set; }


        [DisplayName("Sô lương:")]
        public int? SoLuong { get; set; }

        [DisplayName("Thành tiên:")]
        public decimal? ThanhTien { get; set; }

        //public virtual HoaDon Hoadon { get; set; }
        public virtual San San { get; set; }

    }
}


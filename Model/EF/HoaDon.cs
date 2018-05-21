namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Hóa Đơn:")]
        public int MaHD { get; set; }

   
        [DisplayName("Mã Sân:")]
        [StringLength(10)]
        public string MaSan { get; set; }


        [DisplayName("Mã Thành Viên:")]
        public int? MaTV { get; set; }


        [DisplayName("Mã Nhân Viên:")]
        public int? MaNV { get; set; }

   
        [DisplayName("Ngày Đặt:")]
        public DateTime? NgayDa { get; set; }

      
        [StringLength(50)]
        [DisplayName("Trạng Thái:")]
        public string TrangThai { get; set; }

        [StringLength(50)]
        [DisplayName("Dịch Vụ:")]
        public string DichVu { get; set; }

   
        [DisplayName("Địa Chỉ:")]
        public string DiaChi { get; set; }

        [DisplayName("SDT:")]
        [StringLength(11)]
        public string SDT { get; set; }

        [DisplayName("Người Nhận:")]
        [StringLength(50)]
        public string NguoiDat { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual San San { get; set; }

        public virtual ThanhVien ThanhVien { get; set; }
    }
}


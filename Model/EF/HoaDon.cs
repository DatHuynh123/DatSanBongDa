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

        [Required(ErrorMessage = "Bạn chưa nhập Mã Sân")]
        [DisplayName("Mã Sân:")]
        [StringLength(10)]
        public string MaSan { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Mã Thành viên")]
        [DisplayName("Mã Thành Viên:")]
        public int? MaTV { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Mã Nhân Viên")]
        [DisplayName("Mã Nhân Viên:")]
        public int? MaNV { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Số điện thoại")]
        [DisplayName("Ngày Đặt:")]
        public DateTime? NgayDa { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Trạng Thái")]
        [StringLength(50)]
        [DisplayName("Trạng Thái:")]
        public string TrangThai { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Dịch Vụ")]
        [StringLength(50)]
        [DisplayName("Dịch Vụ:")]
        public string DichVu { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Địa Chỉ")]
        [DisplayName("Địa Chỉ:")]
        public string DiaChi { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual San San { get; set; }

        public virtual ThanhVien ThanhVien { get; set; }
    }
}


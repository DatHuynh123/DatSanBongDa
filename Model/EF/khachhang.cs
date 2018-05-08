namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("khachhang")]
    public partial class khachhang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public khachhang()
        {
            BinhLuans = new HashSet<BinhLuan>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Khách Hàng:")]
        public int MaKH { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Họ")]
        [DisplayName("Họ:")]
        [StringLength(50)]
        public string Ho { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Tên")]
        [DisplayName("Tên:")]
        [StringLength(50)]
        public string Ten { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Địa chỉ")]
        [DisplayName("Địa chỉ:")]
        [StringLength(350)]
        public string DiaChi { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Số điện thoại")]
        [DisplayName("SDT:")]
        [StringLength(11)]
        public string SDT { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Email")]
        [DisplayName("Email:")]
        [StringLength(50)]
        public string Email { get; set; }

        
        [DisplayName("ID Khách Hàng :")]
        public int? IDKH { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Password")]
        [DisplayName("Password:")]
        [StringLength(50)]
        public string Password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }

        public virtual User User { get; set; }
    }
}
//[Key]
//[DatabaseGenerated(DatabaseGeneratedOption.None)]
//[DisplayName("Mã Khách Hàng:")]
//public int MaKH { get; set; }

//[Required(ErrorMessage = "Bạn chưa nhập Họ")]
//[DisplayName("Họ:")]
//[StringLength(50)]
//public string Ho { get; set; }

//[Required(ErrorMessage = "Bạn chưa nhập Tên")]
//[DisplayName("Tên:")]
//[StringLength(50)]
//public string Ten { get; set; }

//[Required(ErrorMessage = "Bạn chưa nhập Địa chỉ")]
//[StringLength(350)]
//[DisplayName("Địa chỉ:")]
//public string DiaChi { get; set; }

//[Required(ErrorMessage = "Bạn chưa nhập Số điện thoại")]
//[DisplayName("SDT:")]
//[StringLength(11)]
//public string SDT { get; set; }

//[Required(ErrorMessage = "Bạn chưa nhập Email")]
//[StringLength(50)]
//[DisplayName("Email:")]
//public string Email { get; set; }

//[Required(ErrorMessage = "Bạn chưa nhập ID Thành Viên")]
//[DisplayName("IDKH:")]
//[Range(0, Int32.MaxValue, ErrorMessage = ("Bạn phải nhập số"))]
//public int? IDKH { get; set; }

//[Required(ErrorMessage = "Bạn chưa nhập Password")]
//[DisplayName("Password:")]
//[StringLength(50)]
//public string Password { get; set; }

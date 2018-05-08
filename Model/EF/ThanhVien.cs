namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThanhVien")]
    public partial class ThanhVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThanhVien()
        {
            BinhLuans = new HashSet<BinhLuan>();
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Thành Viên:")]
        public int MaTV { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Họ")]
        [StringLength(50, ErrorMessage = "Số kí tự tối đa là 50")]
        [DisplayName("Họ:")]
        public string Ho { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Tên")]
        [StringLength(50, ErrorMessage = "Số kí tự tối đa là 50")]
        [DisplayName("Tên:")]
        public string Ten { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Email")]
        [StringLength(50)]
        [DisplayName("Email:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập ID Nhân Viên")]
        [DisplayName("ID Thành Viên:")]
        [Range(0, Int32.MaxValue, ErrorMessage = ("Bạn phải nhập số"))]
        public int IDTV { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Địa chỉ")]
        [StringLength(50)]
        [DisplayName("Địa chỉ:")]
        public string DiaChi { get; set; }

        [DisplayName("SDT:")]
        public int? SDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}

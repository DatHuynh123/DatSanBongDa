namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("MaNV:")]
        public int MaNV { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Họ")]
        [DisplayName("Họ:")]
        [StringLength(50)]
        public string Ho { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Tên")]
        [StringLength(50, ErrorMessage = "Số kí tự tối đa là 50")]
        [DisplayName("Tên:")]
        public string Ten { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Email")]
        [StringLength(50)]
        [DisplayName("Email:")]
        public string Email { get; set; }

        
        [DisplayName("ID Nhân Viên:")]
        public int? IDNV { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Địa chỉ")]
        [StringLength(50)]
        [DisplayName("Địachỉ:")]
        public string DiaChi { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Số điện thoại")]
        [DisplayName("SDT:")]
        public int? SDT { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Passwword")]
        [DisplayName("Passwword:")]
        [StringLength(50)]
        public string Password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}

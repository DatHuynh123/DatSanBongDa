using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DatSanBongDaOnline.Models
{
    public class RegisterModel
    {
        [Key]
        public int MaKH { set; get; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Yêu cầu nhập Email đăng nhập")]
        public string Email { set; get; }

        [Display(Name = "Mật khẩu")]
        [StringLength(50)]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        public string Password { set; get; }

        

        [Display(Name = "Họ")]
        [Required(ErrorMessage = "Yêu cầu nhập họ")]
        public string Ho { set; get; }

        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Yêu cầu nhập tên")]
        public string Ten { set; get; }

        [Display(Name = "Địa chỉ")]
        public string DiaChi { set; get; }       

        [Display(Name = "Điện thoại")]
        public string SDT { set; get; }

        [Display(Name="ID Khách Hàng :")]
        public int? IDKH { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DatSanBongDaOnline.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời bạn nhập tên tài khoản")]
        public string TenTK { set; get; }

        [Required(ErrorMessage = "Mời bạn nhập mật khẩu")]
        public string PW { set; get; }

        public bool RememberMe { set; get; }
    }
}
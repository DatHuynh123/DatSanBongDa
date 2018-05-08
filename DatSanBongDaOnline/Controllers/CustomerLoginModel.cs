using System.ComponentModel.DataAnnotations;

namespace DatSanBongDaOnline.Controllers
{
    public class CustomerLoginModel
    {
        [Required(ErrorMessage = "Mời nhập email")]
        public string Email { set; get; }
        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        public string Password { get; set; }

        public bool Remember { set; get; }
    }
}
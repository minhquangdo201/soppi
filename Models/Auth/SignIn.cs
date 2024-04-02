using System.ComponentModel.DataAnnotations;

namespace soppi.Models {
    public class SignIn {
        [Required(ErrorMessage ="Hãy nhập tên đăng nhập")]
        public string? UserName { get; set; }
        [Required(ErrorMessage ="Hãy nhập mật khẩu")]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
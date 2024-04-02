using System.ComponentModel.DataAnnotations;

namespace soppi.Models
{
    public class SignUp
    {     
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Mật khẩu không trùng khớp")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class RegisterModel
    {
        [Required]
        [MinLength(4, ErrorMessage ="Chiều dài tối thiểu là 4 ký tự")]
        [MaxLength(60, ErrorMessage ="Chiều dài tối đa là 60 ký tự")]
        public String UserName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Không đúng định dạng email")]
        public String Email { get; set; }
        [Required]
        [MinLength(4, ErrorMessage = "Chiều dài tối thiểu là 4 ký tự")]
        [MaxLength(60, ErrorMessage = "Chiều dài tối đa là 60 ký tự")]
        public String Password { get; set; }
        [Compare("Password",ErrorMessage ="Mật khẩu không trùng khớp")]
        public String CofirmPassword { get; set; }
        [Required]
        [RegularExpression("(^[0][0-9]{9}$)", ErrorMessage = "Enter only 10 numbers")]
        public String Phone { get; set; }
        public String Adress { get; set; }
    }
    public class LoginModel
    {
        [Required]
        [EmailAddress(ErrorMessage ="Không đúng định dạng email")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
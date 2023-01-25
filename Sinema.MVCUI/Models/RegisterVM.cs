using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sinema.MVCUI.Models
{
    public class RegisterVM
    {


        [Required(AllowEmptyStrings =false,ErrorMessage ="Kullanici Kodu Boş Olamaz")]
        [DisplayName("Kullanici Kodu")]
        public string UserName { get; set; }


        [Required(AllowEmptyStrings =false,ErrorMessage ="Şifre Boş Olamaz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Boş Olamaz")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        public string? TcNo { get; set; }
    }
}

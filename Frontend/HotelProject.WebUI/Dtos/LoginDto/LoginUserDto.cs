using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage ="Kullanıcı adınızı giriniz.")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Şifrenizi adınızı giriniz.")]
        public string Password { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.AboutDto
{
    public class ResultAboutDto
    {
        [Required(ErrorMessage = "Lütfen başlığı giriniz.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Title en az 1, en fazla 50 karakter olmalıdır.")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Lütfen açıklama giriniz.")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "Description en az 1, en fazla 255 karakter olmalıdır.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Lütfen RoomCount giriniz.")]
        [Range(1, 1000000, ErrorMessage = "RoomCount 1 ile 1,000,000 arasında olmalıdır.")]
        public int RoomCount { get; set; }

        [Required(ErrorMessage = "Lütfen StaffCount giriniz.")]
        [Range(1, 1000000, ErrorMessage = "StaffCount 1 ile 1,000,000 arasında olmalıdır.")]
        public int StaffCount { get; set; }

        [Required(ErrorMessage = "Lütfen CustomerCount giriniz.")]
        [Range(1, 1000000, ErrorMessage = "CustomerCount 1 ile 1,000,000 arasında olmalıdır.")]
        public int CustomerCount { get; set; }
    }
}

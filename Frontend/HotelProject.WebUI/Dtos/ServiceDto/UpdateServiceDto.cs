﻿using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        public int ServiceID { get; set; }

        [Required(ErrorMessage = "Hizmet ikon linki giriniz.")]
        public string? ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet başlığı giriniz.")]
        [StringLength(100, ErrorMessage = "Hizmet başlığı en falza 100 karakter olabilir.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Hizmet başlığı giriniz.")]
        [StringLength(500, ErrorMessage = "Hizmet başlığı en falza 500 karakter olabilir.")]
        public string? Description { get; set; }
    }
}

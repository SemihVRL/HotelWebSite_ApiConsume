using System.ComponentModel.DataAnnotations;

namespace HotelProject_WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {

        [Key]
        public int ServiceID { get; set; }

        [Required(ErrorMessage = "Hizmet ikon linki girin")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet başlık girin")]
        [StringLength(50, ErrorMessage = "Hizmet başlık için 50 karakter girin")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Hizmet açıklaması girin")]
        [StringLength(100, ErrorMessage = "Hizmet açıklaması için 50 karakter girin")]
        public string Description { get; set; }
    }
}

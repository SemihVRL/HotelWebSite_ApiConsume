using System.ComponentModel.DataAnnotations;

namespace HotelProject_WebUI.Dtos.ServiceDto
{
    public class AddServiceDto
    {
        [Required(ErrorMessage ="Hizmet ikon linki girin")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet başlık girin")]
        [StringLength(50,ErrorMessage ="Hizmet başlık için 50 karakter girin")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

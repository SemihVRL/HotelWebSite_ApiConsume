using System.ComponentModel.DataAnnotations;

namespace HotelProject_WebUI.Dtos.ServiceDto
{
    public class ListServiceDto
    {
        [Key]
        public int ServiceID { get; set; }
        public string ServiceIcon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

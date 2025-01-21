using System.ComponentModel.DataAnnotations;

namespace HotelProject_WebUI.Models.Testimonials
{
    public class AddTestimonialsViewModel
    {
       
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace HotelProject_WebUI.Models.Testimonials
{
    public class TestimonialsViewModel
    {
        [Key]
        public int TestimonialID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
      
       
    }
}

using System.ComponentModel.DataAnnotations;

namespace HotelProject_WebUI.Dtos.AboutDto
{
    public class ResultAboutDto
    {
        [Key]
        public int AboutUsID { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Content { get; set; }
        public int RoomCount { get; set; }
        public int StaffCount { get; set; }
        public int CustomerCount { get; set; }
    }
}

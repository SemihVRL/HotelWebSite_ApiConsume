using System.ComponentModel.DataAnnotations;

namespace HotelProject_WebUI.Dtos.ContactDto
{
    public class ResultContactDto
    {
        [Key]
        public int ContactID { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}

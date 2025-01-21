using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject_DtoLayer.Dtos.RoomDto
{
    public class RoomAddDto
    {
        [Required(ErrorMessage ="Lütfen Oda numaranızı girin")]
        public string RoomNumber { get; set; }
        public string RoomCoverImage { get; set; }

        [Required(ErrorMessage = "Lütfen Fiyat bilgisini girin")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Lütfen Oda başlığı bilgisini girin")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Lütfen Yatak sayısını girin")]
        public string BedCount { get; set; }

        [Required(ErrorMessage = "Lütfen Banyo sayısını girin")]
        public string BathCount { get; set; }
        public string Wifi { get; set; }
        public string Description { get; set; }
    }
}

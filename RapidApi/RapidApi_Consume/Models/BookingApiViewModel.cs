﻿namespace RapidApi_Consume.Models
{
    public class BookingApiViewModel
    {
        public Result[] results { get; set; }
        public class Result
        {
            public string reviewScoreWord { get; set; }
            public int accuratePropertyClass { get; set; }
            public int reviewCount { get; set; }
            public int ufi { get; set; }
            public bool isPreferred { get; set; }
            public bool isFirstPage { get; set; }
            public int qualityClass { get; set; }
            public int rankingPosition { get; set; }
            public float reviewScore { get; set; }
            public string countryCode { get; set; }
            public int propertyClass { get; set; }
            public string[] photoUrls { get; set; }
            public string checkoutDate { get; set; }
            public int position { get; set; }
            public float latitude { get; set; }
            public int optOutFromGalleryChanges { get; set; }
            public string wishlistName { get; set; }
            public string[] blockIds { get; set; }
            public string currency { get; set; }
            public string checkinDate { get; set; }
            public int id { get; set; }
            public int mainPhotoId { get; set; }
            public string name { get; set; }
            public float longitude { get; set; }
            public bool isPreferredPlus { get; set; }

        }

     

    }
}

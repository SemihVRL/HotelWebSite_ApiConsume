using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Newtonsoft.Json;
using RapidApi_Consume.Models;
using System.Net.Http.Headers;

namespace RapidApi_Consume.Controllers
{
    public class BookingController : Controller
    {
        public async Task< IActionResult> Index()
        {
            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels?dest_id=-2092178&search_type=CITY&arrival_date=2025-01-01&departure_date=2025-01-06&adults=1&children_age=0%2C17&room_qty=1&page_number=1&units=metric&temperature_unit=c&languagecode=en-us&currency_code=AED"),
                Headers =
    {
        { "x-rapidapi-key", "ee5662d860msh7d7eedd580cb965p156e4fjsn88cc69b8348c" },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<BookingApiViewModel>(body);
                return View(values.results.ToList());
            }
            
        }
    }
}

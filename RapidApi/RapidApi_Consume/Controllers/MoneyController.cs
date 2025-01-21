using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi_Consume.Models;
using System.Net.Http.Headers;

namespace RapidApi_Consume.Controllers
{
    public class MoneyController : Controller
    {
        public async Task <IActionResult> Index()
        {    
            //List<MoneyModel> models = new List<MoneyModel>();
          
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/meta/getCurrency"),
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
                var values=JsonConvert.DeserializeObject<MoneyModel>(body);
                return View(values.exchange_rates.ToList());
                
            }
            
        }
    }
}

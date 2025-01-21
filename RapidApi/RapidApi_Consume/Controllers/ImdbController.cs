using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi_Consume.Models;
using System.Net.Http.Headers;

namespace RapidApi_Consume.Controllers
{
    public class ImdbController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ApiMovieModel> model = new List<ApiMovieModel>();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "x-rapidapi-key", "ee5662d860msh7d7eedd580cb965p156e4fjsn88cc69b8348c" },
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                model=JsonConvert.DeserializeObject<List<ApiMovieModel>>(body);
                return View(model);
               
            }
           
        }
    }
}

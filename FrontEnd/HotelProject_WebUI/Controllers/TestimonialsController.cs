using HotelProject_WebUI.Models.Staff;
using HotelProject_WebUI.Models.Testimonials;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing.Text;
using System.Text;

namespace HotelProject_WebUI.Controllers
{
    public class TestimonialsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> TestimonialsIndex()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7294/api/Testimonial");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<TestimonialsViewModel>>(jsondata);
                return View(values);
            }
            return View();

        }

        [HttpGet]
        public IActionResult TestimonialsAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TestimonialsAdd(AddTestimonialsViewModel model)
        {
            var client= _httpClientFactory.CreateClient();

            var jsondata=JsonConvert.SerializeObject(model);

            StringContent content = new StringContent(jsondata,Encoding.UTF8,"application/json");

            var responseMessage = await client.PostAsync("https://localhost:7294/api/Testimonial",content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("TestimonialsIndex");
            }

            return View();

        }

        public async Task<IActionResult> TestimonialsDelete(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7294/api/Testimonial/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("TestimonialsIndex");
            }
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> TestimonialsUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7294/api/Testimonial/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //veritabanı sorguları, ağ istekleri veya dosya okuma işlemleri gibi.kodlarda await kullanırı
                // await yazılırsa asycn method olması lazım

                var values = JsonConvert.DeserializeObject<UpdateTestimonialsViewModel>(jsonData);
                return View(values);

            }

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> TestimonialsUpdate(UpdateTestimonialsViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7294/api/Testimonial", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("TestimonialsIndex");
            }
            else
            {
                var error = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine($"API Error: {error}");
                return View();

            }
            return View();


        }
    }
}

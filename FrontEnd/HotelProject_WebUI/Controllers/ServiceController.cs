
using HotelProject_WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject_WebUI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ServiceIndex()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7294/api/Service");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ListServiceDto>>(jsondata);
                //deserialize demek json dan c# tarafına dönmek demek
                return View(values);
            }

            return View();
        }

        [HttpGet]
        public IActionResult ServiceAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ServiceAdd(AddServiceDto addServiceDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(addServiceDto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responsemessage = await client.PostAsync("https://localhost:7294/api/Service", content);
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ServiceIndex");
            }
            return View();
        }

        public async Task<IActionResult> ServiceDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7294/api/Service/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ServiceIndex");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ServiceUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync($"https://localhost:7294/api/Service/{id}");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateServiceDto>(jsondata);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ServiceUpdate(UpdateServiceDto updateServiceDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var client=_httpClientFactory.CreateClient();
            var jsondata=JsonConvert.SerializeObject(updateServiceDto);
            StringContent content = new StringContent(jsondata,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("https://localhost:7294/api/Service",content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ServiceIndex");
            }
            return View();
        }


    }
}

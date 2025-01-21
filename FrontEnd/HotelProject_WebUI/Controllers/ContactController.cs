using HotelProject_WebUI.Dtos.BookingDto;
using HotelProject_WebUI.Dtos.ContactDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelProject_WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactDto contact)
        {
            contact.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(contact);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:7294/api/Contact", content);
            return RedirectToAction("Index", "Contact");
        }
    }
}

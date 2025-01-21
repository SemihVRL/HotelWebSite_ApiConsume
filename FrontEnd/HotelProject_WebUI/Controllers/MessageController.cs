using HotelProject_EntityLayer.Concrete;
using HotelProject_WebUI.Dtos.ContactDto;
using HotelProject_WebUI.Dtos.SendMessageDto;
using HotelProject_WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.InteropServices;
using System.Text;

namespace HotelProject_WebUI.Controllers
{
    public class MessageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MessageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Inbox()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7294/api/Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultContactDto>>(jsondata);

                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult InboxAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InboxAdd(Contact contact)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata=JsonConvert.SerializeObject(contact);

            StringContent content= new StringContent(jsondata,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7294/api/Contact",content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return View();
            }
            return View();
        }

        public async Task<IActionResult> InboxDelete(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7294/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Inbox");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> InboxUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7294/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //veritabanı sorguları, ağ istekleri veya dosya okuma işlemleri gibi.kodlarda await kullanırı
                // await yazılırsa async method olması lazım

                var values = JsonConvert.DeserializeObject<ResultContactDto>(jsonData);
                return View(values);

            }

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> InboxUpdate(ResultContactDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7294/api/Contact", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Inbox");
            }
            return View();


        }

        public IActionResult SidebarContactPartial()
        {
            return PartialView();
        }

        public IActionResult SidebarContactCategoryPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult StaffSendMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> StaffSendMessage(CreateMessageDto dto)
        {
            dto.SenderMail = "admin@gmail.com";
            dto.SenderName = "admin";
            dto.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            

            var client = _httpClientFactory.CreateClient();

            var jsondata = JsonConvert.SerializeObject(dto);
            //burda c# olan objeci json formatında dönmesi için biz bunu serialize ettik

            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            //içeriğimizin dönüşümü için geçerli olan kod 
            // türkçe karakteri desteklicek şekilde getir

            var responseMessage = await client.PostAsync("https://localhost:7294/api/SendMessage", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox");
            }
            return View();
        }

        public async Task<IActionResult> SendBox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7294/api/SendMessage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<SendBoxListDto>>(jsondata);

                return View(values);
            }
            return View();
        }

        public async Task<ActionResult> MessageDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7294/api/SendMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //veritabanı sorguları, ağ istekleri veya dosya okuma işlemleri gibi.kodlarda await kullanırı
                // await yazılırsa async method olması lazım

                var values = JsonConvert.DeserializeObject<GetMessageByIdDto>(jsonData);
                return View(values);

            }

            return View();
        }





    }
}

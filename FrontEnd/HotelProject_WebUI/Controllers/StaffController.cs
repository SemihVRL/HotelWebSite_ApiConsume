using HotelProject_WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject_WebUI.Controllers
{
    public class StaffController : Controller
    {
        //httpclientfactory ınterface alanından consructor oluşturuyoruz
        private readonly IHttpClientFactory _httpClientFactory;

        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //listeleme alanı
        // async method bir dosya okuma, bir API çağrısı yapma veya bir veritabanına erişme 

        public async Task <IActionResult> StaffIndex()
        {
            var client=_httpClientFactory.CreateClient();//istemci oluşturduk

            var responseMessage = await client.GetAsync("https://localhost:7294/api/Staff");
            //istekte bulunduk

            if (responseMessage.IsSuccessStatusCode)//başarılı bir kod dönerse
            {
                var jsondata=await responseMessage.Content.ReadAsStringAsync();
                //gelen veriyi jsondata değişkenine atadık

                var values=JsonConvert.DeserializeObject<List<StaffViewModel>>(jsondata);
                //json formatını c# objesine döndürebilmek için deserialize ettik

                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult StaffAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> StaffAdd(AddStaffViewModel model)
        {
            var client=_httpClientFactory.CreateClient();

            var jsondata=JsonConvert.SerializeObject(model);
            //burda c# olan objeci json formatında dönmesi için biz bunu serialize ettik

            StringContent content = new StringContent(jsondata,Encoding.UTF8,"application/json");
            //içeriğimizin dönüşümü için geçerli olan kod 
            // türkçe karakteri desteklicek şekilde getir

            var responseMessage = await client.PostAsync("https://localhost:7294/api/Staff", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("StaffIndex");
            }
            return View();
        }


        public async Task<IActionResult> StaffDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7294/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("StaffIndex");

            }

            return View();


        }
        [HttpGet]
        public async Task<IActionResult> StaffUpdate(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage=await client.GetAsync($"https://localhost:7294/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //veritabanı sorguları, ağ istekleri veya dosya okuma işlemleri gibi.kodlarda await kullanırı
                // await yazılırsa async method olması lazım

                var values = JsonConvert.DeserializeObject<StaffUpdateViewModel>(jsonData);
                return View(values);

            }

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> StaffUpdate(StaffUpdateViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(model);
            StringContent content= new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7294/api/Staff",content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("StaffIndex");
            }
            return View();


        }




    }
}

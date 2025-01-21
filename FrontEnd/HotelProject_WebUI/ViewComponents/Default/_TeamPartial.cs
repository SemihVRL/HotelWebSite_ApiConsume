using HotelProject_WebUI.Dtos.AboutDto;
using HotelProject_WebUI.Dtos.StaffDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject_WebUI.ViewComponents.Default
{
    public class _TeamPartial:ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public _TeamPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7294/api/Staff");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultStaffDto>>(jsondata);
                //deserialize demek json dan c# tarafına dönmek demek
                return View(values);
            }

            return View();

        }
    }
}

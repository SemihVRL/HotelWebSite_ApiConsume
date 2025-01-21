using Microsoft.AspNetCore.Mvc;

namespace HotelProject_WebUI.ViewComponents.Default
{
    public class _VideoPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

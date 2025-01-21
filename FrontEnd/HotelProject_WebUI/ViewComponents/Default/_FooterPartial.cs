using Microsoft.AspNetCore.Mvc;

namespace HotelProject_WebUI.ViewComponents.Default
{
    public class _FooterPartial:ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}

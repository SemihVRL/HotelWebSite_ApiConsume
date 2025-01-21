using Microsoft.AspNetCore.Mvc;

namespace HotelProject_WebUI.ViewComponents.Default
{
    public class _ReservationPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        { 
            return View(); 
        }
    }
}

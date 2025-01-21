using Microsoft.AspNetCore.Mvc;

namespace HotelProject_WebUI.ViewComponents.Default
{
    public class _SliderPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {  
            return View(); 
        
        }
    }
}

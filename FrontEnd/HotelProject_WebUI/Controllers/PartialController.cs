﻿using Microsoft.AspNetCore.Mvc;

namespace HotelProject_WebUI.Controllers
{
    public class PartialController : Controller
    {
        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }

        public PartialViewResult PreloaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult NavHeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult SidebarPartial()
        {
            return PartialView();
        }

        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }

        public PartialViewResult ScriptsPartial()
        {
            return PartialView();
        }

    }
}

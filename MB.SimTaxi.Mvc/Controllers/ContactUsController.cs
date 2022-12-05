using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MB.SimTaxi.Mvc.Controllers
{
    public class ContactUsController : Controller
    {
        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

    }
}

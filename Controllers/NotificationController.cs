using Microsoft.AspNetCore.Mvc;

namespace OKTECH.Controllers
{
    public class NotificationController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

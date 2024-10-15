using Microsoft.AspNetCore.Mvc;

namespace OKTECH.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index(string inputData)
        {
            return View();
        }
    }
}

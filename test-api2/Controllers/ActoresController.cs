using Microsoft.AspNetCore.Mvc;

namespace test_api2.Controllers
{
    public class ActoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

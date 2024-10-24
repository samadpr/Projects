using Microsoft.AspNetCore.Mvc;

namespace JobPortalSystem_Exercise.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

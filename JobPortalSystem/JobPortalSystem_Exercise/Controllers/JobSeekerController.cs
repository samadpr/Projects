using Microsoft.AspNetCore.Mvc;

namespace JobPortalSystem_Exercise.Controllers
{
    public class JobSeekerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

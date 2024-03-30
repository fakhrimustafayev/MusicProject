using Microsoft.AspNetCore.Mvc;

namespace MusicProject.Areas.admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

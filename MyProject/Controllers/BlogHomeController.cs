using Microsoft.AspNetCore.Mvc;

namespace MyProject.Controllers
{
    public class BlogHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

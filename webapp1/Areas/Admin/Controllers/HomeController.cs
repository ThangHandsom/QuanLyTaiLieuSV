using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        [Authorize(Roles = "1")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

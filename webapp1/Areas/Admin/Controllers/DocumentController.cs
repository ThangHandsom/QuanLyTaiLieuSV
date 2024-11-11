using Microsoft.AspNetCore.Mvc;

namespace WebApp1.Areas.Admin.Controllers
{
    public class DocumentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

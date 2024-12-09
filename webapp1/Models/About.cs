using Microsoft.AspNetCore.Mvc;

namespace WebApp1.Models
{
    public class About : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

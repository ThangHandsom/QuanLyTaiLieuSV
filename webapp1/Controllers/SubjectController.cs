using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class SubjectController : Controller
    {
        private readonly DataContext _context;

        public SubjectController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var subjects = _context.Subjects.ToList();
            return View(subjects);
        }

        [Route("/subject/{alias}-{id}.html")]
        public async Task<IActionResult> Details(int id, string alias)
        {
            var subject = await _context.Subjects
                .Include(s => s.Documents)
                .FirstOrDefaultAsync(s => s.SubjectID == id);

            if (subject == null)
            {
                return NotFound();
            }

            var generatedAlias = GenerateAlias(subject.SubjectName);
            if (!string.Equals(alias, generatedAlias, StringComparison.OrdinalIgnoreCase))
            {
                return RedirectToActionPermanent("Details", new { alias = generatedAlias, id });
            }

            return View(subject);
        }

        private string GenerateAlias(string subjectName)
        {
            return subjectName.ToLower().Replace(" ", "-").Replace(".", "").Replace(",", "");
        }
    }
}

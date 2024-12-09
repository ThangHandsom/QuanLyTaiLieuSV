using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models;
using System.IO;
using System.Threading.Tasks;

namespace WebApp1.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly DataContext _context;

        // Inject DbContext vào controller
        public DocumentsController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Download(int id)
        {
            var document = await _context.Documents
                .FirstOrDefaultAsync(d => d.DocumentID == id);

            if (document == null)
            {
                return NotFound();
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", document.FilePath);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var mimeType = GetMimeType(filePath);

            return File(fileBytes, mimeType, document.DocumentName); 
        }

        private string GetMimeType(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLowerInvariant();
            return extension switch
            {
                ".pdf" => "application/pdf",
                ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                ".doc" => "application/msword",
                ".pptx" => "application/vnd.openxmlformats-officedocument.presentationml.presentation",
                ".ppt" => "application/vnd.ms-powerpoint",
                _ => "application/octet-stream"
            };
        }
    }
}

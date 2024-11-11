using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models;
using X.PagedList.Extensions;

namespace WebApp1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogCommentsController : Controller
    {
        private readonly DataContext _context;

        public BlogCommentsController(DataContext context)
        {
            _context = context;
        }

        // GET: Admin/BlogComments
        public async Task<IActionResult> Index(int id)
        {
            var blog = await _context.Blogs
                .Include(b => b.Account)
                .FirstOrDefaultAsync(b => b.BlogID == id);

            if (blog == null)
            {
                return NotFound(); 
            }

            var blogComments = await _context.BlogComments
                .Where(bc => bc.BlogID == id)
                .Include(bc => bc.Account)
                .Include(bc => bc.Blog)
                .ToListAsync();

            ViewBag.BlogTitle = blog.Title;

            ViewData["Blog"] = blog;
            return View(blogComments);
        }


        // GET: Admin/BlogComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogComment = await _context.BlogComments
                .Include(b => b.Account)
                .Include(b => b.Blog)
                .FirstOrDefaultAsync(m => m.BlogCommentID == id);
            if (blogComment == null)
            {
                return NotFound();
            }

            return View(blogComment);
        }


        // GET: Admin/BlogComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BlogComments == null)
            {
                return NotFound();
            }

            var blogComment = await _context.BlogComments
                .Include(b => b.Account)
                .Include(b => b.Blog)
                .FirstOrDefaultAsync(m => m.BlogCommentID == id);
            if (blogComment == null)
            {
                return NotFound();
            }

            return View(blogComment);
        }

        // POST: Admin/BlogComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BlogComments == null)
            {
                return Problem("Entity set 'DataContext.BlogComments'  is null.");
            }
            var blogComment = await _context.BlogComments.FindAsync(id);
            if (blogComment != null)
            {
                _context.BlogComments.Remove(blogComment);
            }
            var blogtId = blogComment.BlogID; // Lấy id của sản phẩm liên quan đến đánh giá này

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "BlogComments", new { id = blogtId });
        }

        private bool BlogCommentExists(int id)
        {
            return _context.BlogComments.Any(e => e.BlogCommentID == id);
        }
    }
}

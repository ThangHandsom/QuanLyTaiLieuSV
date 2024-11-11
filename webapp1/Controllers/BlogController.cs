using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using WebApp1.Models;
using X.PagedList.Extensions;

namespace WebApp1.Controllers
{
    public class BlogController : Controller
    {
        private readonly DataContext _context;
        public BlogController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 2;
            var blogs = _context.Blogs.Where(i => (bool)i.IsActive).OrderByDescending(i => i.BlogID).ToPagedList((int)page, pageSize);
            ViewBag.blogComment = _context.BlogComments.ToList();
            return View(blogs);
        }
        [Route("/blog/{alias}-{id}.html")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Blogs == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs
                .FirstOrDefaultAsync(m => m.BlogID == id);
            if (blog == null)
            {
                return NotFound();
            }

            ViewBag.blogComment = _context.BlogComments
                .Include(c => c.Account)
                .Where(i => i.BlogID == id)
                .ToList();

            return View(blog);
        }

        //tạo bình luận cho bài viết
        [HttpPost]
        public IActionResult Create(string message, int blogId, int? parentCommentId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                TempData["Message"] = "Bạn cần đăng nhập để đăng bình luận.";
                return RedirectToAction("Login", "Account");
            }

            var blog = _context.Blogs.SingleOrDefault(b => b.BlogID == blogId);
            if (blog == null)
            {
                ModelState.AddModelError("", "Blog không tồn tại!");
                return View();
            }

            if (parentCommentId.HasValue)
            {
                //  trả lời (SubComment)
                var parentComment = _context.BlogComments.SingleOrDefault(bc => bc.BlogCommentID == parentCommentId.Value);
                if (parentComment == null)
                {
                    TempData["Message"] = "Bình luận gốc không tồn tại!";
                    return RedirectToAction("Index", "Blog");
                }

                // Tạo mới SubComment
                var subComment = new SubComment
                {
                    Detail = message,
                    BlogCommentID = parentCommentId.Value,
                    CreatedDate = DateTime.Now,
                    AccountID = GetUserAccountId()
                };

                try
                {
                    _context.SubComments.Add(subComment);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Lỗi khi lưu trả lời: {ex.Message}");
                    return View();
                }
            }
            else
            {
                // bình luận chính (BlogComment)
                var blogComment = new BlogComment
                {
                    Detail = message,
                    BlogID = blogId,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    AccountID = GetUserAccountId()
                };

                try
                {
                    _context.BlogComments.Add(blogComment);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Lỗi khi lưu bình luận: {ex.Message}");
                    return View();
                }
            }

            return RedirectToAction("Index", "Blog");
        }


        private int GetUserAccountId()
        {
            // Lấy AccountId từ claim
            var accountIdClaim = User.FindFirst("AccountId");

            if (accountIdClaim != null)
            {
                return int.Parse(accountIdClaim.Value); // Chuyển giá trị AccountId thành số nguyên và trả về
            }

            // Nếu không tìm thấy claim "AccountId", ném ngoại lệ
            throw new UnauthorizedAccessException("Account ID not found.");
        }

    }
}

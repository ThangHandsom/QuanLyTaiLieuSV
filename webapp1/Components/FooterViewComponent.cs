using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models; // Đảm bảo có class Footer trong Models của bạn

namespace WebApp1.Components
{
    [ViewComponent(Name = "Footer")]
    public class FooterViewComponent : ViewComponent
    {
        private readonly DataContext _context; // Hoặc sử dụng dịch vụ phù hợp

        public FooterViewComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Lấy thông tin Footer từ cơ sở dữ liệu hoặc từ một nguồn khác
            var footer = await _context.Footers.FirstOrDefaultAsync(); // Lấy dữ liệu từ DB
            return View("Default", footer); // Trả về Partial View
        }
    }
}

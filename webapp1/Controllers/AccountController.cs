using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Principal;
using WebApp1.Utilities;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Accounts.SingleOrDefault(u => u.UserName == username);

            if (user == null || !VerifyPassword(password, user.Password))
            {
                Functions._Message = "Sai tên đăng nhập hoặc mật khẩu!";
                return View("Login");
            }

            Functions._Message = string.Empty;

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Role, user.RoleID.ToString()),
        new Claim("AccountId", user.AccountID.ToString())
    };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity)
            );

            if (user.RoleID == 1 || user.RoleID == 2) 
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (user.RoleID == 3)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Login");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(string Username, string Password, string FullName, string Phone, string Email, string Classs, string Studentcode, string Gender, DateTime Birth)
        {
            try
            {
                if (_context.Accounts.Any(u => u.UserName == Username))
                {
                    Functions._Message = "Tài khoản đã tồn tại!";
                    return View();
                }

                var newUser = new Account
                {
                    UserName = Username,
                    Password = Password,
                    FullName = FullName,
                    Phone = Phone,
                    Class = Classs,
                    StudentCode = Studentcode,
                    Email = Email,
                    Gender = Gender,
                    Birth = Birth,
                    IsActive = true,
                    RoleID = 3,
                };
                Functions._Message = string.Empty;

                newUser.Password = HashMD5.GetHash(newUser.Password != null ? newUser.Password : "");
                _context.Accounts.Add(newUser);
                _context.SaveChanges();
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, newUser.UserName),
                    new Claim(ClaimTypes.Role, newUser.RoleID.ToString()),
                     new Claim("AccountId", newUser.AccountID.ToString()) // Thêm AccountId vào claims

                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity)
                );

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Đã xảy ra lỗi khi đăng ký.");
                return View();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        private bool VerifyPassword(string enteredPassword, string storedPasswordHash)
        {
            string enteredPasswordHash = HashMD5.GetHash(enteredPassword);
            return enteredPasswordHash == storedPasswordHash;
        }
        //Đổi mật khẩu
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(string oldPassword, string newPassword)
        {
            var username = User.Identity.Name;
            var user = _context.Accounts.SingleOrDefault(u => u.UserName == username);

            if (user == null || user.Password != oldPassword)
            {
                ModelState.AddModelError(string.Empty, "Mật khẩu cũ không đúng.");
                return View();
            }

            user.Password = newPassword;
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        //Trang cá nhân
        public IActionResult Profile()
        {
            var username = User.Identity.Name;
            var user = _context.Accounts.SingleOrDefault(u => u.UserName == username);

            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }
        //Cập nhật thông tin cá nhân
        public IActionResult UpdateProfile()
        {
            var username = User.Identity.Name;
            var user = _context.Accounts.SingleOrDefault(u => u.UserName == username);

            if (user == null)
            {
                return NotFound();
            }

            return View(user); 
        }

        [HttpPost]
        public IActionResult UpdateProfile(string fullName, string phone, string email, string classs, string studentcode, DateTime? birth, IFormFile? imageFile)
        {
            var username = User.Identity.Name;
            var user = _context.Accounts.SingleOrDefault(u => u.UserName == username);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found.");
                return View(user);
            }

            user.FullName = fullName;
            user.Phone = phone;
            user.Email = email;
            user.Class = classs;
            user.StudentCode = studentcode;
            user.Birth = birth;

            if (imageFile != null && imageFile.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imageFile.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                user.Image = "/images/" + imageFile.FileName;
            }

            _context.SaveChanges();

            return RedirectToAction("Profile", "Account");
        }

        //Quên mật khẩu
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FogotPassword()
        {
            return View();
        }
    }
}

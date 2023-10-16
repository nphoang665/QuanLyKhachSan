using Microsoft.AspNetCore.Mvc;
using QuanLyKhachSan.DataAcess.Data;
using QuanLyKhachSan.Model;
using System.Linq;

namespace QuanLyKhachSan.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _db;
        public LoginController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(TaiKhoan obj)
        {
            var account = _db.TaiKhoan.FirstOrDefault(s => s.TenDangNhap == obj.TenDangNhap && s.MatKhau == obj.MatKhau);
            if (account == null)
            {
                // Tài khoản hoặc mật khẩu không chính xác
                TempData["Error"] = "Đăng nhập không thành công do sai tài khoản hoặc mật khẩu";
                return View();
            }
            else
            {
                // Đăng nhập thành công, chuyển hướng đến trang chủ
                return RedirectToAction("Index", "TongQuan");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DangKy(TaiKhoan tk)
        {
            if (ModelState.IsValid)
            {

                _db.TaiKhoan.Add(tk);
                _db.SaveChanges();
                TempData["notification"] = "Đăng ký thành công.";
            }
            return RedirectToAction("Index", "Login");
        }



    }
}

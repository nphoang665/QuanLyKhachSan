using Microsoft.AspNetCore.Mvc;
using QuanLyKhachSan.DataAcess.Data;
using QuanLyKhachSan.Model;

namespace QuanLyKhachSan.Controllers
{
    public class DangKyController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DangKyController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(TaiKhoan tk)
        {
            if (ModelState.IsValid)
            {
                _db.TaiKhoan.Add(tk);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "Login");
        }
    }
}

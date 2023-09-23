using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.DataAcess.Data;
using QuanLyKhachSan.Model;

namespace QuanLyKhachSan.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly ApplicationDbContext _db;
        public KhachHangController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
        var khachHangs= await _db.KhachHangs.ToListAsync();
            return View(khachHangs);    
        }
        public IActionResult ThemKhachHang()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ThemKhachHang(KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                _db.Add(khachHang);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khachHang);
        }

    }
}

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
        [ValidateAntiForgeryToken]
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
        public IActionResult SuaKhachHang(string? id)
        {
          
            var categoryFromDb = _db.KhachHangs.FirstOrDefault(s => s.MaKhachHang == id);

            return View(categoryFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaKhachHang(KhachHang kh)
        {
            _db.KhachHangs.Update(kh);
            _db.SaveChanges();
            return RedirectToAction("Index","KhachHang");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult XoaKhachHang(string? id)
        {
            var kh = _db.KhachHangs.FirstOrDefault(s => s.MaKhachHang == id);
           if(kh == null)
            {
                return NotFound();
            }
           _db.KhachHangs.Remove(kh);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}

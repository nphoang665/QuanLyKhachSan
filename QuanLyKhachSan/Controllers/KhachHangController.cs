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
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 1;
            int totalKhachHangs = await _db.KhachHangs.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalKhachHangs / pageSize);

            if (page < 1)
                page = 1;
            else if (page > totalPages)
                page = totalPages;

            var paginatedKhachHangs = await _db.KhachHangs
                .OrderBy(kh => kh.MaKhachHang)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewData["TotalPages"] = totalPages;
            ViewData["CurrentPage"] = page;

            return View(paginatedKhachHangs);
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

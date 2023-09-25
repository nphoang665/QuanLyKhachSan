using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.DataAcess.Data;
using QuanLyKhachSan.Model;

namespace QuanLyKhachSan.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly ApplicationDbContext _db;
        public NhanVienController(ApplicationDbContext db)
        {
            _db= db;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 1;
            int totalKhachHangs = await _db.NhanViens.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalKhachHangs / pageSize);

            if (page < 1)
                page = 1;
            else if (page > totalPages)
                page = totalPages;

            var paginatedKhachHangs = await _db.NhanViens
                .OrderBy(kh => kh.MaNhanVien)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewData["TotalPagesNhanVien"] = totalPages;
            ViewData["CurrentPageNhanVien"] = page;

            return View(paginatedKhachHangs);
        }
        public IActionResult ThemNhanVien()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ThemNhanVien(NhanVien nhanvien)
        {
            if (ModelState.IsValid)
            {
                _db.NhanViens.Add(nhanvien);
              await  _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(nhanvien);
        }
        public IActionResult SuaNhanVien(string? id)
        {
            var nhanVienFromDb = _db.NhanViens.FirstOrDefault(s=>s.MaNhanVien == id);

            return View(nhanVienFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaNhanVien(NhanVien nv)
        {
            if (ModelState.IsValid)
            {
                _db.NhanViens.Update(nv);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nv);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult XoaNhanVien(string? id)
        {
            var nv = _db.NhanViens.FirstOrDefault(s => s.MaNhanVien == id);
            _db.NhanViens.Remove(nv);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

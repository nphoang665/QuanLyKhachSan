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
        public async Task<IActionResult> Index()
        {
            var nhanviens = await _db.NhanViens.ToListAsync();
            return View(nhanviens);
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

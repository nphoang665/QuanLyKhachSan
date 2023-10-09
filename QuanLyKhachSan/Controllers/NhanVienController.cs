using MailKit.Search;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
            _db = db;
        }
        public async Task<IActionResult> Index(string searchText, string gender, string ChucVu, int page = 1)
        {
            int pageSize = 7;
            int totalKhachHangs = await _db.NhanViens.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalKhachHangs / pageSize);

            // Lọc kết quả theo từ khóa tìm kiếm

            var khachHangs = _db.NhanViens.AsQueryable();
            // Lọc kết quả theo giới tính
            if (!String.IsNullOrEmpty(gender))
            {
                khachHangs = khachHangs.Where(kh => kh.GioiTinh == gender);
            }
            if (!String.IsNullOrEmpty(searchText))
            {
                khachHangs = khachHangs.Where(kh => kh.TenNhanVien.Contains(searchText));
            }

            // Lọc theo chức vụ
            if (!String.IsNullOrEmpty(ChucVu))
            {
                khachHangs = khachHangs.Where(kh => kh.ChucVu.Contains(ChucVu));
            }

            // Phân trang kết quả
            var paginatedKhachHangs = await khachHangs
                .OrderBy(kh => kh.MaNhanVien)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Trả về view
            ViewData["TotalPages"] = totalPages;
            ViewData["CurrentPage"] = page;
            ViewData["searchText"] = khachHangs;
            return View(paginatedKhachHangs);
        }


        // Trong Controller của bạn
        [HttpGet]
        public IActionResult ThemNhanVien()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemNhanVien(NhanVien model)
        {
            if (ModelState.IsValid)
            {
                _db.NhanViens.Add(model);
               _db.SaveChangesAsync();
                return RedirectToAction("Index"); 
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult SuaNhanVien(string id)
        {
            var nv = _db.NhanViens.FirstOrDefault(s=> s.MaNhanVien==id);
            return View(nv);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaNhanVien(NhanVien model)
        {
            if (ModelState.IsValid)
            {
                _db.NhanViens.Update(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
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

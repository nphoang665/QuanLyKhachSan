using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.DataAcess.Data;
using QuanLyKhachSan.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace QuanLyKhachSan.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly ApplicationDbContext _db;
        public KhachHangController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index(string searchText, string gender, string TrangThai, int page = 1)
        {

            int pageSize = 7;
            int totalKhachHangs = await _db.KhachHangs.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalKhachHangs / pageSize);
            var khachHangs = _db.KhachHangs.AsQueryable();

            // Lọc kết quả theo giới tính
            if (!String.IsNullOrEmpty(gender))
            {
                khachHangs = khachHangs.Where(kh => kh.GioiTinh == gender);
            }
            // Lọc kết quả theo từ khóa tìm kiếm


            if (!String.IsNullOrEmpty(searchText))
            {
                khachHangs = khachHangs.Where(kh => kh.TenKhachHang.Contains(searchText));
            }
            // Lọc theo trạng thái
            if (!String.IsNullOrEmpty(TrangThai))
            {
                khachHangs = khachHangs.Where(kh => kh.GhiChu == TrangThai);
            }
            // Phân trang kết quả
            var paginatedKhachHangs = await khachHangs
                .OrderBy(kh => kh.MaKhachHang)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            // Lấy giá trị của radio button
            // Trả về view
            ViewData["TotalPages"] = totalPages;
            ViewData["CurrentPage"] = page;
            ViewData["searchText"] = khachHangs;
            ViewData["gender"] = gender;
            ViewData["TrangThai"] = TrangThai;
            return View(paginatedKhachHangs);

        }




        [HttpGet]
        public IActionResult ThemKhachHang()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemKhachHang(KhachHang model)
        {
            if (ModelState.IsValid)
            {
                _db.KhachHangs.Add(model);
                _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult SuaKhachHang(string id)
        {
            var nv = _db.KhachHangs.FirstOrDefault(s => s.MaKhachHang == id);
            return View(nv);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaKhachHang(KhachHang model)
        {
            if (ModelState.IsValid)
            {
                _db.KhachHangs.Update(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult XoaKhachHangPartical(string? id)
        {
            var kh = _db.KhachHangs.FirstOrDefault(s => s.MaKhachHang == id);
            if (kh == null)
            {
                return NotFound();
            }
            _db.KhachHangs.Remove(kh);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Search(string searchText)
        {
            var allkhachhang = _db.KhachHangs.ToList();
       
            if (searchText == null)
            {
                return PartialView("_KhachHangPartial", allkhachhang);
            }
            else
            {
 var khachHangs = await _db.KhachHangs
                .Where(kh => kh.TenKhachHang.Contains(searchText.Trim())) // Thay ".TenKhachHang" bằng thuộc tính bạn muốn tìm kiếm
                .ToListAsync();

            return PartialView("_KhachHangPartial", khachHangs); // Trả về một PartialView chứa kết quả tìm kiếm
            }
           
        }

    }
}

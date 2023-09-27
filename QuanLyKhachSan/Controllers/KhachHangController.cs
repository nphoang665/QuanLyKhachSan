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
            int pageSize = 7;
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

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ThemKhachHang()
        {
                var formCollection = Request.Form;
            var khachHang = new KhachHang();
            khachHang.MaKhachHang = formCollection["MaKhachHang"];
            khachHang.TenKhachHang = formCollection["TenKhachHang"];
            khachHang.GioiTinh = formCollection["GioiTinh"];
            khachHang.NgaySinh = DateTime.Parse(formCollection["NgaySinh"]);
            khachHang.DienThoai = formCollection["DienThoai"];
            khachHang.DiaChi = formCollection["DiaChi"];
            khachHang.GhiChu = formCollection["GhiChu"];
            if (ModelState.IsValid)
            {
                _db.KhachHangs.Add(khachHang);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(khachHang);
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SuaKhachHang()
        {
            var formCollection = Request.Form;
            var khachHang = new KhachHang();
            khachHang.MaKhachHang = formCollection["MaKhachHangSua"];
            khachHang.TenKhachHang = formCollection["TenKhachHangSua"];
            khachHang.GioiTinh = formCollection["GioiTinhSua"];
            khachHang.NgaySinh = DateTime.Parse(formCollection["NgaySinhSua"]);
            khachHang.DienThoai = formCollection["DienThoaiSua"];
            khachHang.DiaChi = formCollection["DiaChiSua"];
            khachHang.GhiChu = formCollection["GhiChuSua"];
            if (ModelState.IsValid)
            {
                _db.KhachHangs.Update(khachHang);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(khachHang);
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
                .Where(kh => kh.TenKhachHang.Contains(searchText)) // Thay ".TenKhachHang" bằng thuộc tính bạn muốn tìm kiếm
                .ToListAsync();

            return PartialView("_KhachHangPartial", khachHangs); // Trả về một PartialView chứa kết quả tìm kiếm
            }
           
        }

    }
}

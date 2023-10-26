using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyKhachSan.DataAcess.Data;

namespace QuanLyKhachSan.Controllers
{
    
    public class HoSoController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HoSoController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string id)
        {
            var employee = _db.NhanViens.FirstOrDefault(s => s.MaNhanVien == id);
            if (employee != null)
            {
                return View(employee); // Truyền dữ liệu vào view
            }
            else
            {
                return NotFound(); // Trả về lỗi nếu không tìm thấy nhân viên
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LuuEmailMoi(string manhanvien, string email, string tendangnhap)
        {
            var _tk = _db.TaiKhoan.FirstOrDefault(s => s.TenDangNhap == tendangnhap);
            _tk.Email = email;
            _db.TaiKhoan.Update(_tk);
            _db.SaveChanges();
            var _nhanvien = _db.NhanViens.FirstOrDefault(s => s.MaNhanVien == manhanvien);
            _nhanvien.Email = email;
            _db.NhanViens.Update(_nhanvien);
            _db.SaveChanges();

            return RedirectToAction("Index", "HoSo", new { id = manhanvien });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DoiMatKhauHoSo(string manhanvien,string tendangnhap, string mkHienTai, string mkMoi, string xacThucMkMoi)
        {
            var _doiMatKhau = _db.TaiKhoan.FirstOrDefault(s => s.TenDangNhap == tendangnhap && s.MatKhau==mkHienTai);
            if (_doiMatKhau != null)
            {
                _doiMatKhau.MatKhau = mkMoi;
                _db.TaiKhoan.Update(_doiMatKhau);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "HoSo", new { id = manhanvien });

        }
    }
}

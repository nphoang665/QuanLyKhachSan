using Microsoft.AspNetCore.Mvc;
using QuanLyKhachSan.DataAcess.Data;
using QuanLyKhachSan.Model;
using System.Net.WebSockets;

namespace QuanLyKhachSan.Controllers
{
    public class PhongController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PhongController(ApplicationDbContext db)
        {
            _db= db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NhanPhong(string HangPhong,string MaKhachHang,string Phong, string HinhThuc,DateTime Ngaynhan,DateTime NgayTra,string DuKien, double ThanhTien)
        {
            var nhanphong = new DatPhong();
            nhanphong.HangPhong = HangPhong;
            nhanphong.MaKhachHang = MaKhachHang;
            nhanphong.Phong= Phong;
            nhanphong.HinhThuc = HinhThuc;
            nhanphong.NgayNhan = Ngaynhan;
            nhanphong.NgayTra = NgayTra;
            nhanphong.DuKien = "1";
            nhanphong.ThanhTien = 10000;
            
            _db.DatPhongs.Add(nhanphong);
            _db.SaveChanges();
            return View(nhanphong);
        }
    }
}

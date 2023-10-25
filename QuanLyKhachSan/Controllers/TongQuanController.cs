﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.DataAcess.Data;

namespace QuanLyKhachSan.Controllers
{
    public class TongQuanController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TongQuanController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()

        {
           
            return View();
        }
        [HttpPost]
        public IActionResult LayTinhTrangPhong()
        {
            var phongDaDat = _db.DatPhongs.Select(x => x.MaPhong).Count();
            var soluongphong = _db.Phong.Select(s => s.MaPhong).Count();
            var PhongTrong = soluongphong-phongDaDat;

            // Trả về dữ liệu dưới dạng JSON
            return Json(new { PhongTrong = PhongTrong, phongDaDat = phongDaDat });
        }
        public IActionResult LayDoanhThuTheoThang()
        {
            var doanhThuTheoThang = _db.HoaDon
                .GroupBy(hd => new { hd.NgayTra.Year, hd.NgayTra.Month })
                .Select(g => new
                {
                    Thang = g.Key.Month,
                    Nam = g.Key.Year,
                    DoanhThu = g.Sum(hd => hd.ThanhTien)
                })
                .ToList();

            return Json(doanhThuTheoThang);
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
			_db = db;
		}

		public IActionResult Index()
		{
			var rooms = _db.Phong.ToList();
			ViewBag.Rooms = rooms;
			var khachhangs = _db.KhachHangs.ToList();
			ViewBag.KhachHangs = khachhangs;
			var bookedRooms = _db.DatPhongs.Select(p => p.Phong).ToList();
			ViewBag.BookedRooms = bookedRooms;

			return View();
		}

		[HttpPost]
		public IActionResult NhanPhong(string MaDatPhong, string Phong, string HangPhong, string MaKhachHang, string HinhThuc, float GiaPhong, DateTime NgayNhan, DateTime NgayTra, string DuKien, float ThanhTien)
		{
			var nhanphong = new DatPhong();
			nhanphong.MaDatPhong = MaDatPhong;
			nhanphong.Phong = Phong;
			nhanphong.HangPhong = HangPhong;
			nhanphong.MaKhachHang = MaKhachHang;
			nhanphong.HinhThuc = HinhThuc;
			nhanphong.GiaPhong = GiaPhong;
			nhanphong.NgayNhan = NgayNhan;
			nhanphong.NgayNhan = NgayTra;
			nhanphong.DuKien = DuKien;
			nhanphong.ThanhTien = ThanhTien;

			_db.DatPhongs.Add(nhanphong);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public string GetHangPhong(string maPhong)
		{

			var phong = _db.Phong.Find(maPhong);
			return phong.HangPhong;


		}
		[HttpGet]
		public IActionResult LayThanhToan(string maPhong)
		{
			var datPhong = _db.DatPhongs.FirstOrDefault(s => s.Phong == maPhong);
			return Json(datPhong);
		}
		[HttpGet]
		public IActionResult LayTenKhachHang(string maPhong)
		{
			var phong = _db.DatPhongs.FirstOrDefault(s => s.Phong == maPhong);
			var tenkhachhang = _db.KhachHangs.FirstOrDefault(s => s.MaKhachHang == phong.MaKhachHang);
			return Json(tenkhachhang);
		}
		[HttpPost]
		public IActionResult ThanhToan(string Phong)
		{
		var datphong=	_db.DatPhongs.FirstOrDefault(s => s.Phong == Phong);
			_db.DatPhongs.Remove(datphong);
			_db.SaveChanges();
			return RedirectToAction("Index");	
		}


	}
}

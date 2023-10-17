using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.DataAcess.Data;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;


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
			var bookedRooms = _db.DatPhongs.Select(p => p.MaPhong).ToList();
			ViewBag.BookedRooms = bookedRooms;
			var nhanvien = _db.NhanViens.ToList();
			ViewBag.NhanViens = nhanvien;

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> NhanPhong(string MaDatPhong, string Phong, string MaKhachHang, string HinhThuc, int GiaPhong, DateTime NgayNhan, DateTime NgayTra, string DuKien, float ThanhTien, string MaNhanVien)
		{

			var nhanphong = new DatPhong();
			nhanphong.MaDatPhong = MaDatPhong;
			nhanphong.MaPhong = Phong;
			nhanphong.MaNhanVien = MaNhanVien;
			nhanphong.MaKhachHang = MaKhachHang;
			nhanphong.HinhThuc = HinhThuc;
			nhanphong.GiaPhong = GiaPhong;
			nhanphong.NgayNhan = NgayNhan;
			nhanphong.NgayTra = NgayTra;
			nhanphong.DuKien = DuKien;
			nhanphong.ThanhTien = ThanhTien;



			_db.DatPhongs.Add(nhanphong);
			_db.SaveChanges();

			var phongDaDat = _db.Phong.FirstOrDefault(s => s.MaPhong == Phong);
			phongDaDat.TrangThai = "Đang sử dụng";
			_db.SaveChanges();
			return RedirectToAction("Index");

		}

		[HttpGet]
		public string GetHangPhong(string maPhong)
		{
			var phong = _db.Phong.Find(maPhong);
			if (phong != null)
			{
				return phong.HangPhong;
			}
			return "Không có hạng phòng trùng khớp";
		}

		[HttpGet]
		public IActionResult LayThanhToan(string maPhong)
		{
			var datPhong = _db.DatPhongs.FirstOrDefault(s => s.MaPhong == maPhong);
			return Json(datPhong);
		}
		[HttpGet]
		public IActionResult LayTenKhachHang(string maPhong)
		{
			var phong = _db.DatPhongs.FirstOrDefault(s => s.MaPhong == maPhong);
			if (phong != null)
			{
				var tenkhachhang = _db.KhachHangs.FirstOrDefault(s => s.MaKhachHang == phong.MaKhachHang);
				if (tenkhachhang != null)
				{
					return Json(tenkhachhang);
				}
			}
			return Json(new { error = "không có tên khách hàng trùng khớp" });
		}

		[HttpPost]
		public IActionResult ThanhToan(string Phong)
		{
			var datphong = _db.DatPhongs.FirstOrDefault(s => s.MaPhong == Phong);
			var PhongThanhToan = _db.Phong.FirstOrDefault(s => s.MaPhong == Phong);
			PhongThanhToan.TrangThai = "Trống";
			_db.SaveChanges();
			_db.DatPhongs.Remove(datphong);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult CheckRoom(string maPhong)
		{
			var datphong = _db.DatPhongs.FirstOrDefault(s => s.MaPhong == maPhong);
			return Json(datphong != null);
		}
		[HttpGet]
		public JsonResult GetRooms()
		{
			var rooms = _db.Phong.ToList(); // Thay đổi này để phù hợp với cấu trúc dữ liệu của bạn
			return Json(rooms);
		}
		[HttpGet]
		public async Task<IActionResult> GetRoomPrice(string maPhong)
		{
			// Tìm phòng với mã phòng đã cho
			var phong = await _db.Phong.FirstOrDefaultAsync(p => p.MaPhong == maPhong);

			if (phong == null)
			{
				// Nếu không tìm thấy phòng, trả về một lỗi 404
				return NotFound();
			}

			// Trả về giá theo giờ và giá theo ngày của phòng
			return Ok(new { GiaTheoGio = phong.GiaTheoGio, GiaTheoNgay = phong.GiaTheoNgay });
		}

	}
}

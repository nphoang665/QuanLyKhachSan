using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.DataAcess.Data;
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
		public async Task<IActionResult> NhanPhong(string MaDatPhong, string Phong, string MaKhachHang, string HinhThuc, int GiaPhong, DateTime? NgayNhan, DateTime? NgayTra, string DuKien, float ThanhTien, string MaNhanVien,float khachTra)
		{
		
			var MadatPhongExist = _db.DatPhongs.FirstOrDefault(s => s.MaDatPhong == MaDatPhong);
			if (string.IsNullOrEmpty(MaDatPhong))
			{
				return Json(new { success = false, message = "Mã đặt phòng không được để trống." });
			}
			if(MadatPhongExist != null)
			{
				return Json(new { success = false, message = "Mã đặt phòng đã tồn tại." });
			}
			if (MaDatPhong.Length != 6)
			{
				return Json(new { success = false, message = "Mã đặt phòng phải là 6 kí tự." });
			}
			// Kiểm tra ngày nhận
			if (NgayNhan == null)
			{
				return Json(new { success = false, message = "Ngày nhận không được để trống." });
			}

			// Kiểm tra ngày trả
			if (NgayTra == null)
			{
				return Json(new { success = false, message = "Ngày trả không được để trống." });
			}
			if (NgayTra < NgayNhan)
			{
				return Json(new { success = false, message = "Lỗi. Ngày trả phòng không được nhỏ hơn ngày nhận phòng." });
			}

			// Kiểm tra ngày đặt
			if (NgayNhan.Value.Date < DateTime.Today)
			{
				return Json(new { success = false, message = "Ngày đặt không được nhỏ hơn ngày hôm nay." });
			}

			if (ModelState.IsValid)
			{
				var nhanphong = new DatPhong();
				nhanphong.MaDatPhong = MaDatPhong;
				nhanphong.MaPhong = Phong;
				nhanphong.MaNhanVien = MaNhanVien;
				nhanphong.MaKhachHang = MaKhachHang;
				nhanphong.HinhThuc = HinhThuc;
				nhanphong.GiaPhong = GiaPhong;

				if (NgayNhan.HasValue)
				{
					nhanphong.NgayNhan = NgayNhan.Value;
				}

				if (NgayTra.HasValue)
				{
					nhanphong.NgayTra = NgayTra.Value;
				}

				nhanphong.DuKien = DuKien;
				nhanphong.ThanhTien = ThanhTien;

				_db.DatPhongs.Add(nhanphong);
			await _db.SaveChangesAsync();

				var phongDaDat = _db.Phong.FirstOrDefault(s => s.MaPhong == Phong);
				phongDaDat.TrangThai = "Đang sử dụng";
			await _db.SaveChangesAsync();
				float tongtienkhachdatra = ThanhTien - khachTra;
				var tinhTienKhachHangTra = _db.DatPhongs.FirstOrDefault(s => s.MaDatPhong == MaDatPhong);
				tinhTienKhachHangTra.ThanhTien = tongtienkhachdatra;
				await _db.SaveChangesAsync();
				return Json(new { success = true, message = "Đặt phòng thành công." });
			}
			else
			{
				return Json(new { success = false, message = "Đặt phòng không thành công." });
			}
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
		public JsonResult ThanhToan(string Phong, string khachDaThanhToan)
		{
			float khachDaThanhToanSo;
			bool laSo = float.TryParse(khachDaThanhToan, out khachDaThanhToanSo);

			if (!laSo)
			{
				return Json(new { success = false, message = "Lỗi. Vui lòng nhập số." });
			}

			var LayTongTien = _db.DatPhongs.FirstOrDefault(s => s.MaPhong == Phong);

			if (khachDaThanhToanSo < LayTongTien.ThanhTien)
			{
				return Json(new { success = false, message = "Số tiền thanh toán không đủ. Vui lòng thanh toán đủ số tiền." });
			}

			else
			{
				var datphong = _db.DatPhongs.FirstOrDefault(s => s.MaPhong == Phong);
				var PhongThanhToan = _db.Phong.FirstOrDefault(s => s.MaPhong == Phong);
				PhongThanhToan.TrangThai = "Trống";
				_db.SaveChanges();
				_db.DatPhongs.Remove(datphong);
				_db.SaveChanges();

				return Json(new { success = true, message = "Thanh toán thành công. Cảm ơn bạn đã sử dụng dịch vụ của chúng tôi." });
			}
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
			var rooms = _db.Phong.ToList(); 
			return Json(rooms);
		}
		[HttpGet]
		public async Task<IActionResult> GetRoomPrice(string maPhong)
		{
			var phong = await _db.Phong.FirstOrDefaultAsync(p => p.MaPhong == maPhong);

			if (phong == null)
			{
				return NotFound();
			}

			return Ok(new { GiaTheoGio = phong.GiaTheoGio, GiaTheoNgay = phong.GiaTheoNgay });
		}

	}
}

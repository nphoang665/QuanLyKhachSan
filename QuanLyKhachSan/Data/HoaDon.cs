using QuanLyKhachSan.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyKhachSan.Data
{
	public class HoaDon
	{
		[Key]
		public string MaHoaDon { get; set; }

		public string MaDatPhong { get; set; }

		// Thêm khóa ngoại từ bảng NhanVien
		public string MaNhanVien { get; set; }

		// Thêm khóa ngoại từ bảng Phong
		public string MaPhong { get; set; }

		// Thêm khóa ngoại từ bảng KhachHang
		public string MaKhachHang { get; set; }

		public string HinhThuc { get; set; }
		public int GiaPhong { get; set; }
		public DateTime NgayNhan { get; set; }
		public DateTime NgayTra { get; set; }
		public string DuKien { get; set; }
		public float ThanhTien { get; set; }
	}
}

using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.Data;
using QuanLyKhachSan.Model;


namespace QuanLyKhachSan.DataAcess.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		public DbSet<TaiKhoan> TaiKhoan { get; set; }
		public DbSet<KhachHang> KhachHangs { get; set; }
		public DbSet<NhanVien> NhanViens { get; set; }
		public DbSet<DatPhong> DatPhongs { get; set; }
		public DbSet<Room> Phong { get; set; }
		public DbSet<HoaDon> HoaDon { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<KhachHang>().HasData(
		new KhachHang { MaKhachHang = "KH0001", TenKhachHang = "Nguyễn Văn An", CCCD = "123432156789", GioiTinh = "Nam", NgaySinh = new DateTime(1980, 1, 1), DienThoai = "0938481234", DiaChi = "Hà Nội", NgayTao = DateTime.Now, GhiChu = "Không" },
		new KhachHang { MaKhachHang = "KH0002", TenKhachHang = "Trần Thị Bé", CCCD = "987654232321", GioiTinh = "Nữ", NgaySinh = new DateTime(1985, 2, 2), DienThoai = "0938484567", DiaChi = "TP Hồ Chí Minh", NgayTao = DateTime.Now, GhiChu = "Không" },
		new KhachHang { MaKhachHang = "KH0003", TenKhachHang = "Huỳnh An Cao", CCCD = "123432156734", GioiTinh = "Nam", NgaySinh = new DateTime(1988, 2, 2), DienThoai = "0938485966", DiaChi = "TP Hồ Chí Minh", NgayTao = DateTime.Now, GhiChu = "Không" },
		new KhachHang { MaKhachHang = "KH0004", TenKhachHang = "Nguyễn Thị Bích", CCCD = "123432156754", GioiTinh = "Nữ", NgaySinh = new DateTime(1995, 2, 2), DienThoai = "0938234166", DiaChi = "TP Hồ Chí Minh", NgayTao = DateTime.Now, GhiChu = "Không" },
		new KhachHang { MaKhachHang = "KH0005", TenKhachHang = "Hồ Thị Mỹ", CCCD = "123432156785", GioiTinh = "Nữ", NgaySinh = new DateTime(1985, 2, 2), DienThoai = "0938485966", DiaChi = "TP Hồ Chí Minh", NgayTao = DateTime.Now, GhiChu = "Không" },
		new KhachHang { MaKhachHang = "KH0006", TenKhachHang = "Nguyễn Văn B", CCCD = "123432156782", GioiTinh = "Nam", NgaySinh = new DateTime(1981, 1, 2), DienThoai = "0938481235", DiaChi = "Hà Nội", NgayTao = DateTime.Now, GhiChu = "Không" },
		new KhachHang { MaKhachHang = "KH0007", TenKhachHang = "Trần Thị C", CCCD = "123432156781", GioiTinh = "Nữ", NgaySinh = new DateTime(1986, 2, 3), DienThoai = "0938484568", DiaChi = "TP Hồ Chí Minh", NgayTao = DateTime.Now, GhiChu = "Không" },
		new KhachHang { MaKhachHang = "KH0008", TenKhachHang = "Lê Văn C", CCCD = "123432157823", GioiTinh = "Nam", NgaySinh = new DateTime(1982, 1, 3), DienThoai = "0938481236", DiaChi = "Hà Nội", NgayTao = DateTime.Now, GhiChu = "Không" },
		new KhachHang { MaKhachHang = "KH0009", TenKhachHang = "Phạm Thị D", CCCD = "123432156733", GioiTinh = "Nữ", NgaySinh = new DateTime(1987, 2, 4), DienThoai = "0938484569", DiaChi = "TP Hồ Chí Minh", NgayTao = DateTime.Now, GhiChu = "Không" },
		new KhachHang { MaKhachHang = "KH0010", TenKhachHang = "Đặng Văn D", CCCD = "123432156734", GioiTinh = "Nam", NgaySinh = new DateTime(1983, 1, 4), DienThoai = "0938481237", DiaChi = "Hà Nội", NgayTao = DateTime.Now, GhiChu = "Không" },
		new KhachHang { MaKhachHang = "KH0011", TenKhachHang = "Vũ Thị E", CCCD = "123432156756", GioiTinh = "Nữ", NgaySinh = new DateTime(1988, 2, 5), DienThoai = "0938484570", DiaChi = "TP Hồ Chí Minh", NgayTao = DateTime.Now, GhiChu = "Không" },
		new KhachHang { MaKhachHang = "KH0012", TenKhachHang = "Bùi Văn E", CCCD = "123432156774", GioiTinh = "Nam", NgaySinh = new DateTime(1984, 1, 5), DienThoai = "0938481238", DiaChi = "Hà Nội", NgayTao = DateTime.Now, GhiChu = "Không" },
		new KhachHang { MaKhachHang = "KH0013", TenKhachHang = "Ngô Thị F", CCCD = "123432156775", GioiTinh = "Nữ", NgaySinh = new DateTime(1989, 2, 6), DienThoai = "0938484571", DiaChi = "TP Hồ Chí Minh", NgayTao = DateTime.Now, GhiChu = "Không" },
		new KhachHang { MaKhachHang = "KH0014", TenKhachHang = "Lý Văn F", CCCD = "123432156756", GioiTinh = "Nam", NgaySinh = new DateTime(1985, 1, 6), DienThoai = "0938481239", DiaChi = "Hà Nội", NgayTao = DateTime.Now, GhiChu = "Không" },
		new KhachHang { MaKhachHang = "KH0015", TenKhachHang = "Dương Thị G", CCCD = "123432156775", GioiTinh = "Nữ", NgaySinh = new DateTime(1990, 2, 7), DienThoai = "0938484572", DiaChi = "TP Hồ Chí Minh", NgayTao = DateTime.Now, GhiChu = "Không" },
		new KhachHang { MaKhachHang = "KH0016", TenKhachHang = "Phan Văn G", CCCD = "123432156756", GioiTinh = "Nam", NgaySinh = new DateTime(1986, 1, 7), DienThoai = "0938481240", DiaChi = "Hà Nội", NgayTao = DateTime.Now, GhiChu = "Không" },
		new KhachHang { MaKhachHang = "KH0017", TenKhachHang = "Trịnh Thị H", CCCD = "123432156734", GioiTinh = "Nữ", NgaySinh = new DateTime(1991, 2, 8), DienThoai = "0938484573", DiaChi = "TP Hồ Chí Minh", NgayTao = DateTime.Now, GhiChu = "Không" },
		new KhachHang { MaKhachHang = "KH0018", TenKhachHang = "Nguyễn Văn H", CCCD = "123432156775", GioiTinh = "Nam", NgaySinh = new DateTime(1987, 1, 8), DienThoai = "0938481241", DiaChi = "Hà Nội", NgayTao = DateTime.Now, GhiChu = "Không" },
		new KhachHang { MaKhachHang = "KH0019", TenKhachHang = "Lê Thị I", CCCD = "123432156734", GioiTinh = "Nữ", NgaySinh = new DateTime(1992, 2, 9), DienThoai = "0938484574", DiaChi = "TP Hồ Chí Minh", NgayTao = DateTime.Now, GhiChu = "Không" },
		new KhachHang { MaKhachHang = "KH0020", TenKhachHang = "Đỗ Văn I", CCCD = "123432156765", GioiTinh = "Nam", NgaySinh = new DateTime(1988, 1, 9), DienThoai = "0938481242", DiaChi = "Hà Nội", NgayTao = DateTime.Now, GhiChu = "Không" }
		);
			modelBuilder.Entity<NhanVien>().HasData(
	new NhanVien { MaNhanVien = "NV0001", TenNhanVien = "Nguyễn Văn A", CCCD = "123456314789", GioiTinh = "Nam", NgaySinh = new DateTime(1980, 1, 1), ChucVu = "Quản lý", DienThoai = "0938481234", Email = "nhutbmt82@gmail.com", DiaChi = "Hà Nội", NgayVaoLam = new DateTime(2020, 1, 1), GhiChu = "Không" },
	new NhanVien { MaNhanVien = "NV0002", TenNhanVien = "Trần Thị B", CCCD = "982347654321", GioiTinh = "Nữ", NgaySinh = new DateTime(1985, 2, 2), ChucVu = "Nhân viên", DienThoai = "0938484567", Email = "ttb@gmail.com", DiaChi = "TP Hồ Chí Minh", NgayVaoLam = new DateTime(2021, 2, 2), GhiChu = "Không" },
new NhanVien { MaNhanVien = "NV0003", TenNhanVien = "Lê Văn C", CCCD = "123456732190", GioiTinh = "Nam", NgaySinh = new DateTime(1982, 1, 3), ChucVu = "Nhân viên", DienThoai = "0938481235", Email = "lvc@gmail.com", DiaChi = "Hà Nội", NgayVaoLam = new DateTime(2020, 1, 3), GhiChu = "Không" },
new NhanVien { MaNhanVien = "NV0004", TenNhanVien = "Phạm Thị D", CCCD = "987652314322", GioiTinh = "Nữ", NgaySinh = new DateTime(1986, 2, 3), ChucVu = "Nhân viên", DienThoai = "0938484568", Email = "ptd@gmail.com", DiaChi = "TP Hồ Chí Minh", NgayVaoLam = new DateTime(2021, 2, 3), GhiChu = "Không" },
new NhanVien { MaNhanVien = "NV0005", TenNhanVien = "Nguyễn Văn E", CCCD = "123324456791", GioiTinh = "Nam", NgaySinh = new DateTime(1983, 1, 4), ChucVu = "Nhân viên", DienThoai = "0938481236", Email = "nve@gmail.com", DiaChi = "Hà Nội", NgayVaoLam = new DateTime(2020, 1, 4), GhiChu = "Không" },
new NhanVien { MaNhanVien = "NV0006", TenNhanVien = "Trần Thị F", CCCD = "987655674323", GioiTinh = "Nữ", NgaySinh = new DateTime(1987, 2, 4), ChucVu = "Quản lý", DienThoai = "0938484569", Email = "ttf@gmail.com", DiaChi = "TP Hồ Chí Minh", NgayVaoLam = new DateTime(2021, 2, 4), GhiChu = "Không" },
new NhanVien { MaNhanVien = "NV0007", TenNhanVien = "Đặng Văn G", CCCD = "123454346792", GioiTinh = "Nam", NgaySinh = new DateTime(1984, 1, 5), ChucVu = "Nhân viên", DienThoai = "0938481237", Email = "dvg@gmail.com", DiaChi = "Hà Nội", NgayVaoLam = DateTime.Now, GhiChu = "Không" },
new NhanVien { MaNhanVien = "NV0008", TenNhanVien = "Vũ Thị H", CCCD = "987654444324", GioiTinh = "Nữ", NgaySinh = new DateTime(1988, 2, 5), ChucVu = "Quản lý", DienThoai = "0938484570", Email = "vth@gmail.com", DiaChi = "TP Hồ Chí Minh", NgayVaoLam = DateTime.Now, GhiChu = "Không" },
new NhanVien { MaNhanVien = "NV0009", TenNhanVien = "Bùi Văn I", CCCD = "123456545793", GioiTinh = "Nam", NgaySinh = new DateTime(1985, 1, 6), ChucVu = "Nhân viên", DienThoai = "0938481238", Email = "bvi@gmail.com", DiaChi = "Hà Nội", NgayVaoLam = DateTime.Now, GhiChu = "Không" },
new NhanVien { MaNhanVien = "NV0010", TenNhanVien = "Ngô Thị J", CCCD = "987654444325", GioiTinh = "Nữ", NgaySinh = new DateTime(1989, 2, 6), ChucVu = "Nhân viên", DienThoai = "0938484571", Email = "ntj@gmail.com", DiaChi = "TP Hồ Chí Minh", NgayVaoLam = DateTime.Now, GhiChu = "Không" }
);
			modelBuilder.Entity<TaiKhoan>().HasData(
	 new TaiKhoan { TenDangNhap = "admin", MatKhau = "admin", Email = "nhutbmt82@gmail.com" ,NgayTao= DateTime.Now},
	 new TaiKhoan { TenDangNhap = "user", MatKhau = "user", Email = "be123@gmail.com", NgayTao = DateTime.Now }
 );
			modelBuilder.Entity<Room>().HasData(
	   new Room { MaPhong = "101", KhuVuc = "A", HangPhong = "Phòng Đơn", GiaTheoGio = 100000, GiaTheoNgay = 600000, TrangThai = "Trống" },
	   new Room { MaPhong = "102", KhuVuc = "A", HangPhong = "Phòng Đôi", GiaTheoGio = 200000, GiaTheoNgay = 1000000, TrangThai = "Trống" },
	   new Room { MaPhong = "103", KhuVuc = "B", HangPhong = "Phòng Đơn", GiaTheoGio = 100000, GiaTheoNgay = 600000, TrangThai = "Trống" },
	   new Room { MaPhong = "104", KhuVuc = "B", HangPhong = "Phòng Đơn", GiaTheoGio = 100000, GiaTheoNgay = 600000, TrangThai = "Trống" },
	   new Room { MaPhong = "201", KhuVuc = "C", HangPhong = "Phòng Đôi", GiaTheoGio = 200000, GiaTheoNgay = 1000000, TrangThai = "Trống" },
		  new Room { MaPhong = "202", KhuVuc = "A", HangPhong = "Phòng Đơn", GiaTheoGio = 100000, GiaTheoNgay = 600000, TrangThai = "Trống" },
	   new Room { MaPhong = "203", KhuVuc = "B", HangPhong = "Phòng Đôi", GiaTheoGio = 200000, GiaTheoNgay = 1000000, TrangThai = "Trống" },
	   new Room { MaPhong = "204", KhuVuc = "B", HangPhong = "Phòng Đơn", GiaTheoGio = 100000, GiaTheoNgay = 600000, TrangThai = "Trống" },
		  new Room { MaPhong = "301", KhuVuc = "C", HangPhong = "Phòng Đôi", GiaTheoGio = 200000, GiaTheoNgay = 1000000, TrangThai = "Trống" },
		  new Room { MaPhong = "302", KhuVuc = "A", HangPhong = "Phòng Đơn", GiaTheoGio = 100000, GiaTheoNgay = 600000, TrangThai = "Trống" },
	   new Room { MaPhong = "303", KhuVuc = "B", HangPhong = "Phòng Đôi", GiaTheoGio = 200000, GiaTheoNgay = 1000000, TrangThai = "Trống" },
	   new Room { MaPhong = "304", KhuVuc = "B", HangPhong = "Phòng Đơn", GiaTheoGio = 100000, GiaTheoNgay = 600000, TrangThai = "Trống" },
		  new Room { MaPhong = "401", KhuVuc = "C", HangPhong = "Phòng Đôi", GiaTheoGio = 200000, GiaTheoNgay = 1000000, TrangThai = "Trống" },
		  new Room { MaPhong = "402", KhuVuc = "A", HangPhong = "Phòng Đơn", GiaTheoGio = 100000, GiaTheoNgay = 600000, TrangThai = "Trống" },
	   new Room { MaPhong = "403", KhuVuc = "B", HangPhong = "Phòng Đôi", GiaTheoGio = 200000, GiaTheoNgay = 1000000, TrangThai = "Trống" },
	   new Room { MaPhong = "404", KhuVuc = "B", HangPhong = "Phòng Đơn", GiaTheoGio = 100000, GiaTheoNgay = 600000, TrangThai = "Trống" }
   );
		}
	}
}

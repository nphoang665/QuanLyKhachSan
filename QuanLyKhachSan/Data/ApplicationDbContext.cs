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
        public DbSet<HoaDon> HoaDon { get;set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KhachHang>().HasData(
                new KhachHang { MaKhachHang = "KH0001", TenKhachHang = "Nguyễn Văn An", CCCD = "123456789", GioiTinh = "Nam", NgaySinh = new DateTime(1980, 1, 1), DienThoai = "0938481234", DiaChi = "Hà Nội", GhiChu = "Không" },
                new KhachHang { MaKhachHang = "KH0002", TenKhachHang = "Trần Thị Bé", CCCD = "987654321", GioiTinh = "Nữ", NgaySinh = new DateTime(1985, 2, 2), DienThoai = "0938484567", DiaChi = "TP Hồ Chí Minh", GhiChu = "Không" },
                new KhachHang { MaKhachHang = "KH0003", TenKhachHang = "Huỳnh An Cao", CCCD = "987654321", GioiTinh = "Nam", NgaySinh = new DateTime(1988, 2, 2), DienThoai = "0938485966", DiaChi = "TP Hồ Chí Minh", GhiChu = "Không" },
                 new KhachHang { MaKhachHang = "KH0004", TenKhachHang = "Nguyễn Thị Bích", CCCD = "987654321", GioiTinh = "Nữ", NgaySinh = new DateTime(1995, 2, 2), DienThoai = "0938234166", DiaChi = "TP Hồ Chí Minh", GhiChu = "Không" },
                new KhachHang { MaKhachHang = "KH0005", TenKhachHang = "Hồ Thị Mỹ", CCCD = "987654321", GioiTinh = "Nữ", NgaySinh = new DateTime(1985, 2, 2), DienThoai = "0938485966", DiaChi = "TP Hồ Chí Minh", GhiChu = "Không" }
            );
            modelBuilder.Entity<NhanVien>().HasData(
       new NhanVien { MaNhanVien = "NV0001", TenNhanVien = "Nguyễn Văn A", CCCD = "123456789", GioiTinh = "Nam", NgaySinh = new DateTime(1980, 1, 1), ChucVu = "Quản lý", DienThoai = "0123456789", DiaChi = "Hà Nội", NgayVaoLam = new DateTime(2020, 1, 1), GhiChu = "Không" },
       new NhanVien { MaNhanVien = "NV0002", TenNhanVien = "Trần Thị B", CCCD = "987654321", GioiTinh = "Nữ", NgaySinh = new DateTime(1985, 2, 2), ChucVu = "Nhân viên", DienThoai = "0987654321", DiaChi = "TP Hồ Chí Minh", NgayVaoLam = new DateTime(2021, 2, 2), GhiChu = "Không" },
       new NhanVien { MaNhanVien = "NV0003", TenNhanVien = "Phạm Văn C", CCCD = "234567890", GioiTinh = "Nam", NgaySinh = new DateTime(1990, 3, 3), ChucVu = "Quản lý", DienThoai = "0234567890", DiaChi = "Đà Nẵng", NgayVaoLam = new DateTime(2022, 3, 3), GhiChu = "Không" },
       new NhanVien { MaNhanVien = "NV0004", TenNhanVien = "Lê Thị D", CCCD = "345678901", GioiTinh = "Nữ", NgaySinh = new DateTime(1995, 4, 4), ChucVu = "Nhân viên", DienThoai = "0345678901", DiaChi = "Cần Thơ", NgayVaoLam = new DateTime(2023, 4, 4), GhiChu = "Không" },
       new NhanVien { MaNhanVien = "NV0005", TenNhanVien = "Hoàng Văn E", CCCD = "456789012", GioiTinh = "Nam", NgaySinh = new DateTime(2000, 5, 5), ChucVu = "Quản lý", DienThoai = "0456789012", DiaChi = "Hải Phòng", NgayVaoLam = new DateTime(2024, 5, 5), GhiChu = "Không" }
   );
            modelBuilder.Entity<TaiKhoan>().HasData(
     new TaiKhoan { TenDangNhap = "admin", MatKhau = "admin", Email = "admin@gmail.com" },
     new TaiKhoan { TenDangNhap = "user", MatKhau = "user", Email = "user@gmail.com" }
 );
            modelBuilder.Entity<Room>().HasData(
       new Room { MaPhong = "101", KhuVuc = "A", HangPhong = "VIP", GiaTheoGio = 200000, GiaTheoQuaDem = 500000, GiaTheoNgay = 1000000, TrangThai = "Trống" },
       new Room { MaPhong = "102", KhuVuc = "A", HangPhong = "Thường", GiaTheoGio = 100000, GiaTheoQuaDem = 300000, GiaTheoNgay = 600000, TrangThai = "Trống" },
       new Room { MaPhong = "103", KhuVuc = "B", HangPhong = "VIP", GiaTheoGio = 200000, GiaTheoQuaDem = 500000, GiaTheoNgay = 1000000, TrangThai = "Đang sử dụng" },
       new Room { MaPhong = "104", KhuVuc = "B", HangPhong = "Thường", GiaTheoGio = 100000, GiaTheoQuaDem = 300000, GiaTheoNgay = 600000, TrangThai = "Đang sử dụng" },
       new Room { MaPhong = "201", KhuVuc = "C", HangPhong = "VIP", GiaTheoGio = 200000, GiaTheoQuaDem = 500000, GiaTheoNgay = 1000000, TrangThai = "Trống" },
          new Room { MaPhong = "202", KhuVuc = "A", HangPhong = "Thường", GiaTheoGio = 100000, GiaTheoQuaDem = 300000, GiaTheoNgay = 600000, TrangThai = "Trống" },
       new Room { MaPhong = "203", KhuVuc = "B", HangPhong = "VIP", GiaTheoGio = 200000, GiaTheoQuaDem = 500000, GiaTheoNgay = 1000000, TrangThai = "Đang sử dụng" },
       new Room { MaPhong = "204", KhuVuc = "B", HangPhong = "Thường", GiaTheoGio = 100000, GiaTheoQuaDem = 300000, GiaTheoNgay = 600000, TrangThai = "Đang sử dụng" },
          new Room { MaPhong = "301", KhuVuc = "C", HangPhong = "VIP", GiaTheoGio = 200000, GiaTheoQuaDem = 500000, GiaTheoNgay = 1000000, TrangThai = "Trống" },
          new Room { MaPhong = "302", KhuVuc = "A", HangPhong = "Thường", GiaTheoGio = 100000, GiaTheoQuaDem = 300000, GiaTheoNgay = 600000, TrangThai = "Trống" },
       new Room { MaPhong = "303", KhuVuc = "B", HangPhong = "VIP", GiaTheoGio = 200000, GiaTheoQuaDem = 500000, GiaTheoNgay = 1000000, TrangThai = "Đang sử dụng" },
       new Room { MaPhong = "304", KhuVuc = "B", HangPhong = "Thường", GiaTheoGio = 100000, GiaTheoQuaDem = 300000, GiaTheoNgay = 600000, TrangThai = "Đang sử dụng" },
          new Room { MaPhong = "401", KhuVuc = "C", HangPhong = "VIP", GiaTheoGio = 200000, GiaTheoQuaDem = 500000, GiaTheoNgay = 1000000, TrangThai = "Trống" },
          new Room { MaPhong = "402", KhuVuc = "A", HangPhong = "Thường", GiaTheoGio = 100000, GiaTheoQuaDem = 300000, GiaTheoNgay = 600000, TrangThai = "Trống" },
       new Room { MaPhong = "403", KhuVuc = "B", HangPhong = "VIP", GiaTheoGio = 200000, GiaTheoQuaDem = 500000, GiaTheoNgay = 1000000, TrangThai = "Đang sử dụng" },
       new Room { MaPhong = "404", KhuVuc = "B", HangPhong = "Thường", GiaTheoGio = 100000, GiaTheoQuaDem = 300000, GiaTheoNgay = 600000, TrangThai = "Đang sử dụng" }
   );
        }
    }
}

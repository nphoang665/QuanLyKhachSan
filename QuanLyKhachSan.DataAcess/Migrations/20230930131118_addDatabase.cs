using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKhachSan.DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class addDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.CreateTable(
                name: "DatPhongs",
                columns: table => new
                {
                    MaDatPhong = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Phong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HangPhong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HinhThuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaPhong = table.Column<double>(type: "float", nullable: false),
                    NgayNhan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayTra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuKien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThanhTien = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatPhongs", x => x.MaDatPhong);
                });
		
		migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    MaKhachHang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.MaKhachHang);
                });
			migrationBuilder.Sql("INSERT INTO KhachHangs (MaKhachHang, TenKhachHang, GioiTinh, NgaySinh, DienThoai, DiaChi, GhiChu) VALUES ('KH001', 'Nguyen Van A', 'Nam', '1980-01-01', '0123456789', 'Dia chi 1', 'Ghi chu 1')");
			migrationBuilder.Sql("INSERT INTO KhachHangs (MaKhachHang, TenKhachHang, GioiTinh, NgaySinh, DienThoai, DiaChi, GhiChu) VALUES ('KH002', 'Nguyen Van B', 'Nam', '1981-01-01', '0123456780', 'Dia chi 2', 'Ghi chu 2')");
			migrationBuilder.Sql("INSERT INTO KhachHangs (MaKhachHang, TenKhachHang, GioiTinh, NgaySinh, DienThoai, DiaChi, GhiChu) VALUES ('KH003', 'Nguyen Van C', 'Nam', '1982-01-01', '0123456798', 'Dia chi 3', 'Ghi chu 3')");
			migrationBuilder.Sql("INSERT INTO KhachHangs (MaKhachHang, TenKhachHang, GioiTinh, NgaySinh, DienThoai, DiaChi, GhiChu) VALUES ('KH004', 'Nguyen Van D', 'Nam', '1983-01-01', '0123456987', 'Dia chi 4', 'Ghi chu 4')");
			migrationBuilder.Sql("INSERT INTO KhachHangs (MaKhachHang, TenKhachHang, GioiTinh, NgaySinh, DienThoai, DiaChi, GhiChu) VALUES ('KH005', 'Nguyen Van E', 'Nam', '1984-01-01', '0123456879', 'Dia chi 5', 'Ghi chu 5')");

			migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    MaNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenNhanVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.MaNhanVien);
                });
			migrationBuilder.Sql("INSERT INTO NhanViens (MaNhanVien, TenNhanVien, GioiTinh, NgaySinh, DienThoai, DiaChi, GhiChu) VALUES ('NV001', 'Nguyen Van A', 'Nam', '1980-01-01', '0123456789', 'Dia chi 1', 'Ghi chu 1')");
			migrationBuilder.Sql("INSERT INTO NhanViens (MaNhanVien, TenNhanVien, GioiTinh, NgaySinh, DienThoai, DiaChi, GhiChu) VALUES ('NV002', 'Nguyen Van B', 'Nam', '1981-01-01', '0123456780', 'Dia chi 2', 'Ghi chu 2')");
			migrationBuilder.Sql("INSERT INTO NhanViens (MaNhanVien, TenNhanVien, GioiTinh, NgaySinh, DienThoai, DiaChi, GhiChu) VALUES ('NV003', 'Nguyen Van C', 'Nam', '1982-01-01', '0123456798', 'Dia chi 3', 'Ghi chu 3')");
			migrationBuilder.Sql("INSERT INTO NhanViens (MaNhanVien, TenNhanVien, GioiTinh, NgaySinh, DienThoai, DiaChi, GhiChu) VALUES ('NV004', 'Nguyen Van D', 'Nam', '1983-01-01', '0123456987', 'Dia chi 4', 'Ghi chu 4')");
			migrationBuilder.Sql("INSERT INTO NhanViens (MaNhanVien, TenNhanVien, GioiTinh, NgaySinh, DienThoai, DiaChi, GhiChu) VALUES ('NV005', 'Nguyen Van E', 'Nam', '1984-01-01', '0123456879', 'Dia chi 5', 'Ghi chu 5')");
			migrationBuilder.CreateTable(
                name: "Phong",
                columns: table => new
                {
                    MaPhong = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KhuVuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HangPhong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaTheoGio = table.Column<double>(type: "float", nullable: false),
                    GiaTheoQuaDem = table.Column<double>(type: "float", nullable: false),
                    GiaTheoNgay = table.Column<double>(type: "float", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phong", x => x.MaPhong);
                });
			migrationBuilder.Sql("INSERT INTO Phong (MaPhong, KhuVuc, HangPhong, GiaTheoGio, GiaTheoQuaDem, GiaTheoNgay, GhiChu) VALUES ('101', 'Khu vực 1', 'Hạng 1', 100000, 200000, 300000, 'Ghi chú 1')");
			migrationBuilder.Sql("INSERT INTO Phong (MaPhong, KhuVuc, HangPhong, GiaTheoGio, GiaTheoQuaDem, GiaTheoNgay, GhiChu) VALUES ('102', 'Khu vực 1', 'Hạng 1', 100000, 200000, 300000, 'Ghi chú 1')");
			migrationBuilder.Sql("INSERT INTO Phong (MaPhong, KhuVuc, HangPhong, GiaTheoGio, GiaTheoQuaDem, GiaTheoNgay, GhiChu) VALUES ('103', 'Khu vực 1', 'Hạng 1', 100000, 200000, 300000, 'Ghi chú 1')");
			migrationBuilder.Sql("INSERT INTO Phong (MaPhong, KhuVuc, HangPhong, GiaTheoGio, GiaTheoQuaDem, GiaTheoNgay, GhiChu) VALUES ('104', 'Khu vực 1', 'Hạng 1', 100000, 200000, 300000, 'Ghi chú 1')");
			migrationBuilder.Sql("INSERT INTO Phong (MaPhong, KhuVuc, HangPhong, GiaTheoGio, GiaTheoQuaDem, GiaTheoNgay, GhiChu) VALUES ('201', 'Khu vực 1', 'Hạng 1', 100000, 200000, 300000, 'Ghi chú 1')");
			migrationBuilder.Sql("INSERT INTO Phong (MaPhong, KhuVuc, HangPhong, GiaTheoGio, GiaTheoQuaDem, GiaTheoNgay, GhiChu) VALUES ('202', 'Khu vực 1', 'Hạng 1', 100000, 200000, 300000, 'Ghi chú 1')");
			migrationBuilder.Sql("INSERT INTO Phong (MaPhong, KhuVuc, HangPhong, GiaTheoGio, GiaTheoQuaDem, GiaTheoNgay, GhiChu) VALUES ('203', 'Khu vực 1', 'Hạng 1', 100000, 200000, 300000, 'Ghi chú 1')");
			migrationBuilder.Sql("INSERT INTO Phong (MaPhong, KhuVuc, HangPhong, GiaTheoGio, GiaTheoQuaDem, GiaTheoNgay, GhiChu) VALUES ('204', 'Khu vực 1', 'Hạng 1', 100000, 200000, 300000, 'Ghi chú 1')");
			migrationBuilder.Sql("INSERT INTO Phong (MaPhong, KhuVuc, HangPhong, GiaTheoGio, GiaTheoQuaDem, GiaTheoNgay, GhiChu) VALUES ('301', 'Khu vực 1', 'Hạng 1', 100000, 200000, 300000, 'Ghi chú 1')");
			migrationBuilder.Sql("INSERT INTO Phong (MaPhong, KhuVuc, HangPhong, GiaTheoGio, GiaTheoQuaDem, GiaTheoNgay, GhiChu) VALUES ('302', 'Khu vực 1', 'Hạng 1', 100000, 200000, 300000, 'Ghi chú 1')");
			migrationBuilder.Sql("INSERT INTO Phong (MaPhong, KhuVuc, HangPhong, GiaTheoGio, GiaTheoQuaDem, GiaTheoNgay, GhiChu) VALUES ('303', 'Khu vực 1', 'Hạng 1', 100000, 200000, 300000, 'Ghi chú 1')");
			migrationBuilder.Sql("INSERT INTO Phong (MaPhong, KhuVuc, HangPhong, GiaTheoGio, GiaTheoQuaDem, GiaTheoNgay, GhiChu) VALUES ('304', 'Khu vực 1', 'Hạng 1', 100000, 200000, 300000, 'Ghi chú 1')");
			migrationBuilder.Sql("INSERT INTO Phong (MaPhong, KhuVuc, HangPhong, GiaTheoGio, GiaTheoQuaDem, GiaTheoNgay, GhiChu) VALUES ('401', 'Khu vực 1', 'Hạng 1', 100000, 200000, 300000, 'Ghi chú 1')");
			migrationBuilder.Sql("INSERT INTO Phong (MaPhong, KhuVuc, HangPhong, GiaTheoGio, GiaTheoQuaDem, GiaTheoNgay, GhiChu) VALUES ('402', 'Khu vực 1', 'Hạng 1', 100000, 200000, 300000, 'Ghi chú 1')");
			migrationBuilder.Sql("INSERT INTO Phong (MaPhong, KhuVuc, HangPhong, GiaTheoGio, GiaTheoQuaDem, GiaTheoNgay, GhiChu) VALUES ('403', 'Khu vực 1', 'Hạng 1', 100000, 200000, 300000, 'Ghi chú 1')");
			migrationBuilder.Sql("INSERT INTO Phong (MaPhong, KhuVuc, HangPhong, GiaTheoGio, GiaTheoQuaDem, GiaTheoNgay, GhiChu) VALUES ('404', 'Khu vực 1', 'Hạng 1', 100000, 200000, 300000, 'Ghi chú 1')");


			migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    TenDangNhap = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.TenDangNhap);
                });
			migrationBuilder.Sql("INSERT INTO TaiKhoan (TenDangNhap, MatKhau) VALUES ('admin', 'admin')");
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatPhongs");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "Phong");

            migrationBuilder.DropTable(
                name: "TaiKhoan");
        }
    }
}

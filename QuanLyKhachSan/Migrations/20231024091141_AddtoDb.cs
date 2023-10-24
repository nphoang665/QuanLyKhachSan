using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuanLyKhachSan.Migrations
{
    /// <inheritdoc />
    public partial class AddtoDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    MaHoaDon = table.Column<string>(type: "char(6)", nullable: false),
					HinhThuc = table.Column<string>(type: "nvarchar(30)", nullable: false),
					GiaPhong = table.Column<int>(type: "int", nullable: false),
					NgayNhan = table.Column<DateTime>(type: "datetime2", nullable: false),
					NgayTra = table.Column<DateTime>(type: "datetime2", nullable: false),
					DuKien = table.Column<string>(type: "nvarchar(40)", nullable: false),
					ThanhTien = table.Column<float>(type: "real", nullable: false)
				},
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.MaHoaDon);
                });

            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
					MaKhachHang = table.Column<string>(type: "char(6)", nullable: false),
					TenKhachHang = table.Column<string>(type: "nvarchar(55)", nullable: false),
					CCCD = table.Column<string>(type: "char(12)", nullable: false),
					GioiTinh = table.Column<string>(type: "nvarchar(4)", nullable: false),
					NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
					DienThoai = table.Column<string>(type: "varchar(11)", nullable: false),
					DiaChi = table.Column<string>(type: "nvarchar(90)", nullable: false),
					GhiChu = table.Column<string>(type: "nvarchar(100)", nullable: false)
				},
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.MaKhachHang);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
					MaNhanVien = table.Column<string>(type: "char(6)", nullable: false),
					TenNhanVien = table.Column<string>(type: "nvarchar(55)", nullable: false),
					CCCD = table.Column<string>(type: "char(12)", nullable: false),
					GioiTinh = table.Column<string>(type: "nvarchar(4)", nullable: false),
					NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
					ChucVu = table.Column<string>(type: "nvarchar(30)", nullable: false),
					DienThoai = table.Column<string>(type: "varchar(12)", nullable: false),
					DiaChi = table.Column<string>(type: "nvarchar(90)", nullable: false),
					NgayVaoLam = table.Column<DateTime>(type: "datetime2", nullable: false),
					GhiChu = table.Column<string>(type: "nvarchar(100)", nullable: false)
				},
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.MaNhanVien);
                });

            migrationBuilder.CreateTable(
                name: "Phong",
                columns: table => new
                {
					MaPhong = table.Column<string>(type: "char(3)", nullable: false),
					KhuVuc = table.Column<string>(type: "nvarchar(40)", nullable: false),
					HangPhong = table.Column<string>(type: "nvarchar(20)", nullable: false),
					GiaTheoGio = table.Column<int>(type: "int", nullable: false),
					GiaTheoQuaDem = table.Column<int>(type: "int", nullable: false),
					GiaTheoNgay = table.Column<int>(type: "int", nullable: false),
					TrangThai = table.Column<string>(type: "nvarchar(30)", nullable: false)
				},
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phong", x => x.MaPhong);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
					TenDangNhap = table.Column<string>(type: "varchar(25)", nullable: false),
					MatKhau = table.Column<string>(type: "varchar(25)", nullable: false),
					Email = table.Column<string>(type: "varchar(42)", nullable: false)
				},
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.TenDangNhap);
                });

            migrationBuilder.CreateTable(
                name: "DatPhongs",
                columns: table => new
                {
					MaDatPhong = table.Column<string>(type: "char(6)", nullable: false),
					MaNhanVien = table.Column<string>(type: "char(6)", nullable: false),
					MaPhong = table.Column<string>(type: "char(3)", nullable: false),
					MaKhachHang = table.Column<string>(type: "char(6)", nullable: false),
					HinhThuc = table.Column<string>(type: "nvarchar(30)", nullable: false),
					GiaPhong = table.Column<int>(type: "int", nullable: false),
					NgayNhan = table.Column<DateTime>(type: "datetime2", nullable: false),
					NgayTra = table.Column<DateTime>(type: "datetime2", nullable: false),
					DuKien = table.Column<string>(type: "nvarchar(40)", nullable: false),
					ThanhTien = table.Column<float>(type: "real", nullable: false)
				},
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatPhongs", x => x.MaDatPhong);
                    table.ForeignKey(
                        name: "FK_DatPhongs_KhachHangs_MaKhachHang",
                        column: x => x.MaKhachHang,
                        principalTable: "KhachHangs",
                        principalColumn: "MaKhachHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatPhongs_NhanViens_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanViens",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatPhongs_Phong_MaPhong",
                        column: x => x.MaPhong,
                        principalTable: "Phong",
                        principalColumn: "MaPhong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "KhachHangs",
                columns: new[] { "MaKhachHang", "CCCD", "DiaChi", "DienThoai", "GhiChu", "GioiTinh", "NgaySinh", "TenKhachHang" },
                values: new object[,]
                {
                    { "KH0001", "123456789", "Hà Nội", "0938481234", "Không", "Nam", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Văn An" },
                    { "KH0002", "987654321", "TP Hồ Chí Minh", "0938484567", "Không", "Nữ", new DateTime(1985, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trần Thị Bé" },
                    { "KH0003", "987654321", "TP Hồ Chí Minh", "0938485966", "Không", "Nam", new DateTime(1988, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Huỳnh An Cao" },
                    { "KH0004", "987654321", "TP Hồ Chí Minh", "0938234166", "Không", "Nữ", new DateTime(1995, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Thị Bích" },
                    { "KH0005", "987654321", "TP Hồ Chí Minh", "0938485966", "Không", "Nữ", new DateTime(1985, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hồ Thị Mỹ" }
                });

            migrationBuilder.InsertData(
                table: "NhanViens",
                columns: new[] { "MaNhanVien", "CCCD", "ChucVu", "DiaChi", "DienThoai", "GhiChu", "GioiTinh", "NgaySinh", "NgayVaoLam", "TenNhanVien" },
                values: new object[,]
                {
                    { "NV0001", "123456789", "Quản lý", "Hà Nội", "0123456789", "Không", "Nam", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Văn A" },
                    { "NV0002", "987654321", "Nhân viên", "TP Hồ Chí Minh", "0987654321", "Không", "Nữ", new DateTime(1985, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trần Thị B" },
                    { "NV0003", "234567890", "Quản lý", "Đà Nẵng", "0234567890", "Không", "Nam", new DateTime(1990, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phạm Văn C" },
                    { "NV0004", "345678901", "Nhân viên", "Cần Thơ", "0345678901", "Không", "Nữ", new DateTime(1995, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Thị D" },
                    { "NV0005", "456789012", "Quản lý", "Hải Phòng", "0456789012", "Không", "Nam", new DateTime(2000, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hoàng Văn E" }
                });

            migrationBuilder.InsertData(
                table: "Phong",
                columns: new[] { "MaPhong", "GiaTheoGio", "GiaTheoNgay", "GiaTheoQuaDem", "HangPhong", "KhuVuc", "TrangThai" },
                values: new object[,]
                {
                    { "101", 200000, 1000000, 500000, "VIP", "A", "Trống" },
                    { "102", 100000, 600000, 300000, "Thường", "A", "Trống" },
                    { "103", 200000, 1000000, 500000, "VIP", "B", "Đang sử dụng" },
                    { "104", 100000, 600000, 300000, "Thường", "B", "Đang sử dụng" },
                    { "201", 200000, 1000000, 500000, "VIP", "C", "Trống" },
                    { "202", 100000, 600000, 300000, "Thường", "A", "Trống" },
                    { "203", 200000, 1000000, 500000, "VIP", "B", "Đang sử dụng" },
                    { "204", 100000, 600000, 300000, "Thường", "B", "Đang sử dụng" },
                    { "301", 200000, 1000000, 500000, "VIP", "C", "Trống" },
                    { "302", 100000, 600000, 300000, "Thường", "A", "Trống" },
                    { "303", 200000, 1000000, 500000, "VIP", "B", "Đang sử dụng" },
                    { "304", 100000, 600000, 300000, "Thường", "B", "Đang sử dụng" },
                    { "401", 200000, 1000000, 500000, "VIP", "C", "Trống" },
                    { "402", 100000, 600000, 300000, "Thường", "A", "Trống" },
                    { "403", 200000, 1000000, 500000, "VIP", "B", "Đang sử dụng" },
                    { "404", 100000, 600000, 300000, "Thường", "B", "Đang sử dụng" }
                });

            migrationBuilder.InsertData(
                table: "TaiKhoan",
                columns: new[] { "TenDangNhap", "Email", "MatKhau" },
                values: new object[,]
                {
                    { "admin", "admin@gmail.com", "admin" },
                    { "user", "user@gmail.com", "user" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DatPhongs_MaKhachHang",
                table: "DatPhongs",
                column: "MaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_DatPhongs_MaNhanVien",
                table: "DatPhongs",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_DatPhongs_MaPhong",
                table: "DatPhongs",
                column: "MaPhong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatPhongs");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "Phong");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuanLyKhachSan.Migrations
{
    /// <inheritdoc />
    public partial class AddEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    MaHoaDon = table.Column<string>(type: "char(6)", nullable: false),
                    MaDatPhong = table.Column<string>(type: "char(6)", nullable: false),
                    MaNhanVien = table.Column<string>(type: "char(6)", nullable: false),
                    MaPhong = table.Column<string>(type: "char(3)", nullable: false),
                    MaKhachHang = table.Column<string>(type: "char(6)", nullable: false),
                    HinhThuc = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    GiaPhong = table.Column<int>(type: "int", nullable: false),
                    NgayNhan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayTra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuKien = table.Column<string>(type: "nvarchar(20)", nullable: false),
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
                    TenKhachHang = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CCCD = table.Column<string>(type: "char(12)", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(4)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DienThoai = table.Column<string>(type: "varchar(11)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(70)", nullable: true)
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
                    TenNhanVien = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CCCD = table.Column<string>(type: "char(12)", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(4)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChucVu = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    DienThoai = table.Column<string>(type: "varchar(12)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    NgayVaoLam = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(70)", nullable: true)
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
                    KhuVuc = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    HangPhong = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    GiaTheoGio = table.Column<int>(type: "int", nullable: false),
                    GiaTheoQuaDem = table.Column<int>(type: "int", nullable: false),
                    GiaTheoNgay = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", nullable: false)
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
                    Email = table.Column<string>(type: "varchar(50)", nullable: false)
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
                    DuKien = table.Column<string>(type: "nvarchar(20)", nullable: false),
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
                    { "KH0001", "123456789111", "Hà Nội", "0938481234", "Không", "Nam", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Văn An" },
    { "KH0002", "987654321111", "TP Hồ Chí Minh", "0938484567", "Không", "Nữ", new DateTime(1985, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trần Thị Bé" },
    { "KH0003", "987654321222", "TP Hồ Chí Minh", "0938485966", "Không", "Nam", new DateTime(1988, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Huỳnh An Cao" },
    { "KH0004", "987654321333", "TP Hồ Chí Minh", "0938234166", "Không", "Nữ", new DateTime(1995, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Thị Bích" },
    { "KH0005", "987654321444", "TP Hồ Chí Minh", "0938485966", "Không", "Nữ", new DateTime(1985, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hồ Thị Mỹ" },
    { "KH0006", "987654321555", "Hà Nội", "0938485966", "Không", "Nam", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Văn Bình" },
    { "KH0007", "987654321666", "Hà Nội", "0938485966", "Không", "Nữ", new DateTime(1992, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trần Thị Mai" },
    { "KH0008", "987654321777", "Đà Nẵng", "0938485966", "Không", "Nam", new DateTime(1987, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Văn Nam" },
    { "KH0009", "987654321888", "Đà Nẵng", "0938485966", "Không", "Nữ", new DateTime(1994, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phạm Thị Hà" },
    { "KH0010", "987654321999", "Cần Thơ", "0938485966", "Không", "Nam", new DateTime(1982, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Văn Tân" },
    { "KH0011", "987654322000", "Cần Thơ", "0938485966", "Không", "Nữ", new DateTime(1996, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trần Thị Tú" },
    { "KH0012", "987654322111", "Bình Định", "0938485966", "Không", "Nam", new DateTime(1990, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hồ Văn Cường" },
    { "KH0013", "987654322222", "Bình Định", "0938485966", "Không", "Nữ", new DateTime(1988, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Thị Lan" },
    { "KH0014", "987654322333", "Nghệ An", "0938485966", "Không", "Nam", new DateTime(1989, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Văn Đông" },
    { "KH0015", "987654322444", "Nghệ An", "0938485966", "Không", "Nữ", new DateTime(1997, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phạm Thị Hương" },
    { "KH0016", "987654322555", "Hà Tĩnh", "0938485966", "Không", "Nam", new DateTime(1981, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Văn Đạt" },
    { "KH0017", "987654322666", "Hà Tĩnh", "0938485966", "Không", "Nữ", new DateTime(1984, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trần Thị Thảo" },
    { "KH0018", "987654322777", "Quảng Bình", "0938485966", "Không", "Nam", new DateTime(1993, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hoàng Văn Hòa" },
    { "KH0019", "987654322888", "Quảng Bình", "0938485966", "Không", "Nữ", new DateTime(1983, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Thị Ngọc" },
    { "KH0020", "987654322999", "Huế", "0938485966", "Không", "Nam", new DateTime(1980, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Văn Khánh" },
    { "KH0021", "987654323000", "Huế", "0938485966", "Không", "Nữ", new DateTime(1988, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trần Thị Hằng" },
    { "KH0022", "987654323111", "Quảng Nam", "0938485966", "Không", "Nam", new DateTime(1991, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hoàng Văn Thọ" },
    { "KH0023", "987654323222", "Quảng Nam", "0938485966", "Không", "Nữ", new DateTime(1996, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Thị Tâm" },
    { "KH0024", "987654323333", "Quảng Ngãi", "0938485966", "Không", "Nam", new DateTime(1984, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Văn Long" },
    { "KH0025", "987654323444", "Quảng Ngãi", "0938485966", "Không", "Nữ", new DateTime(1986, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trần Thị Dung" }
                });

            migrationBuilder.InsertData(
                table: "NhanViens",
                columns: new[] { "MaNhanVien", "CCCD", "ChucVu", "DiaChi", "DienThoai", "Email", "GhiChu", "GioiTinh", "NgaySinh", "NgayVaoLam", "TenNhanVien" },
                values: new object[,]
                {
                    { "NV0001", "123453336789", "Quản lý", "Hà Nội", "0123456789", "an123@gmail.com", "Không", "Nam", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Văn A" },
                    { "NV0002", "987653334321", "Nhân viên", "TP Hồ Chí Minh", "0987654321", "be123@gmail.com", "Không", "Nữ", new DateTime(1985, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trần Thị B" },
                    { "NV0003", "234567822290", "Quản lý", "Đà Nẵng", "0234567890", "quoc123a@gmail.com", "Không", "Nam", new DateTime(1990, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phạm Văn C" },
                    { "NV0004", "345678901444", "Nhân viên", "Cần Thơ", "0345678901", "tung123@gmail.com", "Không", "Nữ", new DateTime(1995, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Thị D" },
                    { "NV0005", "456789016662", "Quản lý", "Hải Phòng", "0456789012", "e2s3441@gmail.com", "Không", "Nam", new DateTime(2000, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hoàng Văn E" }
                });

            migrationBuilder.InsertData(
                table: "Phong",
                columns: new[] { "MaPhong", "GiaTheoGio", "GiaTheoNgay", "GiaTheoQuaDem", "HangPhong", "KhuVuc", "TrangThai" },
                values: new object[,]
                {
                    { "101", 200000, 1000000, 500000, "VIP", "A", "Trống" },
                    { "102", 100000, 600000, 300000, "Thường", "A", "Trống" },
                    { "103", 200000, 1000000, 500000, "VIP", "B", "Trống" },
                    { "104", 100000, 600000, 300000, "Thường", "B", "Trống" },
                    { "201", 200000, 1000000, 500000, "VIP", "C", "Trống" },
                    { "202", 100000, 600000, 300000, "Thường", "A", "Trống" },
                    { "203", 200000, 1000000, 500000, "VIP", "B", "Trống" },
                    { "204", 100000, 600000, 300000, "Thường", "B", "Trống" },
                    { "301", 200000, 1000000, 500000, "VIP", "C", "Trống" },
                    { "302", 100000, 600000, 300000, "Thường", "A", "Trống" },
                    { "303", 200000, 1000000, 500000, "VIP", "B", "Trống" },
                    { "304", 100000, 600000, 300000, "Thường", "B", "Trống" },
                    { "401", 200000, 1000000, 500000, "VIP", "C", "Trống" },
                    { "402", 100000, 600000, 300000, "Thường", "A", "Trống" },
                    { "403", 200000, 1000000, 500000, "VIP", "B", "Trống" },
                    { "404", 100000, 600000, 300000, "Thường", "B", "Trống" }
                });

            migrationBuilder.InsertData(
                table: "TaiKhoan",
                columns: new[] { "TenDangNhap", "Email", "MatKhau" },
                values: new object[,]
                {
                    { "admin", "an123@gmail.com", "admin" },
                    { "user", "be123@gmail.com", "user" }
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

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuanLyKhachSan.Migrations
{
    /// <inheritdoc />
    public partial class AddToDb : Migration
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
                    DuKien = table.Column<string>(type: "nvarchar(30)", nullable: false),
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
                    GioiTinh = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DienThoai = table.Column<string>(type: "varchar(10)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(30)", nullable: true)
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
                    GioiTinh = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChucVu = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    DienThoai = table.Column<string>(type: "varchar(10)", nullable: false),
                    Email = table.Column<string>(type: "varchar(55)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    NgayVaoLam = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(40)", nullable: true)
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
                    KhuVuc = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    HangPhong = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    GiaTheoGio = table.Column<int>(type: "int", nullable: false),
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
                    TenDangNhap = table.Column<string>(type: "varchar(35)", nullable: false),
                    MatKhau = table.Column<string>(type: "varchar(35)", nullable: false),
                    Email = table.Column<string>(type: "varchar(55)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    SoNguoiO = table.Column<byte>(type: "tinyint", nullable: false),
                    MaKhachHang = table.Column<string>(type: "char(6)", nullable: false),
                    HinhThuc = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    GiaPhong = table.Column<int>(type: "int", nullable: false),
                    NgayNhan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayTra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuKien = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ThanhTien = table.Column<float>(type: "real", nullable: false),
                    KhachDaThanhToan = table.Column<float>(type: "real", nullable: false)
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
                columns: new[] { "MaKhachHang", "CCCD", "DiaChi", "DienThoai", "GhiChu", "GioiTinh", "NgaySinh", "NgayTao", "TenKhachHang" },
                values: new object[,]
                {
                    { "KH0001", "123432156789", "Hà Nội", "0938481234", "Không", "Nam", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 29, 21, 31, 53, 353, DateTimeKind.Local).AddTicks(8268), "Nguyễn Văn An" },
                    { "KH0002", "987654232321", "TP Hồ Chí Minh", "0938484567", "Không", "Nữ", new DateTime(1985, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 29, 21, 31, 53, 353, DateTimeKind.Local).AddTicks(8278), "Trần Thị Bé" },
                    { "KH0003", "123432156734", "TP Hồ Chí Minh", "0938485966", "Không", "Nam", new DateTime(1988, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 29, 21, 31, 53, 353, DateTimeKind.Local).AddTicks(8280), "Huỳnh An Cao" },
                    { "KH0004", "123432156754", "TP Hồ Chí Minh", "0938234166", "Không", "Nữ", new DateTime(1995, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 29, 21, 31, 53, 353, DateTimeKind.Local).AddTicks(8282), "Nguyễn Thị Bích" },
                    { "KH0005", "123432156785", "TP Hồ Chí Minh", "0938485966", "Không", "Nữ", new DateTime(1985, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 29, 21, 31, 53, 353, DateTimeKind.Local).AddTicks(8283), "Hồ Thị Mỹ" },
                    { "KH0006", "123432156782", "Hà Nội", "0938481235", "Không", "Nam", new DateTime(1981, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 29, 21, 31, 53, 353, DateTimeKind.Local).AddTicks(8284), "Nguyễn Văn B" },
                    { "KH0007", "123432156781", "TP Hồ Chí Minh", "0938484568", "Không", "Nữ", new DateTime(1986, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 29, 21, 31, 53, 353, DateTimeKind.Local).AddTicks(8286), "Trần Thị C" },
                    { "KH0008", "123432157823", "Hà Nội", "0938481236", "Không", "Nam", new DateTime(1982, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 29, 21, 31, 53, 353, DateTimeKind.Local).AddTicks(8287), "Lê Văn C" },
                    { "KH0009", "123432156733", "TP Hồ Chí Minh", "0938484569", "Không", "Nữ", new DateTime(1987, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 29, 21, 31, 53, 353, DateTimeKind.Local).AddTicks(8288), "Phạm Thị D" },
                    { "KH0010", "123432156734", "Hà Nội", "0938481237", "Không", "Nam", new DateTime(1983, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 29, 21, 31, 53, 353, DateTimeKind.Local).AddTicks(8290), "Đặng Văn D" },
                    { "KH0011", "123432156756", "TP Hồ Chí Minh", "0938484570", "Không", "Nữ", new DateTime(1988, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 29, 21, 31, 53, 353, DateTimeKind.Local).AddTicks(8291), "Vũ Thị E" },
                    { "KH0012", "123432156774", "Hà Nội", "0938481238", "Không", "Nam", new DateTime(1984, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 29, 21, 31, 53, 353, DateTimeKind.Local).AddTicks(8292), "Bùi Văn E" },
                    { "KH0013", "123432156775", "TP Hồ Chí Minh", "0938484571", "Không", "Nữ", new DateTime(1989, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 29, 21, 31, 53, 353, DateTimeKind.Local).AddTicks(8294), "Ngô Thị F" },
                    { "KH0014", "123432156756", "Hà Nội", "0938481239", "Không", "Nam", new DateTime(1985, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 29, 21, 31, 53, 353, DateTimeKind.Local).AddTicks(8295), "Lý Văn F" },
                    { "KH0015", "123432156775", "TP Hồ Chí Minh", "0938484572", "Không", "Nữ", new DateTime(1990, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 29, 21, 31, 53, 353, DateTimeKind.Local).AddTicks(8297), "Dương Thị G" },
                    { "KH0016", "123432156756", "Hà Nội", "0938481240", "Không", "Nam", new DateTime(1986, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 29, 21, 31, 53, 353, DateTimeKind.Local).AddTicks(8298), "Phan Văn G" },
                    { "KH0017", "123432156734", "TP Hồ Chí Minh", "0938484573", "Không", "Nữ", new DateTime(1991, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 29, 21, 31, 53, 353, DateTimeKind.Local).AddTicks(8299), "Trịnh Thị H" },
                    { "KH0018", "123432156775", "Hà Nội", "0938481241", "Không", "Nam", new DateTime(1987, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 29, 21, 31, 53, 353, DateTimeKind.Local).AddTicks(8300), "Nguyễn Văn H" },
                    { "KH0019", "123432156734", "TP Hồ Chí Minh", "0938484574", "Không", "Nữ", new DateTime(1992, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 29, 21, 31, 53, 353, DateTimeKind.Local).AddTicks(8302), "Lê Thị I" },
                    { "KH0020", "123432156765", "Hà Nội", "0938481242", "Không", "Nam", new DateTime(1988, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 29, 21, 31, 53, 353, DateTimeKind.Local).AddTicks(8303), "Đỗ Văn I" }
                });

            migrationBuilder.InsertData(
                table: "NhanViens",
                columns: new[] { "MaNhanVien", "CCCD", "ChucVu", "DiaChi", "DienThoai", "Email", "GhiChu", "GioiTinh", "NgaySinh", "NgayVaoLam", "TenNhanVien" },
                values: new object[,]
                {
                    { "NV0001", "123456314789", "Quản lý", "Hà Nội", "0938481234", "nhutbmt82@gmail.com", "Không", "Nam", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Văn A" },
                    { "NV0002", "982347654321", "Nhân viên", "TP Hồ Chí Minh", "0938484567", "ttb@gmail.com", "Không", "Nữ", new DateTime(1985, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trần Thị B" },
                    { "NV0003", "123456732190", "Nhân viên", "Hà Nội", "0938481235", "lvc@gmail.com", "Không", "Nam", new DateTime(1982, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Văn C" },
                    { "NV0004", "987652314322", "Nhân viên", "TP Hồ Chí Minh", "0938484568", "ptd@gmail.com", "Không", "Nữ", new DateTime(1986, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phạm Thị D" },
                    { "NV0005", "123324456791", "Nhân viên", "Hà Nội", "0938481236", "nve@gmail.com", "Không", "Nam", new DateTime(1983, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Văn E" },
                    { "NV0006", "987655674323", "Quản lý", "TP Hồ Chí Minh", "0938484569", "ttf@gmail.com", "Không", "Nữ", new DateTime(1987, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trần Thị F" },
                    { "NV0007", "123454346792", "Nhân viên", "Hà Nội", "0938481237", "dvg@gmail.com", "Không", "Nam", new DateTime(1984, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 29, 21, 31, 53, 353, DateTimeKind.Local).AddTicks(8447), "Đặng Văn G" },
                    { "NV0008", "987654444324", "Quản lý", "TP Hồ Chí Minh", "0938484570", "vth@gmail.com", "Không", "Nữ", new DateTime(1988, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 29, 21, 31, 53, 353, DateTimeKind.Local).AddTicks(8449), "Vũ Thị H" },
                    { "NV0009", "123456545793", "Nhân viên", "Hà Nội", "0938481238", "bvi@gmail.com", "Không", "Nam", new DateTime(1985, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 29, 21, 31, 53, 353, DateTimeKind.Local).AddTicks(8450), "Bùi Văn I" },
                    { "NV0010", "987654444325", "Nhân viên", "TP Hồ Chí Minh", "0938484571", "ntj@gmail.com", "Không", "Nữ", new DateTime(1989, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 29, 21, 31, 53, 353, DateTimeKind.Local).AddTicks(8452), "Ngô Thị J" }
                });

            migrationBuilder.InsertData(
                table: "Phong",
                columns: new[] { "MaPhong", "GiaTheoGio", "GiaTheoNgay", "HangPhong", "KhuVuc", "TrangThai" },
                values: new object[,]
                {
                    { "101", 100000, 600000, "Phòng Đơn", "A", "Trống" },
                    { "102", 200000, 1000000, "Phòng Đôi", "A", "Trống" },
                    { "103", 100000, 600000, "Phòng Đơn", "B", "Trống" },
                    { "104", 100000, 600000, "Phòng Đơn", "B", "Trống" },
                    { "201", 200000, 1000000, "Phòng Đôi", "C", "Trống" },
                    { "202", 100000, 600000, "Phòng Đơn", "A", "Trống" },
                    { "203", 200000, 1000000, "Phòng Đôi", "B", "Trống" },
                    { "204", 100000, 600000, "Phòng Đơn", "B", "Trống" },
                    { "301", 200000, 1000000, "Phòng Đôi", "C", "Trống" },
                    { "302", 100000, 600000, "Phòng Đơn", "A", "Trống" },
                    { "303", 200000, 1000000, "Phòng Đôi", "B", "Trống" },
                    { "304", 100000, 600000, "Phòng Đơn", "B", "Trống" },
                    { "401", 200000, 1000000, "Phòng Đôi", "C", "Trống" },
                    { "402", 100000, 600000, "Phòng Đơn", "A", "Trống" },
                    { "403", 200000, 1000000, "Phòng Đôi", "B", "Trống" },
                    { "404", 100000, 600000, "Phòng Đơn", "B", "Trống" }
                });

            migrationBuilder.InsertData(
                table: "TaiKhoan",
                columns: new[] { "TenDangNhap", "Email", "MatKhau", "NgayTao" },
                values: new object[,]
                {
                    { "admin", "nhutbmt82@gmail.com", "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "user", "be123@gmail.com", "user", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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

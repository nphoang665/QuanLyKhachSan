using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKhachSan.Migrations
{
    /// <inheritdoc />
    public partial class AddHoaDonToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaDatPhong",
                table: "HoaDon",
                type: "char(6)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaKhachHang",
                table: "HoaDon",
                type: "char(6)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaNhanVien",
                table: "HoaDon",
                type: "char(6)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaPhong",
                table: "HoaDon",
                type: "char(3)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaDatPhong",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "MaKhachHang",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "MaNhanVien",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "MaPhong",
                table: "HoaDon");
        }
    }
}

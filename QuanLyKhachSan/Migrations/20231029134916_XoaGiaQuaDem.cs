using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKhachSan.Migrations
{
    /// <inheritdoc />
    public partial class XoaGiaQuaDem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiaTheoQuaDem",
                table: "Phong");

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "NhanViens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "KhachHangs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GiaTheoQuaDem",
                table: "Phong",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "NhanViens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "KhachHangs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Phong",
                keyColumn: "MaPhong",
                keyValue: "101",
                column: "GiaTheoQuaDem",
                value: 500000);

            migrationBuilder.UpdateData(
                table: "Phong",
                keyColumn: "MaPhong",
                keyValue: "102",
                column: "GiaTheoQuaDem",
                value: 300000);

            migrationBuilder.UpdateData(
                table: "Phong",
                keyColumn: "MaPhong",
                keyValue: "103",
                column: "GiaTheoQuaDem",
                value: 500000);

            migrationBuilder.UpdateData(
                table: "Phong",
                keyColumn: "MaPhong",
                keyValue: "104",
                column: "GiaTheoQuaDem",
                value: 300000);

            migrationBuilder.UpdateData(
                table: "Phong",
                keyColumn: "MaPhong",
                keyValue: "201",
                column: "GiaTheoQuaDem",
                value: 500000);

            migrationBuilder.UpdateData(
                table: "Phong",
                keyColumn: "MaPhong",
                keyValue: "202",
                column: "GiaTheoQuaDem",
                value: 300000);

            migrationBuilder.UpdateData(
                table: "Phong",
                keyColumn: "MaPhong",
                keyValue: "203",
                column: "GiaTheoQuaDem",
                value: 500000);

            migrationBuilder.UpdateData(
                table: "Phong",
                keyColumn: "MaPhong",
                keyValue: "204",
                column: "GiaTheoQuaDem",
                value: 300000);

            migrationBuilder.UpdateData(
                table: "Phong",
                keyColumn: "MaPhong",
                keyValue: "301",
                column: "GiaTheoQuaDem",
                value: 500000);

            migrationBuilder.UpdateData(
                table: "Phong",
                keyColumn: "MaPhong",
                keyValue: "302",
                column: "GiaTheoQuaDem",
                value: 300000);

            migrationBuilder.UpdateData(
                table: "Phong",
                keyColumn: "MaPhong",
                keyValue: "303",
                column: "GiaTheoQuaDem",
                value: 500000);

            migrationBuilder.UpdateData(
                table: "Phong",
                keyColumn: "MaPhong",
                keyValue: "304",
                column: "GiaTheoQuaDem",
                value: 300000);

            migrationBuilder.UpdateData(
                table: "Phong",
                keyColumn: "MaPhong",
                keyValue: "401",
                column: "GiaTheoQuaDem",
                value: 500000);

            migrationBuilder.UpdateData(
                table: "Phong",
                keyColumn: "MaPhong",
                keyValue: "402",
                column: "GiaTheoQuaDem",
                value: 300000);

            migrationBuilder.UpdateData(
                table: "Phong",
                keyColumn: "MaPhong",
                keyValue: "403",
                column: "GiaTheoQuaDem",
                value: 500000);

            migrationBuilder.UpdateData(
                table: "Phong",
                keyColumn: "MaPhong",
                keyValue: "404",
                column: "GiaTheoQuaDem",
                value: 300000);
        }
    }
}

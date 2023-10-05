using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKhachSan.DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class SuaMaDatPhong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HangPhong",
                table: "DatPhongs");

            migrationBuilder.DropColumn(
                name: "Phong",
                table: "DatPhongs");

            migrationBuilder.AlterColumn<int>(
                name: "ThanhTien",
                table: "DatPhongs",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "MaKhachHang",
                table: "DatPhongs",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "GiaPhong",
                table: "DatPhongs",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "MaNhanVien",
                table: "DatPhongs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaPhong",
                table: "DatPhongs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddForeignKey(
                name: "FK_DatPhongs_KhachHangs_MaKhachHang",
                table: "DatPhongs",
                column: "MaKhachHang",
                principalTable: "KhachHangs",
                principalColumn: "MaKhachHang",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DatPhongs_NhanViens_MaNhanVien",
                table: "DatPhongs",
                column: "MaNhanVien",
                principalTable: "NhanViens",
                principalColumn: "MaNhanVien",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DatPhongs_Phong_MaPhong",
                table: "DatPhongs",
                column: "MaPhong",
                principalTable: "Phong",
                principalColumn: "MaPhong",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DatPhongs_KhachHangs_MaKhachHang",
                table: "DatPhongs");

            migrationBuilder.DropForeignKey(
                name: "FK_DatPhongs_NhanViens_MaNhanVien",
                table: "DatPhongs");

            migrationBuilder.DropForeignKey(
                name: "FK_DatPhongs_Phong_MaPhong",
                table: "DatPhongs");

            migrationBuilder.DropIndex(
                name: "IX_DatPhongs_MaKhachHang",
                table: "DatPhongs");

            migrationBuilder.DropIndex(
                name: "IX_DatPhongs_MaNhanVien",
                table: "DatPhongs");

            migrationBuilder.DropIndex(
                name: "IX_DatPhongs_MaPhong",
                table: "DatPhongs");

            migrationBuilder.DropColumn(
                name: "MaNhanVien",
                table: "DatPhongs");

            migrationBuilder.DropColumn(
                name: "MaPhong",
                table: "DatPhongs");

            migrationBuilder.AlterColumn<double>(
                name: "ThanhTien",
                table: "DatPhongs",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "MaKhachHang",
                table: "DatPhongs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<double>(
                name: "GiaPhong",
                table: "DatPhongs",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "HangPhong",
                table: "DatPhongs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phong",
                table: "DatPhongs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

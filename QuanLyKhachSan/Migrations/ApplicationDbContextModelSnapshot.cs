﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyKhachSan.DataAcess.Data;

#nullable disable

namespace QuanLyKhachSan.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DatPhong", b =>
                {
                    b.Property<string>("MaDatPhong")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DuKien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GiaPhong")
                        .HasColumnType("int");

                    b.Property<string>("HinhThuc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("KhachDaThanhToan")
                        .HasColumnType("real");

                    b.Property<string>("MaKhachHang")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaNhanVien")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaPhong")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgayNhan")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTra")
                        .HasColumnType("datetime2");

                    b.Property<byte>("SoNguoiO")
                        .HasColumnType("tinyint");

                    b.Property<float>("ThanhTien")
                        .HasColumnType("real");

                    b.HasKey("MaDatPhong");

                    b.HasIndex("MaKhachHang");

                    b.HasIndex("MaNhanVien");

                    b.HasIndex("MaPhong");

                    b.ToTable("DatPhongs");
                });

            modelBuilder.Entity("QuanLyKhachSan.Data.HoaDon", b =>
                {
                    b.Property<string>("MaHoaDon")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DuKien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GiaPhong")
                        .HasColumnType("int");

                    b.Property<string>("HinhThuc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaDatPhong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaKhachHang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaNhanVien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaPhong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayNhan")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTra")
                        .HasColumnType("datetime2");

                    b.Property<float>("ThanhTien")
                        .HasColumnType("real");

                    b.HasKey("MaHoaDon");

                    b.ToTable("HoaDon");
                });

            modelBuilder.Entity("QuanLyKhachSan.Model.KhachHang", b =>
                {
                    b.Property<string>("MaKhachHang")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CCCD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenKhachHang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaKhachHang");

                    b.ToTable("KhachHangs");

                    b.HasData(
                        new
                        {
                            MaKhachHang = "KH0001",
                            CCCD = "123432156789",
                            DiaChi = "Hà Nội",
                            DienThoai = "0938481234",
                            GhiChu = "Không",
                            GioiTinh = "Nam",
                            NgaySinh = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayTao = new DateTime(2023, 10, 29, 21, 36, 32, 354, DateTimeKind.Local).AddTicks(6655),
                            TenKhachHang = "Nguyễn Văn An"
                        },
                        new
                        {
                            MaKhachHang = "KH0002",
                            CCCD = "987654232321",
                            DiaChi = "TP Hồ Chí Minh",
                            DienThoai = "0938484567",
                            GhiChu = "Không",
                            GioiTinh = "Nữ",
                            NgaySinh = new DateTime(1985, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayTao = new DateTime(2023, 10, 29, 21, 36, 32, 354, DateTimeKind.Local).AddTicks(6669),
                            TenKhachHang = "Trần Thị Bé"
                        },
                        new
                        {
                            MaKhachHang = "KH0003",
                            CCCD = "123432156734",
                            DiaChi = "TP Hồ Chí Minh",
                            DienThoai = "0938485966",
                            GhiChu = "Không",
                            GioiTinh = "Nam",
                            NgaySinh = new DateTime(1988, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayTao = new DateTime(2023, 10, 29, 21, 36, 32, 354, DateTimeKind.Local).AddTicks(6670),
                            TenKhachHang = "Huỳnh An Cao"
                        },
                        new
                        {
                            MaKhachHang = "KH0004",
                            CCCD = "123432156754",
                            DiaChi = "TP Hồ Chí Minh",
                            DienThoai = "0938234166",
                            GhiChu = "Không",
                            GioiTinh = "Nữ",
                            NgaySinh = new DateTime(1995, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayTao = new DateTime(2023, 10, 29, 21, 36, 32, 354, DateTimeKind.Local).AddTicks(6672),
                            TenKhachHang = "Nguyễn Thị Bích"
                        },
                        new
                        {
                            MaKhachHang = "KH0005",
                            CCCD = "123432156785",
                            DiaChi = "TP Hồ Chí Minh",
                            DienThoai = "0938485966",
                            GhiChu = "Không",
                            GioiTinh = "Nữ",
                            NgaySinh = new DateTime(1985, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayTao = new DateTime(2023, 10, 29, 21, 36, 32, 354, DateTimeKind.Local).AddTicks(6673),
                            TenKhachHang = "Hồ Thị Mỹ"
                        },
                        new
                        {
                            MaKhachHang = "KH0006",
                            CCCD = "123432156782",
                            DiaChi = "Hà Nội",
                            DienThoai = "0938481235",
                            GhiChu = "Không",
                            GioiTinh = "Nam",
                            NgaySinh = new DateTime(1981, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayTao = new DateTime(2023, 10, 29, 21, 36, 32, 354, DateTimeKind.Local).AddTicks(6674),
                            TenKhachHang = "Nguyễn Văn B"
                        },
                        new
                        {
                            MaKhachHang = "KH0007",
                            CCCD = "123432156781",
                            DiaChi = "TP Hồ Chí Minh",
                            DienThoai = "0938484568",
                            GhiChu = "Không",
                            GioiTinh = "Nữ",
                            NgaySinh = new DateTime(1986, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayTao = new DateTime(2023, 10, 29, 21, 36, 32, 354, DateTimeKind.Local).AddTicks(6676),
                            TenKhachHang = "Trần Thị C"
                        },
                        new
                        {
                            MaKhachHang = "KH0008",
                            CCCD = "123432157823",
                            DiaChi = "Hà Nội",
                            DienThoai = "0938481236",
                            GhiChu = "Không",
                            GioiTinh = "Nam",
                            NgaySinh = new DateTime(1982, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayTao = new DateTime(2023, 10, 29, 21, 36, 32, 354, DateTimeKind.Local).AddTicks(6677),
                            TenKhachHang = "Lê Văn C"
                        },
                        new
                        {
                            MaKhachHang = "KH0009",
                            CCCD = "123432156733",
                            DiaChi = "TP Hồ Chí Minh",
                            DienThoai = "0938484569",
                            GhiChu = "Không",
                            GioiTinh = "Nữ",
                            NgaySinh = new DateTime(1987, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayTao = new DateTime(2023, 10, 29, 21, 36, 32, 354, DateTimeKind.Local).AddTicks(6678),
                            TenKhachHang = "Phạm Thị D"
                        },
                        new
                        {
                            MaKhachHang = "KH0010",
                            CCCD = "123432156734",
                            DiaChi = "Hà Nội",
                            DienThoai = "0938481237",
                            GhiChu = "Không",
                            GioiTinh = "Nam",
                            NgaySinh = new DateTime(1983, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayTao = new DateTime(2023, 10, 29, 21, 36, 32, 354, DateTimeKind.Local).AddTicks(6680),
                            TenKhachHang = "Đặng Văn D"
                        },
                        new
                        {
                            MaKhachHang = "KH0011",
                            CCCD = "123432156756",
                            DiaChi = "TP Hồ Chí Minh",
                            DienThoai = "0938484570",
                            GhiChu = "Không",
                            GioiTinh = "Nữ",
                            NgaySinh = new DateTime(1988, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayTao = new DateTime(2023, 10, 29, 21, 36, 32, 354, DateTimeKind.Local).AddTicks(6681),
                            TenKhachHang = "Vũ Thị E"
                        },
                        new
                        {
                            MaKhachHang = "KH0012",
                            CCCD = "123432156774",
                            DiaChi = "Hà Nội",
                            DienThoai = "0938481238",
                            GhiChu = "Không",
                            GioiTinh = "Nam",
                            NgaySinh = new DateTime(1984, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayTao = new DateTime(2023, 10, 29, 21, 36, 32, 354, DateTimeKind.Local).AddTicks(6682),
                            TenKhachHang = "Bùi Văn E"
                        },
                        new
                        {
                            MaKhachHang = "KH0013",
                            CCCD = "123432156775",
                            DiaChi = "TP Hồ Chí Minh",
                            DienThoai = "0938484571",
                            GhiChu = "Không",
                            GioiTinh = "Nữ",
                            NgaySinh = new DateTime(1989, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayTao = new DateTime(2023, 10, 29, 21, 36, 32, 354, DateTimeKind.Local).AddTicks(6685),
                            TenKhachHang = "Ngô Thị F"
                        },
                        new
                        {
                            MaKhachHang = "KH0014",
                            CCCD = "123432156756",
                            DiaChi = "Hà Nội",
                            DienThoai = "0938481239",
                            GhiChu = "Không",
                            GioiTinh = "Nam",
                            NgaySinh = new DateTime(1985, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayTao = new DateTime(2023, 10, 29, 21, 36, 32, 354, DateTimeKind.Local).AddTicks(6686),
                            TenKhachHang = "Lý Văn F"
                        },
                        new
                        {
                            MaKhachHang = "KH0015",
                            CCCD = "123432156775",
                            DiaChi = "TP Hồ Chí Minh",
                            DienThoai = "0938484572",
                            GhiChu = "Không",
                            GioiTinh = "Nữ",
                            NgaySinh = new DateTime(1990, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayTao = new DateTime(2023, 10, 29, 21, 36, 32, 354, DateTimeKind.Local).AddTicks(6687),
                            TenKhachHang = "Dương Thị G"
                        },
                        new
                        {
                            MaKhachHang = "KH0016",
                            CCCD = "123432156756",
                            DiaChi = "Hà Nội",
                            DienThoai = "0938481240",
                            GhiChu = "Không",
                            GioiTinh = "Nam",
                            NgaySinh = new DateTime(1986, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayTao = new DateTime(2023, 10, 29, 21, 36, 32, 354, DateTimeKind.Local).AddTicks(6689),
                            TenKhachHang = "Phan Văn G"
                        },
                        new
                        {
                            MaKhachHang = "KH0017",
                            CCCD = "123432156734",
                            DiaChi = "TP Hồ Chí Minh",
                            DienThoai = "0938484573",
                            GhiChu = "Không",
                            GioiTinh = "Nữ",
                            NgaySinh = new DateTime(1991, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayTao = new DateTime(2023, 10, 29, 21, 36, 32, 354, DateTimeKind.Local).AddTicks(6690),
                            TenKhachHang = "Trịnh Thị H"
                        },
                        new
                        {
                            MaKhachHang = "KH0018",
                            CCCD = "123432156775",
                            DiaChi = "Hà Nội",
                            DienThoai = "0938481241",
                            GhiChu = "Không",
                            GioiTinh = "Nam",
                            NgaySinh = new DateTime(1987, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayTao = new DateTime(2023, 10, 29, 21, 36, 32, 354, DateTimeKind.Local).AddTicks(6691),
                            TenKhachHang = "Nguyễn Văn H"
                        },
                        new
                        {
                            MaKhachHang = "KH0019",
                            CCCD = "123432156734",
                            DiaChi = "TP Hồ Chí Minh",
                            DienThoai = "0938484574",
                            GhiChu = "Không",
                            GioiTinh = "Nữ",
                            NgaySinh = new DateTime(1992, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayTao = new DateTime(2023, 10, 29, 21, 36, 32, 354, DateTimeKind.Local).AddTicks(6692),
                            TenKhachHang = "Lê Thị I"
                        },
                        new
                        {
                            MaKhachHang = "KH0020",
                            CCCD = "123432156765",
                            DiaChi = "Hà Nội",
                            DienThoai = "0938481242",
                            GhiChu = "Không",
                            GioiTinh = "Nam",
                            NgaySinh = new DateTime(1988, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayTao = new DateTime(2023, 10, 29, 21, 36, 32, 354, DateTimeKind.Local).AddTicks(6694),
                            TenKhachHang = "Đỗ Văn I"
                        });
                });

            modelBuilder.Entity("QuanLyKhachSan.Model.NhanVien", b =>
                {
                    b.Property<string>("MaNhanVien")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CCCD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChucVu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayVaoLam")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenNhanVien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaNhanVien");

                    b.ToTable("NhanViens");

                    b.HasData(
                        new
                        {
                            MaNhanVien = "NV0001",
                            CCCD = "123456314789",
                            ChucVu = "Quản lý",
                            DiaChi = "Hà Nội",
                            DienThoai = "0938481234",
                            Email = "nhutbmt82@gmail.com",
                            GhiChu = "Không",
                            GioiTinh = "Nam",
                            NgaySinh = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayVaoLam = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenNhanVien = "Nguyễn Văn A"
                        },
                        new
                        {
                            MaNhanVien = "NV0002",
                            CCCD = "982347654321",
                            ChucVu = "Nhân viên",
                            DiaChi = "TP Hồ Chí Minh",
                            DienThoai = "0938484567",
                            Email = "ttb@gmail.com",
                            GhiChu = "Không",
                            GioiTinh = "Nữ",
                            NgaySinh = new DateTime(1985, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayVaoLam = new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenNhanVien = "Trần Thị B"
                        },
                        new
                        {
                            MaNhanVien = "NV0003",
                            CCCD = "123456732190",
                            ChucVu = "Nhân viên",
                            DiaChi = "Hà Nội",
                            DienThoai = "0938481235",
                            Email = "lvc@gmail.com",
                            GhiChu = "Không",
                            GioiTinh = "Nam",
                            NgaySinh = new DateTime(1982, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayVaoLam = new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenNhanVien = "Lê Văn C"
                        },
                        new
                        {
                            MaNhanVien = "NV0004",
                            CCCD = "987652314322",
                            ChucVu = "Nhân viên",
                            DiaChi = "TP Hồ Chí Minh",
                            DienThoai = "0938484568",
                            Email = "ptd@gmail.com",
                            GhiChu = "Không",
                            GioiTinh = "Nữ",
                            NgaySinh = new DateTime(1986, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayVaoLam = new DateTime(2021, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenNhanVien = "Phạm Thị D"
                        },
                        new
                        {
                            MaNhanVien = "NV0005",
                            CCCD = "123324456791",
                            ChucVu = "Nhân viên",
                            DiaChi = "Hà Nội",
                            DienThoai = "0938481236",
                            Email = "nve@gmail.com",
                            GhiChu = "Không",
                            GioiTinh = "Nam",
                            NgaySinh = new DateTime(1983, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayVaoLam = new DateTime(2020, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenNhanVien = "Nguyễn Văn E"
                        },
                        new
                        {
                            MaNhanVien = "NV0006",
                            CCCD = "987655674323",
                            ChucVu = "Quản lý",
                            DiaChi = "TP Hồ Chí Minh",
                            DienThoai = "0938484569",
                            Email = "ttf@gmail.com",
                            GhiChu = "Không",
                            GioiTinh = "Nữ",
                            NgaySinh = new DateTime(1987, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayVaoLam = new DateTime(2021, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenNhanVien = "Trần Thị F"
                        },
                        new
                        {
                            MaNhanVien = "NV0007",
                            CCCD = "123454346792",
                            ChucVu = "Nhân viên",
                            DiaChi = "Hà Nội",
                            DienThoai = "0938481237",
                            Email = "dvg@gmail.com",
                            GhiChu = "Không",
                            GioiTinh = "Nam",
                            NgaySinh = new DateTime(1984, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayVaoLam = new DateTime(2023, 10, 29, 21, 36, 32, 354, DateTimeKind.Local).AddTicks(6834),
                            TenNhanVien = "Đặng Văn G"
                        },
                        new
                        {
                            MaNhanVien = "NV0008",
                            CCCD = "987654444324",
                            ChucVu = "Quản lý",
                            DiaChi = "TP Hồ Chí Minh",
                            DienThoai = "0938484570",
                            Email = "vth@gmail.com",
                            GhiChu = "Không",
                            GioiTinh = "Nữ",
                            NgaySinh = new DateTime(1988, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayVaoLam = new DateTime(2023, 10, 29, 21, 36, 32, 354, DateTimeKind.Local).AddTicks(6836),
                            TenNhanVien = "Vũ Thị H"
                        },
                        new
                        {
                            MaNhanVien = "NV0009",
                            CCCD = "123456545793",
                            ChucVu = "Nhân viên",
                            DiaChi = "Hà Nội",
                            DienThoai = "0938481238",
                            Email = "bvi@gmail.com",
                            GhiChu = "Không",
                            GioiTinh = "Nam",
                            NgaySinh = new DateTime(1985, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayVaoLam = new DateTime(2023, 10, 29, 21, 36, 32, 354, DateTimeKind.Local).AddTicks(6837),
                            TenNhanVien = "Bùi Văn I"
                        },
                        new
                        {
                            MaNhanVien = "NV0010",
                            CCCD = "987654444325",
                            ChucVu = "Nhân viên",
                            DiaChi = "TP Hồ Chí Minh",
                            DienThoai = "0938484571",
                            Email = "ntj@gmail.com",
                            GhiChu = "Không",
                            GioiTinh = "Nữ",
                            NgaySinh = new DateTime(1989, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayVaoLam = new DateTime(2023, 10, 29, 21, 36, 32, 354, DateTimeKind.Local).AddTicks(6839),
                            TenNhanVien = "Ngô Thị J"
                        });
                });

            modelBuilder.Entity("QuanLyKhachSan.Model.Room", b =>
                {
                    b.Property<string>("MaPhong")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("GiaTheoGio")
                        .HasColumnType("int");

                    b.Property<int>("GiaTheoNgay")
                        .HasColumnType("int");

                    b.Property<string>("HangPhong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KhuVuc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrangThai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaPhong");

                    b.ToTable("Phong");

                    b.HasData(
                        new
                        {
                            MaPhong = "101",
                            GiaTheoGio = 100000,
                            GiaTheoNgay = 600000,
                            HangPhong = "Phòng Đơn",
                            KhuVuc = "A",
                            TrangThai = "Trống"
                        },
                        new
                        {
                            MaPhong = "102",
                            GiaTheoGio = 200000,
                            GiaTheoNgay = 1000000,
                            HangPhong = "Phòng Đôi",
                            KhuVuc = "A",
                            TrangThai = "Trống"
                        },
                        new
                        {
                            MaPhong = "103",
                            GiaTheoGio = 100000,
                            GiaTheoNgay = 600000,
                            HangPhong = "Phòng Đơn",
                            KhuVuc = "B",
                            TrangThai = "Trống"
                        },
                        new
                        {
                            MaPhong = "104",
                            GiaTheoGio = 100000,
                            GiaTheoNgay = 600000,
                            HangPhong = "Phòng Đơn",
                            KhuVuc = "B",
                            TrangThai = "Trống"
                        },
                        new
                        {
                            MaPhong = "201",
                            GiaTheoGio = 200000,
                            GiaTheoNgay = 1000000,
                            HangPhong = "Phòng Đôi",
                            KhuVuc = "C",
                            TrangThai = "Trống"
                        },
                        new
                        {
                            MaPhong = "202",
                            GiaTheoGio = 100000,
                            GiaTheoNgay = 600000,
                            HangPhong = "Phòng Đơn",
                            KhuVuc = "A",
                            TrangThai = "Trống"
                        },
                        new
                        {
                            MaPhong = "203",
                            GiaTheoGio = 200000,
                            GiaTheoNgay = 1000000,
                            HangPhong = "Phòng Đôi",
                            KhuVuc = "B",
                            TrangThai = "Trống"
                        },
                        new
                        {
                            MaPhong = "204",
                            GiaTheoGio = 100000,
                            GiaTheoNgay = 600000,
                            HangPhong = "Phòng Đơn",
                            KhuVuc = "B",
                            TrangThai = "Trống"
                        },
                        new
                        {
                            MaPhong = "301",
                            GiaTheoGio = 200000,
                            GiaTheoNgay = 1000000,
                            HangPhong = "Phòng Đôi",
                            KhuVuc = "C",
                            TrangThai = "Trống"
                        },
                        new
                        {
                            MaPhong = "302",
                            GiaTheoGio = 100000,
                            GiaTheoNgay = 600000,
                            HangPhong = "Phòng Đơn",
                            KhuVuc = "A",
                            TrangThai = "Trống"
                        },
                        new
                        {
                            MaPhong = "303",
                            GiaTheoGio = 200000,
                            GiaTheoNgay = 1000000,
                            HangPhong = "Phòng Đôi",
                            KhuVuc = "B",
                            TrangThai = "Trống"
                        },
                        new
                        {
                            MaPhong = "304",
                            GiaTheoGio = 100000,
                            GiaTheoNgay = 600000,
                            HangPhong = "Phòng Đơn",
                            KhuVuc = "B",
                            TrangThai = "Trống"
                        },
                        new
                        {
                            MaPhong = "401",
                            GiaTheoGio = 200000,
                            GiaTheoNgay = 1000000,
                            HangPhong = "Phòng Đôi",
                            KhuVuc = "C",
                            TrangThai = "Trống"
                        },
                        new
                        {
                            MaPhong = "402",
                            GiaTheoGio = 100000,
                            GiaTheoNgay = 600000,
                            HangPhong = "Phòng Đơn",
                            KhuVuc = "A",
                            TrangThai = "Trống"
                        },
                        new
                        {
                            MaPhong = "403",
                            GiaTheoGio = 200000,
                            GiaTheoNgay = 1000000,
                            HangPhong = "Phòng Đôi",
                            KhuVuc = "B",
                            TrangThai = "Trống"
                        },
                        new
                        {
                            MaPhong = "404",
                            GiaTheoGio = 100000,
                            GiaTheoNgay = 600000,
                            HangPhong = "Phòng Đơn",
                            KhuVuc = "B",
                            TrangThai = "Trống"
                        });
                });

            modelBuilder.Entity("QuanLyKhachSan.Model.TaiKhoan", b =>
                {
                    b.Property<string>("TenDangNhap")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.HasKey("TenDangNhap");

                    b.ToTable("TaiKhoan");

                    b.HasData(
                        new
                        {
                            TenDangNhap = "admin",
                            Email = "nhutbmt82@gmail.com",
                            MatKhau = "admin",
                            NgayTao = new DateTime(2023, 10, 29, 21, 36, 32, 354, DateTimeKind.Local).AddTicks(6890)
                        },
                        new
                        {
                            TenDangNhap = "user",
                            Email = "be123@gmail.com",
                            MatKhau = "user",
                            NgayTao = new DateTime(2023, 10, 29, 21, 36, 32, 354, DateTimeKind.Local).AddTicks(6893)
                        });
                });

            modelBuilder.Entity("DatPhong", b =>
                {
                    b.HasOne("QuanLyKhachSan.Model.KhachHang", "KhachHang")
                        .WithMany()
                        .HasForeignKey("MaKhachHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyKhachSan.Model.NhanVien", "NhanVien")
                        .WithMany()
                        .HasForeignKey("MaNhanVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyKhachSan.Model.Room", "Phong")
                        .WithMany()
                        .HasForeignKey("MaPhong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhachHang");

                    b.Navigation("NhanVien");

                    b.Navigation("Phong");
                });
#pragma warning restore 612, 618
        }
    }
}

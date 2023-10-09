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

                    b.Property<float>("ThanhTien")
                        .HasColumnType("real");

                    b.HasKey("MaDatPhong");

                    b.HasIndex("MaKhachHang");

                    b.HasIndex("MaNhanVien");

                    b.HasIndex("MaPhong");

                    b.ToTable("DatPhongs");
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgaySinh")
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
                            CCCD = "123456789",
                            DiaChi = "Hà Nội",
                            DienThoai = "0938481234",
                            GhiChu = "Không",
                            GioiTinh = "Nam",
                            NgaySinh = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenKhachHang = "Nguyễn Văn An"
                        },
                        new
                        {
                            MaKhachHang = "KH0002",
                            CCCD = "987654321",
                            DiaChi = "TP Hồ Chí Minh",
                            DienThoai = "0938484567",
                            GhiChu = "Không",
                            GioiTinh = "Nữ",
                            NgaySinh = new DateTime(1985, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenKhachHang = "Trần Thị Bé"
                        },
                        new
                        {
                            MaKhachHang = "KH0003",
                            CCCD = "987654321",
                            DiaChi = "TP Hồ Chí Minh",
                            DienThoai = "0938485966",
                            GhiChu = "Không",
                            GioiTinh = "Nam",
                            NgaySinh = new DateTime(1988, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenKhachHang = "Huỳnh An Cao"
                        },
                        new
                        {
                            MaKhachHang = "KH0004",
                            CCCD = "987654321",
                            DiaChi = "TP Hồ Chí Minh",
                            DienThoai = "0938234166",
                            GhiChu = "Không",
                            GioiTinh = "Nữ",
                            NgaySinh = new DateTime(1995, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenKhachHang = "Nguyễn Thị Bích"
                        },
                        new
                        {
                            MaKhachHang = "KH0005",
                            CCCD = "987654321",
                            DiaChi = "TP Hồ Chí Minh",
                            DienThoai = "0938485966",
                            GhiChu = "Không",
                            GioiTinh = "Nữ",
                            NgaySinh = new DateTime(1985, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenKhachHang = "Hồ Thị Mỹ"
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

                    b.Property<string>("GhiChu")
                        .IsRequired()
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
                            CCCD = "123456789",
                            ChucVu = "Quản lý",
                            DiaChi = "Hà Nội",
                            DienThoai = "0123456789",
                            GhiChu = "Không",
                            GioiTinh = "Nam",
                            NgaySinh = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayVaoLam = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenNhanVien = "Nguyễn Văn A"
                        },
                        new
                        {
                            MaNhanVien = "NV0002",
                            CCCD = "987654321",
                            ChucVu = "Nhân viên",
                            DiaChi = "TP Hồ Chí Minh",
                            DienThoai = "0987654321",
                            GhiChu = "Không",
                            GioiTinh = "Nữ",
                            NgaySinh = new DateTime(1985, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayVaoLam = new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenNhanVien = "Trần Thị B"
                        },
                        new
                        {
                            MaNhanVien = "NV0003",
                            CCCD = "234567890",
                            ChucVu = "Quản lý",
                            DiaChi = "Đà Nẵng",
                            DienThoai = "0234567890",
                            GhiChu = "Không",
                            GioiTinh = "Nam",
                            NgaySinh = new DateTime(1990, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayVaoLam = new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenNhanVien = "Phạm Văn C"
                        },
                        new
                        {
                            MaNhanVien = "NV0004",
                            CCCD = "345678901",
                            ChucVu = "Nhân viên",
                            DiaChi = "Cần Thơ",
                            DienThoai = "0345678901",
                            GhiChu = "Không",
                            GioiTinh = "Nữ",
                            NgaySinh = new DateTime(1995, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayVaoLam = new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenNhanVien = "Lê Thị D"
                        },
                        new
                        {
                            MaNhanVien = "NV0005",
                            CCCD = "456789012",
                            ChucVu = "Quản lý",
                            DiaChi = "Hải Phòng",
                            DienThoai = "0456789012",
                            GhiChu = "Không",
                            GioiTinh = "Nam",
                            NgaySinh = new DateTime(2000, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgayVaoLam = new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenNhanVien = "Hoàng Văn E"
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

                    b.Property<int>("GiaTheoQuaDem")
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
                            GiaTheoGio = 200000,
                            GiaTheoNgay = 1000000,
                            GiaTheoQuaDem = 500000,
                            HangPhong = "VIP",
                            KhuVuc = "A",
                            TrangThai = "Trống"
                        },
                        new
                        {
                            MaPhong = "102",
                            GiaTheoGio = 100000,
                            GiaTheoNgay = 600000,
                            GiaTheoQuaDem = 300000,
                            HangPhong = "Thường",
                            KhuVuc = "A",
                            TrangThai = "Trống"
                        },
                        new
                        {
                            MaPhong = "103",
                            GiaTheoGio = 200000,
                            GiaTheoNgay = 1000000,
                            GiaTheoQuaDem = 500000,
                            HangPhong = "VIP",
                            KhuVuc = "B",
                            TrangThai = "Đang sử dụng"
                        },
                        new
                        {
                            MaPhong = "104",
                            GiaTheoGio = 100000,
                            GiaTheoNgay = 600000,
                            GiaTheoQuaDem = 300000,
                            HangPhong = "Thường",
                            KhuVuc = "B",
                            TrangThai = "Đang sử dụng"
                        },
                        new
                        {
                            MaPhong = "201",
                            GiaTheoGio = 200000,
                            GiaTheoNgay = 1000000,
                            GiaTheoQuaDem = 500000,
                            HangPhong = "VIP",
                            KhuVuc = "C",
                            TrangThai = "Trống"
                        },
                        new
                        {
                            MaPhong = "202",
                            GiaTheoGio = 100000,
                            GiaTheoNgay = 600000,
                            GiaTheoQuaDem = 300000,
                            HangPhong = "Thường",
                            KhuVuc = "A",
                            TrangThai = "Trống"
                        },
                        new
                        {
                            MaPhong = "203",
                            GiaTheoGio = 200000,
                            GiaTheoNgay = 1000000,
                            GiaTheoQuaDem = 500000,
                            HangPhong = "VIP",
                            KhuVuc = "B",
                            TrangThai = "Đang sử dụng"
                        },
                        new
                        {
                            MaPhong = "204",
                            GiaTheoGio = 100000,
                            GiaTheoNgay = 600000,
                            GiaTheoQuaDem = 300000,
                            HangPhong = "Thường",
                            KhuVuc = "B",
                            TrangThai = "Đang sử dụng"
                        },
                        new
                        {
                            MaPhong = "301",
                            GiaTheoGio = 200000,
                            GiaTheoNgay = 1000000,
                            GiaTheoQuaDem = 500000,
                            HangPhong = "VIP",
                            KhuVuc = "C",
                            TrangThai = "Trống"
                        },
                        new
                        {
                            MaPhong = "302",
                            GiaTheoGio = 100000,
                            GiaTheoNgay = 600000,
                            GiaTheoQuaDem = 300000,
                            HangPhong = "Thường",
                            KhuVuc = "A",
                            TrangThai = "Trống"
                        },
                        new
                        {
                            MaPhong = "303",
                            GiaTheoGio = 200000,
                            GiaTheoNgay = 1000000,
                            GiaTheoQuaDem = 500000,
                            HangPhong = "VIP",
                            KhuVuc = "B",
                            TrangThai = "Đang sử dụng"
                        },
                        new
                        {
                            MaPhong = "304",
                            GiaTheoGio = 100000,
                            GiaTheoNgay = 600000,
                            GiaTheoQuaDem = 300000,
                            HangPhong = "Thường",
                            KhuVuc = "B",
                            TrangThai = "Đang sử dụng"
                        },
                        new
                        {
                            MaPhong = "401",
                            GiaTheoGio = 200000,
                            GiaTheoNgay = 1000000,
                            GiaTheoQuaDem = 500000,
                            HangPhong = "VIP",
                            KhuVuc = "C",
                            TrangThai = "Trống"
                        },
                        new
                        {
                            MaPhong = "402",
                            GiaTheoGio = 100000,
                            GiaTheoNgay = 600000,
                            GiaTheoQuaDem = 300000,
                            HangPhong = "Thường",
                            KhuVuc = "A",
                            TrangThai = "Trống"
                        },
                        new
                        {
                            MaPhong = "403",
                            GiaTheoGio = 200000,
                            GiaTheoNgay = 1000000,
                            GiaTheoQuaDem = 500000,
                            HangPhong = "VIP",
                            KhuVuc = "B",
                            TrangThai = "Đang sử dụng"
                        },
                        new
                        {
                            MaPhong = "404",
                            GiaTheoGio = 100000,
                            GiaTheoNgay = 600000,
                            GiaTheoQuaDem = 300000,
                            HangPhong = "Thường",
                            KhuVuc = "B",
                            TrangThai = "Đang sử dụng"
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

                    b.HasKey("TenDangNhap");

                    b.ToTable("TaiKhoan");

                    b.HasData(
                        new
                        {
                            TenDangNhap = "admin",
                            Email = "admin@gmail.com",
                            MatKhau = "admin"
                        },
                        new
                        {
                            TenDangNhap = "user",
                            Email = "user@gmail.com",
                            MatKhau = "user"
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

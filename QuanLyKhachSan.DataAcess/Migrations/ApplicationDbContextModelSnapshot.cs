﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyKhachSan.DataAcess.Data;

#nullable disable

namespace QuanLyKhachSan.DataAcess.Migrations
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

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyKhachSan.DataAcess.Data;

#nullable disable

namespace QuanLyKhachSan.DataAcess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231002141629_AddEmailClassTaiKhoanToDb")]
    partial class AddEmailClassTaiKhoanToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QuanLyKhachSan.Model.DatPhong", b =>
                {
                    b.Property<string>("MaDatPhong")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DuKien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("GiaPhong")
                        .HasColumnType("float");

                    b.Property<string>("HangPhong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HinhThuc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaKhachHang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayNhan")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTra")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ThanhTien")
                        .HasColumnType("float");

                    b.HasKey("MaDatPhong");

                    b.ToTable("DatPhongs");
                });

            modelBuilder.Entity("QuanLyKhachSan.Model.KhachHang", b =>
                {
                    b.Property<string>("MaKhachHang")
                        .HasColumnType("nvarchar(450)");

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

                    b.Property<string>("GhiChu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("GiaTheoGio")
                        .HasColumnType("float");

                    b.Property<double>("GiaTheoNgay")
                        .HasColumnType("float");

                    b.Property<double>("GiaTheoQuaDem")
                        .HasColumnType("float");

                    b.Property<string>("HangPhong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KhuVuc")
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
#pragma warning restore 612, 618
        }
    }
}
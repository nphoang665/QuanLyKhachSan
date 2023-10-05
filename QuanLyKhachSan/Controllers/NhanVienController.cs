﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.DataAcess.Data;
using QuanLyKhachSan.Model;

namespace QuanLyKhachSan.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly ApplicationDbContext _db;
        public NhanVienController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 7;
            int totalKhachHangs = await _db.NhanViens.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalKhachHangs / pageSize);

            if (page < 1)
                page = 1;
            else if (page > totalPages)
                page = totalPages;

            var paginatedKhachHangs = await _db.NhanViens
                .OrderBy(kh => kh.MaNhanVien)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewData["TotalPagesNhanVien"] = totalPages;
            ViewData["CurrentPageNhanVien"] = page;

            return View(paginatedKhachHangs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ThemNhanVien()
        {
            var formCollection = Request.Form;

            var nhanvien = new NhanVien
            {
                MaNhanVien = formCollection["MaNhanVien"],
                TenNhanVien = formCollection["TenNhanVien"],
                CCCD = formCollection["CCCD"],
                GioiTinh = formCollection["GioiTinh"],
                NgaySinh = DateTime.Parse(formCollection["NgaySinh"]),
                ChucVu = formCollection["ChucVu"],
                DienThoai = formCollection["DienThoai"],
                DiaChi = formCollection["DiaChi"],
                NgayVaoLam = DateTime.Parse(formCollection["NgayVaoLam"]),
                GhiChu = formCollection["GhiChu"]
            };

            if (ModelState.IsValid)
            {

                _db.NhanViens.Add(nhanvien);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhanvien);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SuaNhanVien()
        {
            var formCollection = Request.Form;

            var nhanvien = new NhanVien();
            nhanvien.MaNhanVien = formCollection["MaNhanVienSua"];
            nhanvien.TenNhanVien = formCollection["TenNhanVienSua"];
            nhanvien.CCCD = formCollection["CCCDSua"];
            nhanvien.GioiTinh = formCollection["GioiTinhSua"];
            nhanvien.NgaySinh = DateTime.Parse(formCollection["NgaySinhSua"]);
            nhanvien.ChucVu = formCollection["ChucVuSua"];
            nhanvien.DienThoai = formCollection["DienThoaiSua"];
            nhanvien.DiaChi = formCollection["DiaChiSua"];
            nhanvien.NgayVaoLam = DateTime.Parse(formCollection["NgayVaoLamSua"]);
            nhanvien.GhiChu = formCollection["GhiChuSua"];

            if (ModelState.IsValid)
            {

                _db.NhanViens.Update(nhanvien);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhanvien);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult XoaNhanVien(string? id)
        {
            var nv = _db.NhanViens.FirstOrDefault(s => s.MaNhanVien == id);
            _db.NhanViens.Remove(nv);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}

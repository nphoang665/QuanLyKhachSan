﻿using MailKit.Search;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.DataAcess.Data;
using QuanLyKhachSan.Model;
using System.Text.RegularExpressions;

namespace QuanLyKhachSan.Controllers
{
	public class QuanLyPhongController : Controller
	{
		private readonly ApplicationDbContext _db;
		public QuanLyPhongController(ApplicationDbContext db)
		{
			_db = db;
		}
		public async Task<IActionResult> Index(string searchText, string hangPhong, string TrangThai,int page = 1)
		{
            int? numberOfColumnsToShow = null;
            if (Request.Query.ContainsKey("example_length"))
            {
                numberOfColumnsToShow = Convert.ToInt32(Request.Query["example_length"]);
            }
            ViewBag.NumberOfColumnsToShow = numberOfColumnsToShow;
            int pageSize = numberOfColumnsToShow ?? 10;
            int totalKhachHangs = await _db.Phong.CountAsync();
			int totalPages = (int)Math.Ceiling((double)totalKhachHangs / pageSize);
			var phong = _db.Phong.AsQueryable();
            // Lọc kết quả theo giới tính
            if (!String.IsNullOrEmpty(hangPhong))
            {
                phong = phong.Where(kh => kh.HangPhong == hangPhong);
            }
            // Lọc kết quả theo từ khóa tìm kiếm


            if (!String.IsNullOrEmpty(searchText))
            {
                phong = phong.Where(kh => kh.MaPhong.Contains(searchText));
            }
            // Lọc theo trạng thái
            if (!String.IsNullOrEmpty(TrangThai))
            {
                phong = phong.Where(kh => kh.TrangThai == TrangThai);
            }
            var paginatedKhachHangs = await phong
			.OrderBy(kh => kh.MaPhong)
			.Skip((page - 1) * pageSize)
			.Take(pageSize)
			.ToListAsync();
			ViewData["TotalPages"] = totalPages;
			ViewData["CurrentPage"] = page;
			return View(paginatedKhachHangs);
		}
		[HttpGet]
		public IActionResult SuaPhong(string id)
		{
			var maphong = _db.Phong.Find(id);
			return View(maphong);
		}
		public bool ValidateRoom(Room phong)
		{
			// Kiểm tra các trường nhập liệu trống
			if (string.IsNullOrEmpty(phong.MaPhong))
			{
				ModelState.AddModelError("MaPhong", "Mã phòng không được để trống");
				return false;
			}
			if (string.IsNullOrEmpty(phong.KhuVuc))
			{
				ModelState.AddModelError("KhuVuc", "Khu vực không được để trống");
				return false;
			}
			if (string.IsNullOrEmpty(phong.HangPhong))
			{
				ModelState.AddModelError("HangPhong", "Hạng phòng không được để trống");
				return false;
			}
			// Kiểm tra hạng phòng không có số và kí tự đặc biệt
			Regex regexItem = new Regex("^[\\p{L}]*$");
			if (!regexItem.IsMatch(phong.HangPhong))
			{
				ModelState.AddModelError("HangPhong", "Hạng phòng không được chứa số và kí tự đặc biệt");
				return false;
			}

			// Kiểm tra giá không có chữ và kí tự đặc biệt
			regexItem = new Regex("^[0-9]*$");
			if (!regexItem.IsMatch(phong.GiaTheoGio.ToString()) || !regexItem.IsMatch(phong.GiaTheoNgay.ToString()) || !regexItem.IsMatch(phong.GiaTheoQuaDem.ToString()))
			{
				ModelState.AddModelError("Gia", "Giá không được chứa chữ và kí tự đặc biệt");
				return false;
			}

			// Thêm các điều kiện xác thực khác ở đây

			return true;
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult SuaPhong(Room phong)
		{
			if (ValidateRoom(phong))
			{
				_db.Phong.Update(phong);
				_db.SaveChanges();
                TempData["success"] = "Sửa thông tin phòng thành công";
                return RedirectToAction("Index");
			}
			return View(phong);
		}
	}
}

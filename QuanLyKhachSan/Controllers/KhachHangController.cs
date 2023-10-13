﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.DataAcess.Data;
using QuanLyKhachSan.Model;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using NuGet.Protocol;

namespace QuanLyKhachSan.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly ApplicationDbContext _db;
        public KhachHangController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index(string searchText, string gender, string TrangThai, int page = 1)
        {

            int pageSize = 7;
            int totalKhachHangs = await _db.KhachHangs.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalKhachHangs / pageSize);
            var khachHangs = _db.KhachHangs.AsQueryable();

            // Lọc kết quả theo giới tính
            if (!String.IsNullOrEmpty(gender))
            {
                khachHangs = khachHangs.Where(kh => kh.GioiTinh == gender);
            }
            // Lọc kết quả theo từ khóa tìm kiếm


            if (!String.IsNullOrEmpty(searchText))
            {
                khachHangs = khachHangs.Where(kh => kh.TenKhachHang.Contains(searchText));
            }
            // Lọc theo trạng thái
            if (!String.IsNullOrEmpty(TrangThai))
            {
                khachHangs = khachHangs.Where(kh => kh.GhiChu == TrangThai);
            }
            // Phân trang kết quả
            var paginatedKhachHangs = await khachHangs
                .OrderBy(kh => kh.MaKhachHang)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            // Lấy giá trị của radio button
            // Trả về view
            ViewData["TotalPages"] = totalPages;
            ViewData["CurrentPage"] = page;
            ViewData["searchText"] = khachHangs;
            ViewData["gender"] = gender;
            ViewData["TrangThai"] = TrangThai;
            return View(paginatedKhachHangs);

        }




        [HttpGet]
        public IActionResult ThemKhachHang()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemKhachHang(KhachHang model)
        {
            if (ModelState.IsValid)
            {
                _db.KhachHangs.Add(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult SuaKhachHang(string id)
        {
            var nv = _db.KhachHangs.FirstOrDefault(s => s.MaKhachHang == id);
            return View(nv);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaKhachHang(KhachHang model)
        {
            if (ModelState.IsValid)
            {
                _db.KhachHangs.Update(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult XoaKhachHang(string? id)
        {
            var kh = _db.KhachHangs.FirstOrDefault(s => s.MaKhachHang == id);
           if(kh == null)
            {
                return NotFound();
            }
           _db.KhachHangs.Remove(kh);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult XoaKhachHangPartical(string? id)
        {
            var kh = _db.KhachHangs.FirstOrDefault(s => s.MaKhachHang == id);
            if (kh == null)
            {
                return NotFound();
            }
            _db.KhachHangs.Remove(kh);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Search(string searchText)
        {
            var allkhachhang = _db.KhachHangs.ToList();
       
            if (searchText == null)
            {
                return PartialView("_KhachHangPartial", allkhachhang);
            }
            else
            {
                var khachHangs = await _db.KhachHangs
                .Where(kh => kh.TenKhachHang.Contains(searchText.Trim())) // Thay ".TenKhachHang" bằng thuộc tính bạn muốn tìm kiếm
                .ToListAsync();

            return PartialView("_KhachHangPartial", khachHangs); // Trả về một PartialView chứa kết quả tìm kiếm
            }
           
        }

        public ActionResult ExportExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Đặt bản quyền cho EPPlus
            using (ExcelPackage pck = new ExcelPackage())
            {
                // Tạo một worksheet mới
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("KhachHang");

                // Lấy danh sách khách hàng
                var khachhang = _db.KhachHangs.ToList();

                // Tạo một bảng để lưu trữ dữ liệu khách hàng
                System.Data.DataTable dataTable = new System.Data.DataTable();
                dataTable.Columns.Add("Mã khách Hàng");
                dataTable.Columns.Add("Tên khách hàng");
                dataTable.Columns.Add("CCCD");
                dataTable.Columns.Add("Giới tính");
                dataTable.Columns.Add("Ngày sinh");
                dataTable.Columns.Add("Điện thoại");
                dataTable.Columns.Add("Địa chỉ");
                dataTable.Columns.Add("Ghi chú");
                // Thêm dữ liệu khách hàng vào bảng
                foreach (var khach in khachhang)
                {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow[0] = khach.MaKhachHang;
                    dataRow[1] = khach.TenKhachHang;
                    dataRow[2] = khach.DiaChi;
                    dataRow[3] = khach.GioiTinh;
                    dataRow[4] = khach.NgaySinh;
                    dataRow[5] = khach.DienThoai;
                    dataRow[6] = khach.DiaChi;
                    dataRow[7] = khach.GhiChu;

                    dataTable.Rows.Add(dataRow);
                }

                // Thêm dữ liệu từ bảng vào worksheet
                ws.Cells["A1"].LoadFromDataTable(dataTable, true);

                // Gửi file Excel về client
                var stream = new MemoryStream(pck.GetAsByteArray());

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "KhachHang.xlsx");
            }
        }
        public async Task<IActionResult> ExportPDF()
        {
            // Tạo một tài liệu PDF mới
            Document pdfDoc = new Document();
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter.GetInstance(pdfDoc, memoryStream);

            // Lấy danh sách khách hàng
            var khachhang = _db.KhachHangs.ToList();

            pdfDoc.Open();

            // Tạo một bảng để lưu trữ dữ liệu khách hàng
            PdfPTable table = new PdfPTable(8);
            table.SetWidths(new float[] { 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f }); // Chỉnh độ rộng của các cột

            // Thêm tiêu đề cho các cột
            table.AddCell("Mã KH");
            table.AddCell("Tên Khách Hàng");
            table.AddCell("CCCD");
            table.AddCell("Giới Tính");
            table.AddCell("Ngày Sinh");
            table.AddCell("SDT");
            table.AddCell("  Địa chỉ ");
            table.AddCell("Ghi chú");

            foreach (var khach in khachhang)
            {
                table.AddCell(khach.MaKhachHang);
                table.AddCell(khach.TenKhachHang);
                table.AddCell(khach.CCCD);
                table.AddCell(khach.GioiTinh);
                table.AddCell(khach.NgaySinh.ToShortDateString());
                table.AddCell(khach.DienThoai);
                table.AddCell(khach.DiaChi);
                table.AddCell(khach.GhiChu);
            }

            // Thêm bảng vào tài liệu PDF
            pdfDoc.Add(table);

            pdfDoc.Close();

            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();

            return File(bytes, "application/pdf", "KhachHang.pdf");
        }



    }
}

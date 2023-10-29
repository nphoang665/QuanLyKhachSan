using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.DataAcess.Data;
using QuanLyKhachSan.Model;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using NuGet.Protocol;
using System.Text.RegularExpressions;

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

            int? numberOfColumnsToShow = null;
            if (Request.Query.ContainsKey("example_length"))
            {
                numberOfColumnsToShow = Convert.ToInt32(Request.Query["example_length"]);
            }
            ViewBag.NumberOfColumnsToShow = numberOfColumnsToShow;
            int pageSize = numberOfColumnsToShow ?? 10;
            int totalKhachHangs = await _db.KhachHangs.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalKhachHangs / pageSize);
            var khachHangs = _db.KhachHangs.AsQueryable();

         
            // Phân trang kết quả
            var paginatedKhachHangs = await khachHangs
                .OrderBy(kh => kh.MaKhachHang)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
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
            ValidateKhachHang(model);
            if (ModelState.IsValid)
            {
                DateTime ngayhientai = DateTime.Now;
                model.NgayTao = ngayhientai;
                _db.KhachHangs.Add(model);
                _db.SaveChanges();
                TempData["success"] = "Thêm Khách Hàng Thành Công";
                return RedirectToAction("Index");
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult SuaKhachHang(string id)
        {
            var kh = _db.KhachHangs.FirstOrDefault(s => s.MaKhachHang == id);
            return View(kh);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaKhachHang(KhachHang model)
        {
            ValidateKhachHang(model);
            if (ModelState.IsValid)
            {
                _db.KhachHangs.Update(model);
                _db.SaveChanges();
                TempData["success"] = "Sửa Khách Hàng Thành Công";
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
            TempData["success"] = "Xóa Khách Hàng Thành Công";
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

        private void ValidateKhachHang(KhachHang kh)
        {
            //validate Ma khach hàng
            if (string.IsNullOrEmpty(kh.MaKhachHang))
            {
                ModelState.AddModelError("MaKhachHang", "Mã khách hàng không được bỏ trống");
            }
            else if (kh.MaKhachHang.Length != 6)
            {
                ModelState.AddModelError("MaKhachHang", "Mã khách hàng phải đạt 6 ký tự");
            }
            else if (!Regex.IsMatch(kh.MaKhachHang, "^[a-zA-Z0-9]*$"))
            {
                ModelState.AddModelError("MaKhachHang", "Mã khách hàng chỉ được chứa chữ và số.");
            }
            // validate tenkhachhang
            if (string.IsNullOrEmpty(kh.TenKhachHang))
            {
                ModelState.AddModelError("TenKhachHang", "Tên khách hàng không được bỏ trống");
            }
            else if (kh.TenKhachHang.Length > 50 || kh.TenKhachHang.Length < 3)
            {
                ModelState.AddModelError("TenKhachHang", "Tên khách hàng không được quá dài hoặc quá ngắn.");
            }
            else if (!Regex.IsMatch(kh.TenKhachHang, "^[\\p{L}\\s]*$"))
            {
                ModelState.AddModelError("TenKhachHang", "Tên khách hàng chỉ được chứa chữ cái và không được chứa số.");
            }
            //validate CCCD
            if (kh.CCCD == null)
            {
                ModelState.AddModelError("CCCD", "Căn cước công dân không được bỏ trống");

            }
            else if (kh.CCCD.Length != 12)
            {
                ModelState.AddModelError("CCCD", "Căn cước công dân phải đủ 12 số.");
            }
            else if (!kh.CCCD.Any(char.IsDigit))
            {
                ModelState.AddModelError("CCCD", "Căn cước công dân phải là số.");
            }
            //validate ngaySinh
            DateTime ngayHienTai = DateTime.Now;
            TimeSpan timeSpan = ngayHienTai - kh.NgaySinh;
            if (timeSpan.TotalDays < 5340)
            {
                ModelState.AddModelError("NgaySinh", "Khách hàng phải đủ 15 tuổi trở lên.");
            }
            //validate dienthoai
            if (kh.DienThoai == null)
            {
                ModelState.AddModelError("DienThoai", "Số điện thoại không được bỏ trống.");

            }
            else if (!kh.DienThoai.Any(char.IsDigit))
            {
                ModelState.AddModelError("DienThoai", "Số điện thoại phải là số (không chứa chữ và kí tự đặc việt).");
            }
            else if (kh.DienThoai.Length != 10)
            {
                ModelState.AddModelError("DienThoai", "Số điện thoại có 10 kí tự.");
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

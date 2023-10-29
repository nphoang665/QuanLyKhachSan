using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using QuanLyKhachSan.DataAcess.Data;
using QuanLyKhachSan.Model;
using System.Data;
using System.Text.RegularExpressions;

namespace QuanLyKhachSan.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly ApplicationDbContext _db;
        public NhanVienController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index(string searchText, string gender, string ChucVu, int page = 1)
        {
            int? numberOfColumnsToShow = null;
            if (Request.Query.ContainsKey("example_length"))
            {
                numberOfColumnsToShow = Convert.ToInt32(Request.Query["example_length"]);
            }
            ViewBag.NumberOfColumnsToShow = numberOfColumnsToShow;
            int pageSize = numberOfColumnsToShow ?? 10;
            int totalKhachHangs = await _db.NhanViens.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalKhachHangs / pageSize);

            // Lọc kết quả theo từ khóa tìm kiếm

            var khachHangs = _db.NhanViens.AsQueryable();
            // Lọc kết quả theo giới tính
            if (!String.IsNullOrEmpty(gender))
            {
                khachHangs = khachHangs.Where(kh => kh.GioiTinh == gender);
            }
            if (!String.IsNullOrEmpty(searchText))
            {
                khachHangs = khachHangs.Where(kh => kh.TenNhanVien.Contains(searchText));
            }

            // Lọc theo chức vụ
            if (!String.IsNullOrEmpty(ChucVu))
            {
                khachHangs = khachHangs.Where(kh => kh.ChucVu.Contains(ChucVu));
            }

            // Phân trang kết quả
            var paginatedKhachHangs = await khachHangs
                .OrderBy(kh => kh.MaNhanVien)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Trả về view
            ViewData["TotalPages"] = totalPages;
            ViewData["CurrentPage"] = page;
            ViewData["searchText"] = khachHangs;
            return View(paginatedKhachHangs);
        }


        // Trong Controller của bạn
        [HttpGet]
        public IActionResult ThemNhanVien()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemNhanVien(NhanVien model)
        {
            ValidateNhanVien(model);
			// Check for duplicate MaNhanVien
			if (_db.NhanViens.Any(nv => nv.MaNhanVien == model.MaNhanVien))
			{
				ModelState.AddModelError("MaNhanVien", "Mã nhân viên đã tồn tại.");
			}

			// Check for duplicate DienThoai
			if (_db.NhanViens.Any(nv => nv.DienThoai == model.DienThoai))
			{
				ModelState.AddModelError("DienThoai", "Số điện thoại đã tồn tại.");
			}

			// Check for duplicate CCCD
			if (_db.NhanViens.Any(nv => nv.CCCD == model.CCCD))
			{
				ModelState.AddModelError("CCCD", "CCCD đã tồn tại.");
			}

			// Check for duplicate Email
			if (_db.NhanViens.Any(nv => nv.Email == model.Email))
			{
				ModelState.AddModelError("Email", "Email đã tồn tại.");
			}
			if (ModelState.IsValid)
            {
                TempData["success"] = "Thêm Nhân Viên Thành Công";
                _db.NhanViens.Add(model);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(model);

        }

        [HttpGet]
        public IActionResult SuaNhanVien(string id)
        {
            var nv = _db.NhanViens.FirstOrDefault(s => s.MaNhanVien == id);
            return View(nv);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaNhanVien(NhanVien model)
        {
            ValidateNhanVien(model);
			if (_db.NhanViens.Any(nv => nv.CCCD == model.CCCD && nv.MaNhanVien != model.MaNhanVien))
			{
				ModelState.AddModelError("CCCD", "CCCD đã tồn tại.");
			}

			// Check for duplicate DienThoai
			if (_db.NhanViens.Any(nv => nv.DienThoai == model.DienThoai && nv.MaNhanVien != model.MaNhanVien))
			{
				ModelState.AddModelError("DienThoai", "Số điện thoại đã tồn tại.");
			}

			// Check for duplicate Email
			if (_db.NhanViens.Any(nv => nv.Email == model.Email && nv.MaNhanVien != model.MaNhanVien))
			{
				ModelState.AddModelError("Email", "Email đã tồn tại.");
			}
			if (ModelState.IsValid)
            {
                
                _db.NhanViens.Update(model);
                _db.SaveChanges();
                TempData["success"] = "Sửa Nhân Viên Thành Công";
                return RedirectToAction("Index");
            }
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult XoaNhanVien(string? id)
        {
            var nv = _db.NhanViens.FirstOrDefault(s => s.MaNhanVien == id);
            _db.NhanViens.Remove(nv);
            _db.SaveChanges();
            TempData["success"] = "Xóa Nhân Viên Thành Công";
            return RedirectToAction("Index");
        }
        private void ValidateNhanVien(NhanVien nv)
        {
            //validate Employee Id
            if (nv.MaNhanVien == null)
            {
                ModelState.AddModelError("MaNhanVien", "Mã nhân viên không được bỏ trống");

            }
            else if (nv.MaNhanVien.Length != 6)
            {
                ModelState.AddModelError("MaNhanVien", "Mã nhân viên phải đạt 6 ký tự");
            }
            else if (!Regex.IsMatch(nv.MaNhanVien, "^[a-zA-Z0-9]*$"))
            {
                ModelState.AddModelError("MaNhanVien", "Mã nhân viên chỉ được chứa chữ và số.");
            }

            //validate Name Employee
            if (nv.TenNhanVien == null)
            {
                ModelState.AddModelError("TenNhanVien", "Tên nhân viên không được bỏ trống.");

            }
            else if (nv.TenNhanVien.Length > 50 || nv.TenNhanVien.Length < 3)
            {
                ModelState.AddModelError("TenNhanVien", "Tên nhân viên không được quá dài hoặc quá ngắn.");
            }
            else if (!Regex.IsMatch(nv.TenNhanVien, "^[\\p{L}\\s]*$"))
            {
                ModelState.AddModelError("TenNhanVien", "Tên nhân viên chỉ được chứa chữ cái và không được chứa số.");
            }
            //validate CCCD
            if (nv.CCCD == null)
            {
                ModelState.AddModelError("CCCD", "Căn cước công dân không được bỏ trống");

            }
            else if (nv.CCCD.Length != 12)
            {
                ModelState.AddModelError("CCCD", "Căn cước công dân phải đủ 12 số.");
            }
            else if (!nv.CCCD.Any(char.IsDigit))
            {
                ModelState.AddModelError("CCCD", "Căn cước công dân phải là số.");
            }
            //validate chucvu
            if (nv.ChucVu == null)
            {
                ModelState.AddModelError("ChucVu", "Chức vụ không được bỏ trống.");

            }
            else if (nv.ChucVu.Any(char.IsDigit))
            {
                ModelState.AddModelError("ChucVu", "Chức vụ không chứa số.");
            }//validate SoDienThoai
            if (nv.DienThoai == null)
            {
                ModelState.AddModelError("DienThoai", "Số điện thoại không được bỏ trống.");

            }
            else if (!nv.DienThoai.Any(char.IsDigit))
            {
                ModelState.AddModelError("DienThoai", "Số điện thoại phải là số (không chứa chữ và kí tự đặc việt).");
            }
            else if (nv.DienThoai.Length != 10)
            {
                ModelState.AddModelError("DienThoai", "Số điện thoại có 10 kí tự.");
            }
            DateTime ngayHienTai = DateTime.Now;
            TimeSpan timeSpan = ngayHienTai - nv.NgaySinh;
            if (timeSpan.TotalDays < 6570)
            {
                ModelState.AddModelError("NgaySinh", "Nhân viên phải đủ 18 tuổi.");
            }
            TimeSpan tinhNgayVaoLam = nv.NgayVaoLam - ngayHienTai;
            if (tinhNgayVaoLam.TotalDays > 0)
            {
                ModelState.AddModelError("NgayVaoLam", "Ngày vào làm không được quá ngày hôm nay.");
            }
        }
        public ActionResult ExportExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Đặt bản quyền cho EPPlus
            using (ExcelPackage pck = new ExcelPackage())
            {
                // Tạo một worksheet mới
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("NhanVien");

                // Lấy danh sách 
                var nhanvien = _db.NhanViens.ToList();

                // Tạo một bảng để lưu trữ dữ liệu 
                System.Data.DataTable dataTable = new System.Data.DataTable();
                dataTable.Columns.Add("Mã Nhân Viên");
                dataTable.Columns.Add("Tên Nhân Viên");
                dataTable.Columns.Add("CCCD");
                dataTable.Columns.Add("Giới tính");
                dataTable.Columns.Add("Ngày sinh");
                dataTable.Columns.Add("Điện thoại");
                dataTable.Columns.Add("Địa chỉ");
                dataTable.Columns.Add("Chức Vụ");
                dataTable.Columns.Add("Ngày Vào Làm");
                dataTable.Columns.Add("Ghi chú");
                // Thêm dữ liệu  vào bảng
                foreach (var nv in nhanvien)
                {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow[0] = nv.MaNhanVien;
                    dataRow[1] = nv.TenNhanVien;
                    dataRow[2] = nv.CCCD;
                    dataRow[3] = nv.GioiTinh;
                    dataRow[4] = nv.NgaySinh.ToShortDateString();
                    dataRow[5] = nv.DienThoai;
                    dataRow[6] = nv.DiaChi;
                    dataRow[7] = nv.ChucVu;
                    dataRow[8] = nv.NgayVaoLam.ToShortDateString();
                    dataRow[9] = nv.GhiChu;

                    dataTable.Rows.Add(dataRow);
                }

                // Thêm dữ liệu từ bảng vào worksheet
                ws.Cells["A1"].LoadFromDataTable(dataTable, true);

                // Gửi file Excel về client
                var stream = new MemoryStream(pck.GetAsByteArray());

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "NhanVien.xlsx");
            }
        }
        public async Task<IActionResult> ExportPDF()
        {
            // Tạo một tài liệu PDF mới
            Document pdfDoc = new Document();
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter.GetInstance(pdfDoc, memoryStream);

            // Lấy danh sách nhân viên
            var nhanvien = _db.NhanViens.ToList();

            pdfDoc.Open();

            // Tạo một bảng để lưu trữ dữ liệu khách hàng
            PdfPTable table = new PdfPTable(10);
            table.SetWidths(new float[] { 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f }); // Chỉnh độ rộng của các cột

            // Thêm tiêu đề cho các cột
            table.AddCell("Mã Nhân Viên");
            table.AddCell("Tên Nhân Viên");
            table.AddCell("CCCD");
            table.AddCell("Giới tính");
            table.AddCell("Ngày sinh");
            table.AddCell("Điện thoại");
            table.AddCell("Địa chỉ");
            table.AddCell("Chức Vụ");
            table.AddCell("Ngày Vào Làm");
            table.AddCell("Ghi chú");

            foreach (var nv in nhanvien)
            {
                table.AddCell(nv.MaNhanVien);
                table.AddCell(nv.TenNhanVien);
                table.AddCell(nv.CCCD);
                table.AddCell(nv.GioiTinh);
                table.AddCell(nv.NgaySinh.ToShortDateString());
                table.AddCell(nv.DienThoai);
                table.AddCell(nv.DiaChi);
                table.AddCell(nv.ChucVu);
                table.AddCell(nv.NgayVaoLam.ToShortDateString());
                table.AddCell(nv.GhiChu);
            }

            // Thêm bảng vào tài liệu PDF
            pdfDoc.Add(table);

            pdfDoc.Close();

            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();

            return File(bytes, "application/pdf", "NhanVien.pdf");
        }
    }
}

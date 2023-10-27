
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.DataAcess.Data;

namespace QuanLyKhachSan.Controllers
{
    public class TongQuanController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TongQuanController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()

        {
           
            return View();
        }
        [HttpPost]
        public IActionResult LayTinhTrangPhong()
        {
            var phongDaDat = _db.DatPhongs.Select(x => x.MaPhong).Count();
            var soluongphong = _db.Phong.Select(s => s.MaPhong).Count();
            var PhongTrong = soluongphong-phongDaDat;

            // Trả về dữ liệu dưới dạng JSON
            return Json(new { PhongTrong = PhongTrong, phongDaDat = phongDaDat });
        }

        public IActionResult LayDoanhThuTheoThang()
        {
            // Khởi tạo mảng với 12 phần tử tương ứng với 12 tháng
            var doanhThuTheoThang = new decimal[12];

            // Lấy dữ liệu từ cơ sở dữ liệu
            var duLieuTuDb = _db.HoaDon
                .GroupBy(hd => new { hd.NgayTra.Year, hd.NgayTra.Month })
                .Select(g => new
                {
                    Thang = g.Key.Month,
                    Nam = g.Key.Year,
                    DoanhThu = (decimal)g.Sum(hd => hd.ThanhTien)
                })
                .ToList();

            // Cập nhật giá trị cho các tháng có dữ liệu
            foreach (var item in duLieuTuDb)
            {
                // Lưu ý rằng chỉ số của mảng bắt đầu từ 0
                doanhThuTheoThang[item.Thang -1] = item.DoanhThu;
            }

            return Json(doanhThuTheoThang);
        }


    }
}

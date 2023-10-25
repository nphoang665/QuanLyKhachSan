using Microsoft.AspNetCore.Mvc;
using QuanLyKhachSan.DataAcess.Data;

namespace QuanLyKhachSan.Controllers
{
	public class HoSoController : Controller
	{
        private readonly ApplicationDbContext _db;
        public HoSoController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string id)
        {
            var employee = _db.NhanViens.FirstOrDefault(s => s.MaNhanVien == id);
            if (employee != null)
            {
                return View(employee); // Truyền dữ liệu vào view
            }
            else
            {
                return NotFound(); // Trả về lỗi nếu không tìm thấy nhân viên
            }
        }

    }
}

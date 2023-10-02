using Microsoft.AspNetCore.Mvc;
using QuanLyKhachSan.DataAcess.Data;

namespace QuanLyKhachSan.Controllers
{
	public class QuanLyPhongController : Controller
	{
		private readonly ApplicationDbContext _db;
        public QuanLyPhongController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
		{
			var phong =_db.Phong.ToList();
			return View(phong);
		}
	}
}

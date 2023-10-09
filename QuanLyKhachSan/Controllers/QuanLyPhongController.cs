using Microsoft.AspNetCore.Mvc;
using QuanLyKhachSan.DataAcess.Data;
using QuanLyKhachSan.Model;

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
		[HttpGet]
		public IActionResult SuaPhong(string id)
		{
			var maphong = _db.Phong.Find(id);
			return View(maphong);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult SuaPhong(Room phong)
		{
			if (ModelState.IsValid)
			{
				_db.Phong.Update(phong);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(phong);
		}
	}
}

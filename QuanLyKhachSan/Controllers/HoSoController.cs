using Microsoft.AspNetCore.Mvc;

namespace QuanLyKhachSan.Controllers
{
	public class HoSoController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

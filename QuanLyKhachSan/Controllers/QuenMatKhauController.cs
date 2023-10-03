using Microsoft.AspNetCore.Mvc;

using System.Net;
using System.Net.Mail;

namespace QuanLyKhachSan.Controllers
{
    public class QuenMatKhauController : Controller
    {
    
    
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> GuiMail(string Email, string ConfirmId)
        //{
          
        //}
    }
}

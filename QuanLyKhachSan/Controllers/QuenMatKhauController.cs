using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuanLyKhachSan.DataAcess.Data;
using System.Net;
using System.Net.Mail;

namespace QuanLyKhachSan.Controllers
{
    public class QuenMatKhauController : Controller
    {
        private readonly ApplicationDbContext _db;
        public QuenMatKhauController(ApplicationDbContext db)
        {
            _db= db;
        }
        public static string MaXacNhan;
        public static string Gmail;
        public IActionResult Index()
        {
            return View();
        } 
        [HttpPost]
       
        public async Task<IActionResult> GuiMail(string Email)
        {
            Gmail = Email;
            Random rnd = new Random();
            MaXacNhan = rnd.Next().ToString();
            string from, to, pass, content;
            from = "khachsanasap@gmail.com";
            to = Email;
            pass = "ulwg gvjl vqmb iwya";
            content = MaXacNhan;

            // Create a new SmtpClient object.
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            // Create a new MailMessage object.
            MailMessage mail = new MailMessage();
            mail.To.Add(to);
            mail.From = new MailAddress(from);
            mail.Subject = "Test";
            mail.Body = content;

            // Send the email.
            await smtp.SendMailAsync(mail);

            // Return a success response.
            return Json(new { success = true, message = "Email đã được gửi thành công!" });
        }
        [HttpPost]
        public IActionResult XacNhanMa(string ConfirmId)
        {
            if (ConfirmId== MaXacNhan)
            {
                return Json(new { success = true, message = "Mã xác nhận hợp lệ!" });
            }
            else
            {
                return Json(new { success = false, message = "Mã xác nhận không hợp lệ!" });

            }
        }
        [HttpPost]
        public IActionResult DoiMatKhau(string NewPassword)
        {
            var tk = _db.TaiKhoan.FirstOrDefault(s => s.Email == Gmail);
            if (tk != null)
            {
                tk.MatKhau = NewPassword;
                _db.SaveChanges();          
                return Json(new { success = true, message = "Mật khẩu đã được đặt lại thành công!" });

            }
            else
            {
                return Json(new { success = false, message = "Mật khẩu đã được đặt lại không thành công!" });

            }
        }
    }
}
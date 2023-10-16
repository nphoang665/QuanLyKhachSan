using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Macs;
using QuanLyKhachSan.DataAcess.Data;
using QuanLyKhachSan.Model;
using System.Linq;
using System.Net.Mail;
using System.Net;

namespace QuanLyKhachSan.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _db;
        public LoginController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(TaiKhoan obj)
        {
            var account = _db.TaiKhoan.FirstOrDefault(s => s.TenDangNhap == obj.TenDangNhap && s.MatKhau == obj.MatKhau);
            if (account == null)
            {
                // Tài khoản hoặc mật khẩu không chính xác
                TempData["Error"] = "Đăng nhập không thành công do sai tài khoản hoặc mật khẩu";
                return View();
            }
            else
            {
                // Đăng nhập thành công, chuyển hướng đến trang chủ
                return RedirectToAction("Index", "TongQuan");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DangKy(TaiKhoan tk)
        {
            if (ModelState.IsValid)
            {

                _db.TaiKhoan.Add(tk);
                _db.SaveChanges();
                TempData["notification"] = "Đăng ký thành công.";
            }
            return RedirectToAction("Index", "Login");
        

        }
        public static string MaXacNhan;
        public static string Gmail;

        [HttpPost]
        public async Task<IActionResult> GuiMail(string Email)
        {
            Gmail = Email;
            Random rnd = new Random();
            MaXacNhan = rnd.Next().ToString();

            // Tạo mới một đối tượng SmtpClient.
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential("khachsanasap@gmail.com", "ulwg gvjl vqmb iwya");

            // Tạo mới một đối tượng MailMessage.
            MailMessage mail = new MailMessage();
            mail.To.Add(Email);
            mail.From = new MailAddress("khachsanasap@gmail.com");
            mail.Subject = "Test";
            mail.Body = MaXacNhan;

            // Gửi email.
            await smtp.SendMailAsync(mail);

            // Trả về một phản hồi thành công.
            return Json(new { success = true, confirmationCode = MaXacNhan, responseText = "Email đã được gửi thành công!" });
        }




        [HttpPost]
        public async Task<IActionResult> LuuMatKhau(string MatKhau)
        {
            // Giả định rằng bạn đã lưu email của người dùng vào session khi họ yêu cầu đặt lại mật khẩu
           

            // Tìm tài khoản với email đã cho
            var account = _db.TaiKhoan.FirstOrDefault(a => a.Email == Gmail);
            if (account == null)
            {
                return Json(new { success = false, responseText = "Không tìm thấy tài khoản với email đã cho." });
            }

            // Cập nhật mật khẩu
            account.MatKhau = MatKhau; // Bạn nên mã hóa mật khẩu trước khi lưu nó vào cơ sở dữ liệu

            // Lưu thay đổi vào cơ sở dữ liệu
            _db.TaiKhoan.Update(account);
            await _db.SaveChangesAsync();


            return Json(new { success = true, responseText = "Mật khẩu đã được cập nhật thành công!" });
        }
    }
}

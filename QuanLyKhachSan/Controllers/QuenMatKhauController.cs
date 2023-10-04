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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GuiMail(string Email, string ConfirmId)
        {
            try
            {
                // Tạo một mã xác nhận ngẫu nhiên (có thể sử dụng thư viện mã xác nhận chuyên dụng cho tính bảo mật cao hơn).
                string maXacNhan = Guid.NewGuid().ToString("N").Substring(0, 6);

                // Gửi email xác nhận đến địa chỉ email của người dùng.
                using (var client = new SmtpClient("smtp.gmail.com"))
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("sos21832cc1@gmail.com", "qzxccvbnm");
                    client.Port = 587; // Sử dụng cổng 587 cho TLS.
                    client.EnableSsl = true;

                    var message = new MailMessage
                    {
                        Subject = "Xác nhận mật khẩu",
                        Body = $"Mã xác nhận của bạn là: {maXacNhan}",
                        From = new MailAddress("sos21832cc1@gmail.com"),
                    };

                    message.To.Add(Email);

                    client.Send(message);
                }

                // Ở đây, bạn có thể lưu mã xác nhận vào cơ sở dữ liệu hoặc làm bất kỳ điều gì khác với nó.

                return RedirectToAction("Index", "QuenMatKhau"); // Chuyển đến trang xác nhận email.
            }
            catch (Exception ex)
            {
                return View("Loi");
            }
        }

    }
}

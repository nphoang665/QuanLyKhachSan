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
			string from, to, pass, content;
			from = "khachsanasap@gmail.com";
			to = Email;
			pass = "ulwg gvjl vqmb iwya";
			content = ConfirmId;

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
			return RedirectToAction("Index", "QuenMatKhau");
		}

    }
}

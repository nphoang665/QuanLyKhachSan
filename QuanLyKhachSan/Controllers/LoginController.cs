﻿using Facebook;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using QuanLyKhachSan.DataAcess.Data;
using QuanLyKhachSan.Model;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

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
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = "645775411083495",
                redirect_uri = "https://localhost:7284/Login/FacebookRedirect",
                scope = "public_profile,email"
            });
            ViewBag.Url = loginUrl;
            return View();
        }
        public IActionResult FacebookRedirect(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Get("/oauth/access_token", new
            {
                client_id = "645775411083495",
                client_secret = "65ca299968f6279165596be550ab39fc",
                redirect_uri = "https://localhost:7284/Login/FacebookRedirect",
                code = code
            });
            fb.AccessToken = result.access_token;

            dynamic me = fb.Get("/me?fields=name,email");
            string name = me.Name;
            string email = me.Email;
            return RedirectToAction("Index", "TongQuan");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(TaiKhoan obj)
        {
            if (obj.TenDangNhap == null)
            {
                TempData["ErrorTenDangNhap"] = "Bạn chưa nhập tên đăng nhập";
            }
            if (obj.MatKhau == null)
            {
                TempData["ErrorMatKhau"] = "Bạn chưa nhập mật khẩu";
            }
            var account = _db.TaiKhoan.FirstOrDefault(s => s.TenDangNhap == obj.TenDangNhap && s.MatKhau == obj.MatKhau);
            if (account == null)
            {
                TempData["ErrorMatKhau"] = "Sai mật khẩu. Mời bạn nhập lại";
                return View();
            }
            else
            {

                var _QrEmail = _db.TaiKhoan.FirstOrDefault(s => s.TenDangNhap == obj.TenDangNhap);
                TempData["Email"] = _QrEmail.Email;
                string email = TempData.Peek("Email") as string; // Sử dụng Peek thay vì lấy giá trị
                var qr_TenNhanVien = _db.NhanViens.FirstOrDefault(s => s.Email == email);

                // Tạo cookie
                var cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddDays(30); // Đặt thời hạn cho cookie
                HttpContext.Response.Cookies.Append("TenNhanVien", qr_TenNhanVien.TenNhanVien, cookieOptions);
                HttpContext.Response.Cookies.Append("MaNv", qr_TenNhanVien.MaNhanVien, cookieOptions);
                HttpContext.Response.Cookies.Append("Username", obj.TenDangNhap, cookieOptions);
                HttpContext.Response.Cookies.Append("ChucVu", qr_TenNhanVien.ChucVu, cookieOptions);
                // Đăng nhập thành công, chuyển hướng đến trang chủ
                return RedirectToAction("Index", "TongQuan");
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DangKy(TaiKhoan tk)
        {
            Regex regexItem = new Regex("^[a-zA-Z0-9]*$");
            //kiểm tra tên đăng nhập có tồn tại trong hệ thống chưa
            var existTenDangNhap = _db.TaiKhoan.FirstOrDefault(s => s.TenDangNhap == tk.TenDangNhap);

            //kiểm tra tên đăng nhập rỗng
            if (tk.TenDangNhap == null)
            {
                return Json(new { success = false, field = "TenDangNhap", message = "Vui lòng điền tên đăng nhập." });
            }
            //kiểm tra độ dài tên đăng nhập
            else if (tk.TenDangNhap.Length < 4 || tk.TenDangNhap.Length > 25)
            {
                return Json(new { success = false, field = "TenDangNhap", message = "Lỗi. Tên đăng nhập phải từ 4 đến 25 kí tự" });
            }

            //kiểm tra tên đăng nhập không có dấu và kí tự đặc biệt
            else if (!regexItem.IsMatch(tk.TenDangNhap))
            {
                return Json(new { success = false, field = "TenDangNhap", message = "Lỗi. Tên đăng nhập không chứa dấu và kí tự đặt biệt" });
            }
            //kiểm tra tên đăng nhập có tồn tại trong hệ thống chưa
            else if (existTenDangNhap != null)
            {
                return Json(new { success = false, field = "TenDangNhap", message = "Lỗi. Tên đăng nhập đã tồn tại trong hệ thống" });

            }


            //kiểm tra email có tồn tại trong hệ thống chưa
            var existEmail = _db.TaiKhoan.FirstOrDefault(s => s.Email == tk.Email);
            //kiểm tra email rỗng
            if (tk.Email == null)
            {
                return Json(new { success = false, field = "Email", message = "Vui lòng điền email." });
            }
            //kiểm tra email có tồn tại trong hệ thống chưa
            else if (existEmail != null)
            {
                return Json(new { success = false, field = "Email", message = "Lỗi. Email đã tồn tại trong hệ thống." });
            }


            //kiểm tra mật khẩu rỗng
            if (tk.MatKhau == null)
            {
                return Json(new { success = false, field = "MatKhau", message = "Vui lòng điền mật khẩu." });
            }
            //kiểm tra độ dài của mật khẩu
            else if (tk.MatKhau.Length < 4 || tk.MatKhau.Length > 25)
            {
                return Json(new { success = false, field = "MatKhau", message = "Lỗi. Độ dài mật khẩu từ 4 đến 25 kí tự." });

            }
            //kiểm tra mật khẩu không chứa số và kí tự đặc biệt
            else if (!regexItem.IsMatch(tk.MatKhau))
            {
                return Json(new { success = false, field = "MatKhau", message = "Lỗi. Mật khẩu không chứa dấu hoặc kí tự đặc biệt." });
            }
            if (ModelState.IsValid)
            {
                DateTime ngayHienTai =DateTime.Now;
                var taikhoan = new TaiKhoan();
                taikhoan.TenDangNhap = tk.TenDangNhap;
                taikhoan.MatKhau = tk.MatKhau;
                taikhoan.Email = tk.Email;
                taikhoan.NgayTao = ngayHienTai;
                _db.TaiKhoan.Add(taikhoan);
                _db.SaveChanges();
                return Json(new { success = true, message = "Đăng ký thành công." });
            }
            else
            {
                return Json(new { success = false, message = "Có lỗi xảy ra, vui lòng thử lại." });
            }
        }


        public static string MaXacNhan;
        public static string Gmail;

        [HttpPost]
        public async Task<IActionResult> GuiMail(string Email)
        {
            var existEmail = _db.TaiKhoan.FirstOrDefault(s => s.Email == Email);
            if (Email == null)
            {
                return Json(new { success = false, field = "EmailForgotPassword", message = "Email không được bỏ trống." });

            }
            else if (existEmail == null)
            {
                return Json(new { success = false, field = "EmailForgotPassword", message = "Lỗi. Hệ thống không tồn tại email này." });

            }

            if (ModelState.IsValid)
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
            else
            {
                return Json(new { success = false, message = "Có lỗi xảy ra, vui lòng thử lại." });
            }
        }




        [HttpPost]
        public async Task<IActionResult> LuuMatKhau(string MatKhau)
        {
            Regex regexItem = new Regex("^[a-zA-Z0-9]*$");

            // Giả định rằng bạn đã lưu email của người dùng vào session khi họ yêu cầu đặt lại mật khẩu
            if (MatKhau == null)
            {
                return Json(new { success = false, field = "matKhauForgotPassword", message = "Bạn chưa nhập mật khẩu." });

            }
            else if (!regexItem.IsMatch(MatKhau))
            {
                return Json(new { success = false, field = "matKhauForgotPassword", message = "Lỗi. Mật khẩu không chứa dấu hoặc kí tự đặc biệt." });

            }
            else if (MatKhau.Length < 4 || MatKhau.Length > 25)
            {
                return Json(new { success = false, field = "matKhauForgotPassword", message = "Lỗi. Mật khẩu phải lớn hơn 4 và nhỏ hơn 25 kí tự." });

            }
             if (ModelState.IsValid)
            {
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
            else
            {
                return Json(new { success = false, responseText = "Có lỗi xảy ra, vui lòng thử lại." });
            }
        }
    }
}

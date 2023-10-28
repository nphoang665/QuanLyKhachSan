using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanLyKhachSan.Model
{
    public class TaiKhoan
    {
        [Key]
        public string TenDangNhap { get; set; }
        [Required]
        public string MatKhau { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime NgayTao { get; set; }
     }
}

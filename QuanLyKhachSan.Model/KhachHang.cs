using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Model
{
    public  class KhachHang

    {
        [Key]
        public string MaKhachHang { get; set; }
        [Required]
        public string TenKhachHang { get; set; }
        public string GioiTinh { get; set; }

        public DateTime NgaySinh { get; set; }

        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public string GhiChu { get; set; }
     
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Model
{
    public class DatPhong
    {
        [Key]
        public string MaDatPhong { get; set; }
		public string Phong { get; set; }
		public string HangPhong { get; set; }

        public string MaKhachHang { get; set; }
  
        public string HinhThuc { get; set; }
        public double GiaPhong { get; set; }
        public DateTime NgayNhan { get; set; }
        public DateTime NgayTra { get; set; }
        public string DuKien { get; set; }
        public double ThanhTien { get; set; }

    }
}

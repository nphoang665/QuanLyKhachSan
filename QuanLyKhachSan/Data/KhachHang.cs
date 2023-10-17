using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Model
{
    public class KhachHang

    {
        [Key]
        [DisplayName("Mã Khách Hàng")]
        public string MaKhachHang { get; set; }
        [DisplayName("Tên Khách Hàng")]
        public string TenKhachHang { get; set; }
        [DisplayName("CCCD")]
        public string CCCD { get; set; }
        [DisplayName("Giới Tính")]
        public string GioiTinh { get; set; }
        [DisplayName("Ngày Sinh")]
        public DateTime NgaySinh { get; set; }
        [DisplayName("Số Điện Thoại")]
        public string DienThoai { get; set; }
        [DisplayName("Địa Chỉ")]
        public string DiaChi { get; set; }
        [DisplayName("Ghi Chú")]
        public string GhiChu { get; set; }
    }
}

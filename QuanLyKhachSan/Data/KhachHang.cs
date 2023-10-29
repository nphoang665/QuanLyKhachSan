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
        [DisplayName("Mã khách kàng")]
        [Required(ErrorMessage = "Mã khách hàng không được để trống.")]
        public string MaKhachHang { get; set; }
        [DisplayName("Tên khách hàng")]
        [Required(ErrorMessage = "Tên khách hàng không được để trống.")]
        public string TenKhachHang { get; set; }
        [DisplayName("CCCD")]
        [Required(ErrorMessage = "CCCD không được để trống.")]
        public string CCCD { get; set; }
        [DisplayName("Giới tính")]
        public string GioiTinh { get; set; }
        [DisplayName("Ngày sinh")]
        [Required(ErrorMessage = "Ngày sinh không được để trống.")]
        public DateTime NgaySinh { get; set; }
        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được để trống.")]
        public string DienThoai { get; set; }
        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được để trống.")]
        public string DiaChi { get; set; }
        [DisplayName("Ngày tạo")]
        public DateTime NgayTao { get; set; }
        [DisplayName("Ghi chú")]
        public string? GhiChu { get; set; }
    }
}

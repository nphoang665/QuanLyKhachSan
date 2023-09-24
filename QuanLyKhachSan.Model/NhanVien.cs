using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Model
{
    public class NhanVien
    {
        [Key]
        [DisplayName("Mã Nhân Viên")]
        public string MaNhanVien { get; set; }
        [Required]
        [DisplayName("Tên Nhân Viên")]
        public string TenNhanVien { get; set; }
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

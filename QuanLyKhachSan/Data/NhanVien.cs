using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
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

        [DisplayName("CCCD")]
        public string CCCD { get; set; }

        [DisplayName("Giới Tính")]
        public string GioiTinh { get; set; }

        [DisplayName("Ngày Sinh")]
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }

        [DisplayName("Chức Vụ")]
        public string ChucVu { get; set; }

        [DisplayName("Số Điện Thoại")]
        public string DienThoai { get; set; }

        [DisplayName("Địa Chỉ")]
        public string DiaChi { get; set; }

        [DisplayName("Ngày Vào Làm")]
        [DataType(DataType.Date)]
        public DateTime NgayVaoLam { get; set; }

        [DisplayName("Ghi Chú")]
        public string GhiChu { get; set; }
    }

}

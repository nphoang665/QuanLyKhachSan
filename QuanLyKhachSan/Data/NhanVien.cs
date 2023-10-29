using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuanLyKhachSan.Model
{
    public class NhanVien
    {
        [Key]
        [DisplayName("Mã nhân viên")]
        [Required(ErrorMessage = "Mã nhân viên không được để trống.")]
        public string MaNhanVien { get; set; }

        [DisplayName("Tên nhân viên")]
        [Required(ErrorMessage = "Tên nhân viên không được để trống.")]
        public string TenNhanVien { get; set; }

        [DisplayName("CCCD")]
        [Required(ErrorMessage = "CCCD không được để trống.")]
        public string CCCD { get; set; }

        [DisplayName("Giới tính")]
        public string GioiTinh { get; set; }

        [DisplayName("Ngày sinh")]
        [Required(ErrorMessage = "Ngày sinh không được để trống.")]
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }

        [DisplayName("Chức vụ")]
        public string ChucVu { get; set; }

        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Số điện không được để trống.")]
        public string DienThoai { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email không được để trống.")]
        public string Email { get; set; }

        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được để trống.")]
        public string DiaChi { get; set; }

        [DisplayName("Ngày vào làm")]
        [Required(ErrorMessage = "Ngày vào làm không được để trống.")]
        [DataType(DataType.Date)]

        public DateTime NgayVaoLam { get; set; }


        [DisplayName("Ghi chú")]

        public string? GhiChu { get; set; }
    }

}

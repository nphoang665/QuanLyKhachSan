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
        [Required(ErrorMessage = "Mã nhân viên là bắt buộc.")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Mã khách hàng phải là 6 kí tự")]
        public string MaKhachHang { get; set; }




     
        [DisplayName("Tên Khách Hàng")]
        [Required(ErrorMessage = "Tên khách hànglà bắt buộc.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Tên không được quá dài hoặc quá ngắn")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Tên không hợp lệ")]
        public string TenKhachHang { get; set; }





        [DisplayName("CCCD")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "CCCD Phải có 12 kí tự")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "CCCD phải không chứ chữ hoặc kí tự đặc biệt")]
        [Required(ErrorMessage = "CCCD là bắt buộc.")]

        public string CCCD { get; set; }








        [DisplayName("Giới Tính")]

        public string GioiTinh { get; set; }




        [DisplayName("Ngày Sinh")]
        [Required(ErrorMessage = "Ngày sinh là bắt buộc.")]

        public DateTime NgaySinh { get; set; }





        [DisplayName("Số Điện Thoại")]
        [Required(ErrorMessage = "Số điện thoại là bắt buộc.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Số điện thoại phai đúng 10 kí tự")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Số điện thoại không hợp lệ")]

        public string DienThoai { get; set; }
        [DisplayName("Địa Chỉ")]
        [Required(ErrorMessage = "Địa chỉ là bắt buộc.")]
        public string DiaChi { get; set; }



        [DisplayName("Ghi Chú")]
        [Required(ErrorMessage = "Ghi chú là bắt buộc.")]

        public string GhiChu { get; set; }

    }
}

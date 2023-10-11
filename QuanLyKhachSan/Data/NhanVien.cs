using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Model
{
    public class NhanVien
    {
        [Key]
        [DisplayName("Mã Nhân Viên")]
        [Required(ErrorMessage = "Mã nhân viên là bắt buộc.")]
        [StringLength(6,MinimumLength =6, ErrorMessage ="Mã nhân viên phải là 6 kí tự")]
        public string MaNhanVien { get; set; }




      
        [DisplayName("Tên Nhân Viên")]
        [Required(ErrorMessage = "Tên nhân viên là bắt buộc.")]
        [StringLength(60,MinimumLength =3,ErrorMessage ="Tên không được quá dài hoặc quá ngắn")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Tên không hợp lệ")]
        public string TenNhanVien { get; set; }





        [DisplayName("CCCD")]
        [StringLength(12,MinimumLength =12,ErrorMessage ="CCCD Phải có 12 kí tự")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "CCCD phải không chứ chữ hoặc kí tự đặc biệt")]
        [Required(ErrorMessage = "CCCD là bắt buộc.")]
        public string CCCD { get; set; }





        [DisplayName("Giới Tính")]
        public string GioiTinh { get; set; }





        [DisplayName("Ngày Sinh")]
        [Required(ErrorMessage = "Ngày sinh là bắt buộc.")]
        
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }




        [DisplayName("Chức Vụ")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Chức vụ không được quá dài hoặc quá ngắn")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Chức vụ không hợp lệ")]

        [Required(ErrorMessage = "Chức vụ là bắt buộc.")]

        public string ChucVu { get; set; }




        [DisplayName("Số Điện Thoại")]
        [Required(ErrorMessage = "Số điện thoại là bắt buộc.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Số điện thoại phai đúng 10 kí tự")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Số điện thoại không hợp lệ")]

        public string DienThoai { get; set; }



        [DisplayName("Địa Chỉ")]
        [Required(ErrorMessage = "Địa chỉ là bắt buộc.")]

        public string DiaChi { get; set; }




        [DisplayName("Ngày Vào Làm")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Ngày vào làm là bắt buộc.")]

        public DateTime NgayVaoLam { get; set; }




        [DisplayName("Ghi Chú")]

        public string GhiChu { get; set; }
    }

}

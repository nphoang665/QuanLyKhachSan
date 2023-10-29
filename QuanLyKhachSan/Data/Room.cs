using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Model
{
	public class Room
	{
        [Key]
        public string MaPhong { get; set; }
        [Required(ErrorMessage = "Khu vực không được để trống.")]
        public string KhuVuc { get; set; }
        public string HangPhong { get; set; }
        [Required(ErrorMessage = "Giá không được để trống.")]
        public int GiaTheoGio { get; set; }
        [Required(ErrorMessage = "Giá không được để trống.")]
        public int GiaTheoNgay { get; set; }
        public string TrangThai { get; set; }
    }
}

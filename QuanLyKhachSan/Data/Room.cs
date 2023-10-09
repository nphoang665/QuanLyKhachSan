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
        public string KhuVuc { get; set; }
        public string HangPhong { get; set; }
        public int GiaTheoGio { get; set; }
        public int GiaTheoQuaDem { get; set; }
        public int GiaTheoNgay { get; set; }
        public string TrangThai { get; set; }
    }
}

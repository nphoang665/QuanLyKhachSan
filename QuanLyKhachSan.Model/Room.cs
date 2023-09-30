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
		public double GiaTheoGio { get; set; }
		public double GiaTheoQuaDem { get; set; }
		public double GiaTheoNgay { get; set; }
		public string GhiChu { get; set; }
	}
}

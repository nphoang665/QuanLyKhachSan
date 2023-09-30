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
		public string Number { get; set; }
		public string Type { get; set; }
		public string Price { get; set; }
	}
}

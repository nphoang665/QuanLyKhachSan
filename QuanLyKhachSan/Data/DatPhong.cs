using QuanLyKhachSan.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class DatPhong
{
    [Key]
    public string MaDatPhong { get; set; }


    // Thêm khóa ngoại từ bảng NhanVien
    [ForeignKey("NhanVien")]
    public string MaNhanVien { get; set; }
    public virtual NhanVien NhanVien { get; set; }

    // Thêm khóa ngoại từ bảng Phong
    [ForeignKey("Phong")]
    public string MaPhong { get; set; }
    public virtual Room Phong { get; set; }

    // Thêm khóa ngoại từ bảng KhachHang
    [ForeignKey("KhachHang")]
    public string MaKhachHang { get; set; }
    public virtual KhachHang KhachHang { get; set; }
    public string HinhThuc { get; set; }
    public int GiaPhong { get; set; }
    public DateTime NgayNhan { get; set; }
    public DateTime NgayTra { get; set; }
    public string DuKien { get; set; }
    public float ThanhTien { get; set; }
}
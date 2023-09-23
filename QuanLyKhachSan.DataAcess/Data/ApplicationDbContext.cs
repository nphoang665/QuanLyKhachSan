using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanLyKhachSan.DataAcess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<TaiKhoan> TaiKhoan { get; set; }
    }
}

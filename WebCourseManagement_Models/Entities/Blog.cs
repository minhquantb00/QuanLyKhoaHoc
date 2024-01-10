using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class Blog : BaseEntity
    {
        public int SoLuotThich { get; set; }
        public int SoLuotBinhLuan { get; set; }
        public string AnhBlog { get; set; }
        public string LinkBlog { get; set; }
        public string TieuDeBlog { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DateTime? ThoiGianCapNhat { get; set; }
        public DateTime? ThoiGianXoa { get; set; }
        public int TrangThaiBlogId { get; set; }
        public int LoaiBlogId { get; set; }
        public int NguoiDangBaiId { get; set; }
        public virtual TrangThaiBlog? TrangThaiBlog { get; set; }
        public virtual LoaiBlog? LoaiBlog { get;set; }
        public virtual NguoiDung? NguoiDangBai { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

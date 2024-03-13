using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class ChuongHoc : BaseEntity
    {
        public string TenChuong { get; set; }
        public int TongThoiGianHocTrongChuong { get; set; }
        public int SoBaiHocTrongChuong { get; set; }
        public int KhoaHocId { get; set; }
        public string? AnhChuongHoc { get; set; }
        public virtual KhoaHoc? KhoaHoc { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DateTime? ThoiGianCapNhat { get; set; }
        public virtual ICollection<BaiHoc>? BaiHocs { get; set; }
        public bool? IsActive { get; set; } = true;
    }
}

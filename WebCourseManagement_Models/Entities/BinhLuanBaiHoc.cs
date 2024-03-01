using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class BinhLuanBaiHoc : BaseEntity
    {
        public int BaiHocId { get; set; }
        public virtual BaiHoc BaiHoc { get; set; }
        public int? NguoiDungId { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
        public string? BinhLuan { get; set; }
        public string? DuongDanAnhBinhLuan { get; set; }
        public int? BinhLuanGocId { get; set; }
        public int SoLuotLike { get; set; }
        public int SoLuotBinhLuanTraLoi { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DateTime? ThoiGianCapNhat { get; set; }
        public DateTime? ThoiGianXoa { get; set; }
        public int TrangThaiBinhLuanId { get; set; }
        public virtual TrangThaiBinhLuan TrangThaiBinhLuan { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class BinhLuanBaiViet : BaseEntity
    {
        public int BaiVietId { get; set; }
        public virtual BaiViet BaiViet { get; set; }
        public int? NguoiDungId { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
        public string? BinhLuan { get; set; }
        public string? DuongDanAnhBinhLuan { get; set; }
        public int? BinhLuanGocId { get; set; } // nếu có để coi như cái này là reply
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

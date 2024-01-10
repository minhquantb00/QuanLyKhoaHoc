using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class BaiViet : BaseEntity
    {
        public string TieuDe { get; set; }
        public string MoTaBaiViet { get; set; }
        public string AnhBaiViet { get; set; }
        public int NguoiDungTaoBaiId { get; set; }
        public virtual NguoiDung NguoiDungTaoBai { get; set; }
        public string DuLieuBaiViet { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DateTime? ThoiGianCapNhat { get; set; }
        public DateTime? ThoiGianXoa { get; set; }
        public int SoLuongThich { get; set; }
        public int SoLuotBinhLuan { get; set; }
        public int TrangThaiBaiVietId { get; set; }
        public virtual TrangThaiBaiViet TrangThaiBaiViet { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class BaiHoc : BaseEntity
    {
        public string TenBaiHoc { get; set; }
        public string MoTaBaiHoc { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DateTime? ThoiGianCapNhat { get; set; }
        public int ChuongHocId { get; set; }
        public virtual ChuongHoc? ChuongHoc { get; set; }
        public string VideoBaiHoc { get; set; }
        public int ThoiLuongVideo { get; set; }
        public int TrangThaiBaiHocId { get; set; }
        public virtual TrangThaiBaiHoc? TrangThaiBaiHoc { get; set; }
        public virtual ICollection<DatCauHoi>? DatCauHois { get; set; }
        public virtual ICollection<KhoaHocCuaNguoiDung> KhoaHocCuaNguoiDungs { get; set; }
        public virtual ICollection<BinhLuanBaiHoc> BinhLuanBaiHocs { get; set; }
        public virtual ICollection<ThucHanh> ThucHanhs { get; set; }
    }
}

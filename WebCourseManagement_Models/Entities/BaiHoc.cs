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
        public int LoaiBaiHocId { get; set; }
        public int ChuongKhoaHocId { get; set; }
        public virtual ChuongKhoaHoc ChuongKhoaHoc { get; set; }
        public virtual LoaiBaiHoc LoaiBaiHoc { get; set; }
        public int ThoiLuongVideo { get; set; }
        public int TrangThaiBaiHocId { get; set; }
        public virtual TrangThaiBaiHoc TrangThaiBaiHoc { get; set; }
        public virtual ICollection<BinhLuanBaiHoc> BinhLuanBaiHocs { get; set; }
    }
}

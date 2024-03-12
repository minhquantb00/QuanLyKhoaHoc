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
        public int NguoiBinhLuanId { get; set; }
        public virtual NguoiDung NguoiBinhLuan { get; set; }
        public string NoiDungBinhLuan { get; set; }
        public int? BinhLuanGocId { get; set; }
        public int SoLuotThich { get; set; }
        public int SoLuotTraLoiBinhLuan { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DateTime? ThoiGianCapNhat { get; set; }
        public DateTime? ThoiGianXoa { get; set; }
        public int TrangThaiBinhLuanId { get; set; }
        public virtual TrangThaiBinhLuan? TrangThaiBinhLuan { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<NguoiDungThichBinhLuanBaiHoc>? NguoiDungThichBinhLuanBaiHocs { get; set; }
    }
}

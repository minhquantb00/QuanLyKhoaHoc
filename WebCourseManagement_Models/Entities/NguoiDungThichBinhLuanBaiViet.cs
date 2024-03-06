using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class NguoiDungThichBinhLuanBaiViet : BaseEntity
    {
        public int NguoiDungThichBinhLuanId { get; set; }
        public virtual NguoiDung NguoiDungThichBinhLuan { get; set; }
        public int BinhLuanBaiVietId { get; set; }
        public virtual BinhLuanBaiViet BinhLuanBaiViet { get; set; }
        public DateTime ThoiGianThich { get; set; }
        public DateTime? ThoiGianBoThich { get; set; }
        public bool? DaThich { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class NguoiDungThichBaiViet : BaseEntity
    {
        public int NguoiDungId { get; set; }
        public virtual NguoiDung? NguoiDung { get; set; }
        public int BaiVietId { get; set; }
        public virtual BaiViet? BaiViet { get; set; }
        public DateTime ThoiGianThich { get; set; }
        public DateTime? ThoiGianBoThich { get; set; }
        public bool? DaThich { get; set; }
    }
}

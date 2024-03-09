using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class HoanThanhThucHanh : BaseEntity
    {
        public int NguoiDungId { get; set; }
        public virtual NguoiDung? NguoiDung { get; set; }
        public int ThucHanhId { get; set; }
        public virtual ThucHanh? ThucHanh { get; set; }
        public DateTime ThoiGianHoanThanh { get; set; }
        public int NgonNguId { get; set; }
        public virtual NgonNgu? NgonNgu { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class DiemKiemTraBaiHocCuaNguoiDung : BaseEntity
    {
        public int NguoiDungId { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
        public int BaiHocId { get; set; }
        public virtual BaiHoc BaiHoc { get; set; }
        public DateTime ThoiGianMoBaiHoc { get; set; }
        public bool DaHoanThanh { get; set; }
    }
}

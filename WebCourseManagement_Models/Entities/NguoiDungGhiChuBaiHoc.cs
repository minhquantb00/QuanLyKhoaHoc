using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class NguoiDungGhiChuBaiHoc : BaseEntity
    {
        public int DiemKiemTraBaiHocId { get; set; }
        public virtual DiemKiemTraBaiHocCuaNguoiDung DiemKiemTraBaiHoc { get; set; }
        public string NoiDung { get; set; }
        public DateTime ThoiGianGhiChu { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class NguoiDungThichBinhLuanBaiHoc : BaseEntity
    {
        public int NguoiDungId { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
        public int BinhLuanBaiHocId { get; set; }
        public virtual BinhLuanBaiHoc BinhLuanBaiHoc { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public bool DaXoa { get; set; }
    }
}

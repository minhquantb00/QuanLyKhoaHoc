using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class PhanHoc : BaseEntity
    {
        public int ChuongKhoaHocId { get; set; }
        public virtual ChuongKhoaHoc ChuongKhoaHoc { get; set; }
        public int BaiHocId { get; set; }
        public virtual BaiHoc BaiHoc { get; set; }
        public DateTime ThoiGianThemBaiHocVaoPhanHoc { get; set; }
    }
}

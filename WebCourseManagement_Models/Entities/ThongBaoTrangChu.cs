using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class ThongBaoTrangChu : BaseEntity
    {
        public string TieuDe { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public string NoiDung { get; set; }
        public int NguoiDungId { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
        public string LinkAnh { get; set; }
    }
}

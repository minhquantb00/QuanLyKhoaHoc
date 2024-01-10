using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class DanhHieuNguoiDung : BaseEntity
    {
        public int NguoiDungId { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
        public int DanhHieuId { get; set; }
        public virtual DanhHieu DanhHieu { get; set; }
    }
}

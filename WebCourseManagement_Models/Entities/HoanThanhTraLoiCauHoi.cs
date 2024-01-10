using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class HoanThanhTraLoiCauHoi : BaseEntity
    {
        public int CauHoiId { get; set; }
        public virtual DatCauHoi CauHoi { get; set; }
        public int NguoiDungId { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
        public string CauTraLoi { get; set; }
        public DateTime? ThoiGianHoanThanh { get; set; }
    }
}

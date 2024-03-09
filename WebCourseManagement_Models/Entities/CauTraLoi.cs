using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class CauTraLoi : BaseEntity
    {
        public int CauHoiId { get; set; }
        public virtual DatCauHoi? CauHoi { get; set; }
        public int NguoiTraLoiId { get; set; }
        public virtual NguoiDung? NguoiTraLoi { get; set; }
        public string CauTraLoiChiTiet { get; set; }
        public DateTime ThoiGianTraLoi { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class HoanThanhThucHanh : BaseEntity
    {
        public int NguoiDungId { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
        public int BaiHocThucHanhId { get; set; }
        public virtual ThucHanh BaiHocThucHanh { get; set; }
        public DateTime? ThoiGianHoanThanh { get; set; }
        public int? NgonNguId { get; set; }
        public virtual NgonNgu NgonNgu { get; set;}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class XacNhanEmail : BaseEntity
    {
        public int NguoiDungId { get; set; }
        public virtual NguoiDung NguoiDung { get; set;}
        public DateTime ThoiGianHetHan { get; set; }
        public string MaXacNhan { get; set; }
        public bool DaXacNhan { get; set; } = false;
    }
}

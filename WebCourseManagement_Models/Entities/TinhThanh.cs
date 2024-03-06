using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class TinhThanh : BaseEntity
    {
        public string TenTinhThanh { get; set; }
        public virtual ICollection<QuanHuyen> QuanHuyens { get; set; }
        public virtual ICollection<NguoiDung> NguoiDungs { get; set; }
    }
}

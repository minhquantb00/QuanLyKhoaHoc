using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class QuanHuyen : BaseEntity
    {
        public string TenQuanHuyen { get; set; }
        public int TinhThanhId { get; set; }
        public virtual TinhThanh? TinhThanh { get; set; }
        public virtual ICollection<NguoiDung>? NguoiDungs { get; set; }
        public virtual ICollection<XaPhuong>? XaPhuongs { get; set; }
    }
}

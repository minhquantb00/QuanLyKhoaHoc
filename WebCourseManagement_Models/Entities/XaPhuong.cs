using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class XaPhuong : BaseEntity
    {
        public string Code { get; set; }
        public string TenXaPhuong { get; set; }
        public string TenXaPhuongEnglish { get; set; }
        public int QuanHuyenId { get; set; }
        public virtual QuanHuyen QuanHuyen { get; set; }
    }
}

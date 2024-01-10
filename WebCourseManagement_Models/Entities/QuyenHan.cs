using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class QuyenHan : BaseEntity
    {
        public string MaQuyen { get; set; }
        public string TenQuyenHan { get; set; }
    }
}

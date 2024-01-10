using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class TinhThanh : BaseEntity
    {
        public string Code { get; set; }
        public string TenTinhThanh { get; set; }
        public string TenTinhThanhEnglish { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class CodeDaNgonNgu : BaseEntity
    {
        public string CodeKhoiDau { get; set; }
        public string CallTestCode { get; set; }
        public int NgonNguId { get; set; }
        public virtual NgonNgu NgonNgu { get; set;}
        public int ThucHanhId { get; set; }
        public virtual ThucHanh ThucHanh { get; set;}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class TrangThaiNguoiDung : BaseEntity
    {
        public string MaTrangThai { get; set; }
        public string TenTrangThai { get; set; }    
    }
}

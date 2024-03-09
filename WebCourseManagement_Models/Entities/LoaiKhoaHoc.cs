using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class LoaiKhoaHoc : BaseEntity
    {
        public string TenLoaiKhoaHoc { get; set; }
        public virtual ICollection<KhoaHoc>? KhoaHocs { get; set; }
    }
}

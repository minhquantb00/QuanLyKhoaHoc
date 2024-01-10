using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class TrangThaiBlog : BaseEntity
    {
        public string TenTrangThaiBlog { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
    }
}

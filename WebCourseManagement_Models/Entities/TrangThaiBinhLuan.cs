using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class TrangThaiBinhLuan : BaseEntity
    {
        public string TenTrangThai { get; set; }
        public virtual ICollection<BinhLuanBaiHoc> BinhLuanBaiHocs { get; set;}
        public virtual ICollection<BinhLuanBaiViet> BinhLuanBaiViets { get; set; }
    }
}

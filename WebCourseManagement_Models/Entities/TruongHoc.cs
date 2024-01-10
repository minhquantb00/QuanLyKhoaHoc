using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class TruongHoc : BaseEntity
    {
        public string TenTruongHoc { get; set; }
        public int LoaiTruongHocId { get; set; }
        public virtual LoaiTruongHoc? LoaiTruongHoc { get; set; }
    }
}

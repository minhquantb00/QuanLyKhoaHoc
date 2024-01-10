using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class KinhNghiemHocTap : BaseEntity
    {
        public int NguoiDungId { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
        public int TruongHocId { get; set; }
        public virtual TruongHoc TruongHoc { get; set; }
        public int ChuyenNganhId { get; set; }
        public virtual ChuyenNganh ChuyenNganh { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime? ThoiGianKetThuc { get; set; }
    }
}

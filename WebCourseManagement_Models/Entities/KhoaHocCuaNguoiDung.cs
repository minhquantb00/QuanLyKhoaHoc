using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class KhoaHocCuaNguoiDung : BaseEntity
    {
        public int NguoiDungId { get; set; }
        public virtual NguoiDung? NguoiDung { get; set; }
        public int KhoaHocId { get; set; }
        public virtual KhoaHoc? KhoaHoc { get; set; }
        public bool? DaHoanThanh { get; set; }
        public double PhanTramHoanThanh { get; set; }
        public DateTime ThoiGianDangKy { get; set; }
        public int? BaiHocHienTaiId { get; set; }
        public virtual BaiHoc? BaiHocHienTai { get; set; }
        public int? DanhGiaId { get; set; }
        public virtual DanhGia? DanhGia { get; set; }
    }
}

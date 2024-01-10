using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class KhoaHoc : BaseEntity
    {
        public string TenKhoaHoc { get; set; }
        public string TieuDeKhoaHoc { get; set; }
        public string AnhKhoaHoc { get; set; }
        public int SoBaiHoc { get; set; }
        public int SoChuong { get; set; }
        public int TongThoiGianBaiHoc { get; set; }
        public int SoNguoiDangKyKhoaHoc { get; set ; }
        public int SoHocVienDaHoanThanh { get; set; }
        public int TrangThaiKhoaHocId { get; set; }
        public virtual TrangThaiKhoaHoc TrangThaiKhoaHoc { get; set; }
        public int LoaiKhoaHocId { get; set; }
        public virtual LoaiKhoaHoc LoaiKhoaHoc { get; set; }
        public string? LinkVideoGioiThieu { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class HoaDonDangKy : BaseEntity
    {
        public decimal? TongTien { get; set; }
        public string MaGiaoDich { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public int NguoiDungId { get; set; }
        public virtual NguoiDung? NguoiDung { get; set; }
        public int KhoaHocId { get; set; }
        public virtual KhoaHoc? KhoaHoc { get; set; }
        public int TrangThaiHoaDonId { get; set; }
        public virtual TrangThaiHoaDon? TrangThaiHoaDon { get; set; }
    }
}

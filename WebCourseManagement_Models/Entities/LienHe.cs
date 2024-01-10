using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class LienHe : BaseEntity
    {
        public string TenNguoiLienHe { get; set; }
        public string SoDienThoai { get; set; }
        public bool DaLienHe { get; set; } = false;
        public DateTime ThoiGianGuiYeuCau { get; set; }
        public int? NguoiLienHeId { get; set; }
        public virtual NguoiDung NguoiLienHe { get; set; }
        public DateTime? ThoiGianLienHe { get; set; }
        public int? DanhGiaTheoSao { get; set; }
        public string? NoiDungDanhGia { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class KhoaHoc : BaseEntity
    {
        public string TieuDeKhoaHoc { get; set; }
        public string MoTaKhoaHoc { get; set; }
        public decimal GiaKhoaHoc { get; set; }
        public string AnhKhoaHoc { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public DateTime? NgayXoa { get; set; }
        public int TongThoiGianKhoaHoc { get; set; }
        public int SoHocVienDaHoanThanh { get; set; }
        public int NguoiTaoId { get; set; }
        public int LoaiKhoaHocId { get; set; }
        public virtual LoaiKhoaHoc LoaiKhoaHoc { get; set; }
        public bool IsActive { get; set; }
        public bool? DaXoa { get; set; }
        public virtual ICollection<ChuongHoc> ChuongHocs { get; set; }
        public virtual ICollection<KhoaHocCuaNguoiDung> KhoaHocCuaNguoiDungs { get; set; }
    }
}

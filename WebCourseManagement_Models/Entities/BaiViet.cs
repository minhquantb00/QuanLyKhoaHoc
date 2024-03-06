using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class BaiViet : BaseEntity
    {
        public string TieuDe { get; set; }
        public string MoTa { get; set; }
        public int TrangThaiBaiVietId { get; set; }
        public virtual TrangThaiBaiViet? TrangThaiBaiViet { get; set; }
        public string AnhBaiViet { get; set; }
        public int NguoiTaoBaiVietId { get; set; }
        public virtual NguoiDung? NguoiTaoBaiViet { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DateTime? ThoiGianCapNhat { get; set; }
        public DateTime? ThoiGianXoa { get; set; }
        public int SoLuotThich { get; set; }
        public int SoLuotBinhLuan { get; set; }
        public int LoaiBaiVietId { get; set; }
        public virtual LoaiBaiViet? LoaiBaiViet { get; set; }
        public virtual ICollection<BinhLuanBaiViet>? BinhLuanBaiViets { get; set; }
        public virtual ICollection<NguoiDungThichBaiViet>? NguoiDungThichBaiViets { get; set; }
    }
}

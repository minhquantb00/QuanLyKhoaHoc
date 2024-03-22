using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Commons.Enumerates;

namespace WebCourseManagement_Models.Entities
{
    public class BaoCao : BaseEntity
    {
        public int NguoiGuiBaoCaoId { get; set; }
        public int NguoiViPhamId { get; set; }
        public bool? DaXacMinh { get; set; } = false;
        public DateTime ThoiGianGuiBaoCao { get; set; }
        public DateTime? ThoiGianXacMinh { get; set; }
        public bool? DaViPham { get; set; }
        public string GhiChuBaoCao { get; set; }
        public int LoaiBaoCaoId { get; set; }
        public int? LoaiVanDeId { get; set; }
        public int? BinhLuanId { get; set; }
        public int? BaiVietId { get; set; }
        public Enums.LoaiComment? LoaiBinhLuan { get; set; }
        public virtual NguoiDung? NguoiGuiBaoCao { get; set; }
        public virtual LoaiBaoCao? LoaiBaoCao { get; set; }
    }
}

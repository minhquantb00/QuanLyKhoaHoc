using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataBaiHoc;
using WebCourseManagement_Models.ResponseModels.DataNguoiDung;

namespace WebCourseManagement_Models.ResponseModels.DataBinhLuanBaiHoc
{
    public class DataResponseBinhLuanBaiHoc
    {
        public  DataResponseBaiHoc DataResponseBaiHoc { get; set; }
        public DataResponseNguoiDung DataResponseNguoiDung { get; set; }
        public string? BinhLuan { get; set; }
        public string? DuongDanAnhBinhLuan { get; set; }
        public int? BinhLuanGocId { get; set; }
        public int SoLuotLike { get; set; }
        public int SoLuotBinhLuanTraLoi { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DateTime? ThoiGianCapNhat { get; set; }
        public DateTime? ThoiGianXoa { get; set; }
    }
}

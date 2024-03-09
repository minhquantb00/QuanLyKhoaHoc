using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataNguoiDung;
using WebCourseManagement_Models.ResponseModels.DataNguoiDungThichBinhLuanBaiHoc;

namespace WebCourseManagement_Models.ResponseModels.DataBinhLuanBaiHoc
{
    public class DataResponseBinhLuanBaiHoc : DataResponseBase
    {
        public DataResponseNguoiDung NguoiBinhLuan { get; set; }
        public string DuongDanAnhBinhLuan { get; set; }
        public int? BinhLuanGocId { get; set; }
        public int SoLuotThich { get; set; }
        public int SoLuotTraLoiBinhLuan { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DateTime? ThoiGianCapNhat { get; set; }
        public DateTime? ThoiGianXoa { get; set; }
        public IQueryable<DataResponseNguoiDungThichBinhLuanBaiHoc> NguoiDungThichBinhLuanBaiHocs { get; set; }
    }
}

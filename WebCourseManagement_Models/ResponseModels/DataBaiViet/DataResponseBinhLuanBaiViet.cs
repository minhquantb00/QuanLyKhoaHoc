using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataNguoiDung;

namespace WebCourseManagement_Models.ResponseModels.DataBaiViet
{
    public class DataResponseBinhLuanBaiViet : DataResponseBase
    {
        public DataResponseNguoiDung NguoiBinhLuan { get; set; }
        public string NoiDungBinhLuan { get; set; }
        public int SoLuotThich { get; set; }
        public int SoLuotTraLoiBinhLuan { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DateTime? ThoiGianCapNhat { get; set; }
        public IQueryable<DataResponseNguoiDungThichBinhLuanBaiViet>? NguoiDungThichBinhLuanBaiViets { get; set; }
    }
}

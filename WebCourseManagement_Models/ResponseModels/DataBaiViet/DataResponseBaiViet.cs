using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataNguoiDung;

namespace WebCourseManagement_Models.ResponseModels.DataBaiViet
{
    public class DataResponseBaiViet : DataResponseBase
    {
        public string TieuDe { get; set; }
        public string MoTa { get; set; }
        public string AnhBaiViet { get; set; }
        public DataResponseNguoiDung NguoiTaoBaiViet { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DateTime? ThoiGianCapNhat { get; set; }
        public DateTime? ThoiGianXoa { get; set; }
        public int SoLuotThich { get; set; }
        public int SoLuotBinhLuan { get; set; }
        public IQueryable<DataResponseBinhLuanBaiViet>? BinhLuanBaiViets { get; set; }
        public IQueryable<DataResponseNguoiDungThichBaiViet>? NguoiDungThichBaiViets { get; set; }
    }
}

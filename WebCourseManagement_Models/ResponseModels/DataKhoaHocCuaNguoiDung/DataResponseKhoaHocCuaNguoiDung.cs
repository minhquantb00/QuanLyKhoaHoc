using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataBaiHoc;
using WebCourseManagement_Models.ResponseModels.DataDanhGia;
using WebCourseManagement_Models.ResponseModels.DataKhoaHoc;
using WebCourseManagement_Models.ResponseModels.DataNguoiDung;

namespace WebCourseManagement_Models.ResponseModels.DataKhoaHocCuaNguoiDung
{
    public class DataResponseKhoaHocCuaNguoiDung : DataResponseBase
    {
        public DataResponseNguoiDung NguoiDung { get; set; }
        public DataResponseKhoaHoc KhoaHoc { get; set; }
        public string DaHoanThanh { get; set; }
        public double PhanTramHoanThanh { get; set; }
        public DateTime ThoiGianDangKy { get; set; }
        public DataResponseBaiHoc BaiHocHienTai { get; set; }
        public DataResponseDanhGia DanhGia { get; set; }
    }
}

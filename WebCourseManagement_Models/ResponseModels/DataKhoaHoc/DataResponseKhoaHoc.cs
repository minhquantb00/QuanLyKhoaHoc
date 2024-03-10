using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataChuongHoc;
using WebCourseManagement_Models.ResponseModels.DataNguoiDung;

namespace WebCourseManagement_Models.ResponseModels.DataKhoaHoc
{
    public class DataResponseKhoaHoc : DataResponseBase
    {
        public string TieuDeKhoaHoc { get; set; }
        public string MoTaKhoaHoc { get; set; }
        public decimal GiaKhoaHoc { get; set; }
        public string AnhKhoaHoc { get; set; }
        public decimal? PhanTramGiamGia { get; set; }
        public decimal? GiaKhoaHocThucTe { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public DateTime? NgayXoa { get; set; }
        public int TongThoiGianKhoaHoc { get; set; }
        public int SoHocVienDaHoanThanh { get; set; }
        public DataResponseNguoiDung NguoiTao { get; set; }
        public  IQueryable<DataResponseChuongHoc> ChuongHocs { get; set; }
    }
}

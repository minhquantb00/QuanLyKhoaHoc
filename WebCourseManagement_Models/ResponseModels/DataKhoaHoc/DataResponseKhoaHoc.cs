using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataNguoiDung;

namespace WebCourseManagement_Models.ResponseModels.DataKhoaHoc
{
    public class DataResponseKhoaHoc
    {
        public string TenKhoaHoc { get; set; }
        public string MoTa { get; set; }
        public string AnhKhoaHoc { get; set; }
        public int SoBaiHoc { get; set; }
        public int SoChuong { get; set; }
        public decimal GiaKhoaHoc { get; set; }
        public  DataResponseNguoiDung NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public int TongThoiGianBaiHoc { get; set; }
        public int SoNguoiDangKyKhoaHoc { get; set; }
        public int SoHocVienDaHoanThanh { get; set; }
        public string TenLoaiKhoaHoc { get; set; }
        public string? LinkVideoGioiThieu { get; set; }
    }
}

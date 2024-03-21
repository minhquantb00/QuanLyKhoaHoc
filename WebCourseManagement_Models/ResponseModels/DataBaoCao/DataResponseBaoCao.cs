using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Commons.Enumerates;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataBaiViet;
using WebCourseManagement_Models.ResponseModels.DataBinhLuanBaiHoc;
using WebCourseManagement_Models.ResponseModels.DataNguoiDung;

namespace WebCourseManagement_Models.ResponseModels.DataBaoCao
{
    public class DataResponseBaoCao : DataResponseBase
    {
        public DataResponseNguoiDung NguoiGuiBaoCao { get; set; }
        public DataResponseNguoiDung NguoiViPham { get; set; }
        public string DaXacMinh { get; set; }
        public DateTime ThoiGianGuiBaoCao { get; set; }
        public DateTime? ThoiGianXacMinh { get; set; }
        public string DaViPham { get; set; }
        public string GhiChuBaoCao { get; set; }
        public string TenLoaiBaoCao { get; set; }
        public DataResponseBaiViet BaiViet { get; set; }
        public DataResponseBinhLuanBaiViet? BinhLuanBaiViet { get; set; }
        public DataResponseBinhLuanBaiHoc? BinhLuanBaiHoc { get; set; }
        public string LoaiBinhLuan { get; set; }
    }
}

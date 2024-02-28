using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataKhoaHoc;

namespace WebCourseManagement_Models.ResponseModels.DataChuongHoc
{
    public class DataResponseChuongHoc : DataResponseBase
    {
        public DataResponseKhoaHoc DataKhoaHoc { get; set; }
        public string TenChuong { get; set; }
        public int TongThoiGianHoc1Chuong { get; set; }
        public int SoBaiHocTrongChuong { get; set; }
        public DateTime ThoiGianTao { get; set; }
    }
}

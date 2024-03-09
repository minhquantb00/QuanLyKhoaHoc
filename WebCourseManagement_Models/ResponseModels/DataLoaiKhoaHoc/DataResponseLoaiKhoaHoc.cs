using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.ResponseModels.DataKhoaHoc;

namespace WebCourseManagement_Models.ResponseModels.DataLoaiKhoaHoc
{
    public class DataResponseLoaiKhoaHoc : DataResponseBase
    {
        public string TenLoaiKhoaHoc { get; set; }
        public IQueryable<DataResponseKhoaHoc> DataResponseKhoaHocs { get; set; }
    }
}

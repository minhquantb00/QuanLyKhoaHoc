using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.RequestModels.ChuongHocRequests
{
    public class Request_SuaThongTinChuongHoc
    {
        public int ChuongHocId { get; set; }
        public string TenChuongHoc {  get; set; }
        [DataType(DataType.Upload)]
        public IFormFile? AnhChuongHoc { get; set; }
    }
}

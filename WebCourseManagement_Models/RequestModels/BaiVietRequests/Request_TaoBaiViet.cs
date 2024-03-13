using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;

namespace WebCourseManagement_Models.RequestModels.BaiVietRequests
{
    public class Request_TaoBaiViet
    {
        public string TieuDe { get; set; }
        public string MoTa { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile? AnhBaiViet { get; set; }
        public int LoaiBaiVietId { get; set; }
    }
}

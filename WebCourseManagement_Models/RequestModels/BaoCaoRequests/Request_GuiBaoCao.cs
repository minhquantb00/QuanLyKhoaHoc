using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Commons.Enumerates;
using WebCourseManagement_Models.Entities;

namespace WebCourseManagement_Models.RequestModels.BaoCaoRequests
{
    public class Request_GuiBaoCao
    {
        public string GhiChuBaoCao { get; set; }
        public int? LoaiVanDeId { get; set; }
        public int? BinhLuanId { get; set; }
        public int? BaiVietId { get; set; }
        public Enums.LoaiComment? LoaiBinhLuan { get; set; }
    }
}

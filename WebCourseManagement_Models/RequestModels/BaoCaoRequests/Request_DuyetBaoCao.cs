using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Commons.Enumerates;

namespace WebCourseManagement_Models.RequestModels.BaoCaoRequests
{
    public class Request_DuyetBaoCao
    {
        public int BaoCaoId { get; set; }
        public Enums.XacMinhViPham XacMinhViPham { get; set; }
    }
}

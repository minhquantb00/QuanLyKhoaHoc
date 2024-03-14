using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.RequestModels.ThichBaiVietRequests;
using WebCourseManagement_Models.Responses;

namespace WebCourseManagement_Business.Interfaces
{
    public interface INguoiDungThichBaiVietService
    {
        Task<string> LikeBaiViet(int nguoiDungId, Request_ThichBaiViet request);
    }
}

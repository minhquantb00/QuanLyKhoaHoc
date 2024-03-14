using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.RequestModels.NguoiDungThichBinhLuanBaiHocRequests;
using WebCourseManagement_Models.RequestModels.NguoiDungThichBinhLuanBaiVietRequests;

namespace WebCourseManagement_Business.Interfaces
{
    public interface IThichBinhLuanBaiVietService
    {
        Task<string> ThichBinhLuanBaiViet(int nguoiDungId, Request_NguoiDungThichBinhLuanBaiViet request);
    }
}

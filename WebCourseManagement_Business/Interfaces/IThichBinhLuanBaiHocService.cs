using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.RequestModels.NguoiDungThichBinhLuanBaiHocRequests;
using WebCourseManagement_Models.ResponseModels.DataNguoiDungThichBinhLuanBaiHoc;
using WebCourseManagement_Models.Responses;

namespace WebCourseManagement_Business.Interfaces
{
    public interface IThichBinhLuanBaiHocService
    {
        Task<string> ThichBinhLuanBaiHoc(int nguoiDungId, Request_ThichBinhLuanBaiHoc request);
    }
}

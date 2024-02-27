using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Business.Interfaces;
using WebCourseManagement_Models.RequestModels.KhoaHocRequests;
using WebCourseManagement_Models.ResponseModels.DataKhoaHoc;
using WebCourseManagement_Models.Responses;

namespace WebCourseManagement_Business.Implements
{
    public class KhoaHocService : IKhoaHocService
    {
        public Task<ResponseObject<DataResponseKhoaHoc>> ThemKhoaHoc(Request_ThemKhoaHoc request)
        {
            throw new NotImplementedException();
        }
    }
}

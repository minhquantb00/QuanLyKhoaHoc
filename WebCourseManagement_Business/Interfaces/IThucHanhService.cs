using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.RequestModels.ThucHanhRequests;
using WebCourseManagement_Models.ResponseModels.DataThucHanh;
using WebCourseManagement_Models.Responses;

namespace WebCourseManagement_Business.Interfaces
{
    public interface IThucHanhService
    {
        Task<ResponseObject<DataResponseThucHanh>> ThemYeuCauThucHanh(Request_ThemYeuCauThucHanh request);
    }
}

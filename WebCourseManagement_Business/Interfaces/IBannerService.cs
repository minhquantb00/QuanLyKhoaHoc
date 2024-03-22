using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.RequestModels.BannerRequest;
using WebCourseManagement_Models.ResponseModels.DataBanner;
using WebCourseManagement_Models.Responses;

namespace WebCourseManagement_Business.Interfaces
{
    public interface IBannerService
    {
        Task<ResponseObject<DataResponseBanner>> TaoBanner(Request_TaoBanner request);
    }
}

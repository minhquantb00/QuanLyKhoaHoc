using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.RequestModels.BaoCaoRequests;
using WebCourseManagement_Models.ResponseModels.DataBaoCao;
using WebCourseManagement_Models.Responses;

namespace WebCourseManagement_Business.Interfaces
{
    public interface IBaoCaoService
    {
        Task<ResponseObject<DataResponseBaoCao>> GuiBaoCao(int nguoiDungId, Request_GuiBaoCao request);
        Task<ResponseObject<DataResponseBaoCao>> DuyetBaoCao(Request_DuyetBaoCao request);
    }
}

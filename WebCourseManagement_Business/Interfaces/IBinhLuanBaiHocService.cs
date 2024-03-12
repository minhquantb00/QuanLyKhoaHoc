using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.RequestModels.BinhLuanBaiHocRequest;
using WebCourseManagement_Models.ResponseModels.DataBinhLuanBaiHoc;
using WebCourseManagement_Models.Responses;

namespace WebCourseManagement_Business.Interfaces
{
    public interface IBinhLuanBaiHocService
    {
        Task<ResponseObject<DataResponseBinhLuanBaiHoc>> TaoBinhLuan(int nguoiDungId, Request_TaoBinhLuanBaiHoc request);
        Task<ResponseObject<DataResponseBinhLuanBaiHoc>> SuaBinhLuan(int nguoiDungId, Request_SuaBinhLuanBaiHoc request);
        Task<ResponseObject<DataResponseBinhLuanBaiHoc>> TraLoiBinhLuan(int nguoiDungId, Request_TraLoiBinhLuan request);
        Task<string> XoaBinhLuan(int binhLuanId);
    }
}

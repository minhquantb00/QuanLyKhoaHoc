using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.RequestModels.NguoiDungRequests;
using WebCourseManagement_Models.ResponseModels.DataNguoiDung;
using WebCourseManagement_Models.Responses;
using WebCourseManagement_Repositories.HandlePagination;

namespace WebCourseManagement_Business.Interfaces
{
    public interface IUserService
    {
        Task<IQueryable<DataResponseNguoiDung>> GetAlls();
        Task<ResponseObject<DataResponseNguoiDung>> GetNguoiDungById(int id);
        Task<ResponseObject<DataResponseNguoiDung>> CapNhatThongTinNguoiDung(int nguoiDungId, Request_CapNhatThongTinNguoiDung request);
        Task<string> NguoiDungXoaTaiKhoan(int id);
        Task<string> KhoaTaiKhoanNguoiDung(int id);
        Task<string> MoKhoaTaiKhanNguoiDung(int id);
    }
}

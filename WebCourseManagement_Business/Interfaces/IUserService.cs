using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.RequestModels.InputRequests;
using WebCourseManagement_Models.ResponseModels.DataNguoiDung;
using WebCourseManagement_Models.Responses;
using WebCourseManagement_Repositories.HandlePagination;

namespace WebCourseManagement_Business.Interfaces
{
    public interface IUserService
    {
        Task<PageResult<DataResponseNguoiDung>> GetAlls(InputUser input, int pageSize, int pageNumber);
        Task<ResponseObject<DataResponseNguoiDung>> GetUserById(int nguoiDungId);
    }
}

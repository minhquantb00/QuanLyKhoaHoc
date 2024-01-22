using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Business.Interfaces;
using WebCourseManagement_Models.RequestModels.InputRequests;
using WebCourseManagement_Models.ResponseModels.DataNguoiDung;
using WebCourseManagement_Repositories.HandlePagination;

namespace WebCourseManagement_Business.Implements
{
    public class UserService : IUserService
    {
        public Task<PageResult<DataResponseNguoiDung>> GetAlls(InputUser input, int pageSize, int pageNumber)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.RequestModels.TestCaseRequests;
using WebCourseManagement_Models.ResponseModels.DataTestCase;
using WebCourseManagement_Models.Responses;

namespace WebCourseManagement_Business.Interfaces
{
    public interface ITestCaseService
    {
        Task<ResponseObject<DataResponseTestCaseResult>> TaoTestCase(Request_TaoTestCase request);
    }
}

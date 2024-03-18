using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.ResponseModels.DataTestCase
{
    public class DataResponseTestCaseResult
    {
        public IQueryable<DataResponseTestCase> TestCases { get; set; }
    }
}

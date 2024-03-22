using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Commons.Enumerates;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataThucHanh;

namespace WebCourseManagement_Models.ResponseModels.DataTestCase
{
    public class DataResponseTestCase : DataResponseBase
    {
        public string Input { get; set; }
        public string Output { get; set; }
        public string ExpectOutput { get; set; }
        public Enums.TestCaseEnum Result { get; set; }
        public string RunTimeTotal { get; set; }
        public bool? LockTestCase { get; set; }
    }
}

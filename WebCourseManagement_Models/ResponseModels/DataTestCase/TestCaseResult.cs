using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;

namespace WebCourseManagement_Models.ResponseModels.DataTestCase
{
    public class TestCaseResult
    {
        public string ChiTietDauVao { get; set; }
        public string CodeDauVao { get; set; }
        public string MongDoiDauRa { get; set; }
        public bool? KhoaTestCase { get; set; }
    }
}

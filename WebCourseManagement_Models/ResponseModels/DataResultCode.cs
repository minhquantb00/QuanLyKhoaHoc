using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.ResponseModels
{
    public class DataResultCode
    {
        public bool Success { get; set; }
        public string Result { get; set; }
        public string Time { get; set; }
        public string Exception { get; set; }
    }
}

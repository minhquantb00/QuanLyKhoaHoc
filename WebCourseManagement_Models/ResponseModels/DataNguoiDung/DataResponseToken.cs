using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.ResponseModels.DataNguoiDung
{
    public class DataResponseToken : DataResponseBase
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DataResponseNguoiDung DataResponseNguoiDung { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Commons.Enumerates;

namespace WebCourseManagement_Models.ResponseModels
{
    public class DataGoogleResponse
    {
        public string HoVaTen { get; set; }
        public Enums.GioiTinh GioiTinh { get; set; }
        public string Image { get; set; }
        public string email { get; set; }
        public bool email_verified { get; set; }
        public string locale { get; set; }
    }
}

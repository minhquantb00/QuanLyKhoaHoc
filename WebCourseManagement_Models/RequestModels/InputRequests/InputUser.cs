using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.RequestModels.InputRequests
{
    public class InputUser
    {
        public string? HoVaTen { get; set; }
        public string? SoDienThoai { get; set; }
        public string? Email { get; set; }
        public int? QuyenHanId { get; set; }
    }
}

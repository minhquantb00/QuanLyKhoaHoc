using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class RefreshToken : BaseEntity
    {
        public int NguoiDungId { get; set; }
        public string Token { get; set; }
        public DateTime ThoiGianHetHan { get; set; }
    }
}

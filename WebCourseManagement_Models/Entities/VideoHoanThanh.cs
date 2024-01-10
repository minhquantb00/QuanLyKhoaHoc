using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class VideoHoanThanh : BaseEntity
    {
        public int VideoBaiGiangId { get; set; }
        public virtual VideoBaiGiang VideoBaiGiang { get; set;}
        public int NguoiDungId { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
        public DateTime ThoiGianHoanThanh { get; set; }
    }
}

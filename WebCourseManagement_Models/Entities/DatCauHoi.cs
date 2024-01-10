using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class DatCauHoi : BaseEntity
    {
        public int BaiHocId { get; set; }
        public virtual BaiHoc BaiHoc { get; set; }
        public string CauHoi { get; set; }
        public string CauTraLoiA { get; set; }
        public string CauTraLoiB { get; set; }
        public string CauTraLoiC { get; set; }
        public string CauTraLoiD { get; set; }
        public int SoCauTraLoi { get; set; }
    }
}

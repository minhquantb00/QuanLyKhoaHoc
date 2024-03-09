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
        public virtual BaiHoc? BaiHoc { get; set; }
        public string CauTraLoi { get; set; }
        public int SoCauTraLoi { get; set; }
        public virtual ICollection<CauTraLoi>? CauTraLois { get; set; }
    }
}

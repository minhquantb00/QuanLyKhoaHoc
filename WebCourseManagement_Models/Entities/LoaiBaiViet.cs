using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class LoaiBaiViet : BaseEntity
    {
        public string TenLoaiBaiViet { get; set; }
        public virtual ICollection<BaiViet>? BaiViets { get; set; }
    }
}

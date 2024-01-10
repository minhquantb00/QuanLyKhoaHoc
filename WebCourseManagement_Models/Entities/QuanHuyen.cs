using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class QuanHuyen : BaseEntity
    {
        public string Code { get; set; }
        public string TenQuanHuyen { get; set; }
        public string TenQuanHuyenEnglish { get; set; }
        public int TinhThanhId { get; set; }
        public virtual TinhThanh TinhThanh { get; set; }
    }
}

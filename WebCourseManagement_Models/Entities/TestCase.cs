using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class TestCase : BaseEntity
    {
        public int ThucHanhId { get; set; }
        public virtual ThucHanh ThucHanh { get; set; }
        public string ChiTietDauVao { get; set; }
        public string CodeDauVao { get; set; }
        public string MongDoiDauRa { get; set; }
        public bool? KhoaTestCase { get; set; }
    }
}

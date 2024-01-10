using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class NoiDungTrangChu : BaseEntity
    {
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string Slide1 { get; set; }
        public string Slide2 { get; set; }
        public string Slide3 { get; set; }
        public string Slide4 { get; set; }
        public string Slide5 { get; set; }
    }
}

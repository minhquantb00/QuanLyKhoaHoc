using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.Entities;

namespace WebCourseManagement_Models.ResponseModels.DataThucHanh
{
    public class DataResponseThucHanh
    {
        public string DeBai { get; set; }
        public string ChiTietDeBai { get; set; }
        public string CodeKhoiDau { get; set; }
        public string CallTestCode { get; set; }
        public string CodeDauVao { get; set; }
        public string MongDoiDauRa { get; set; }
        public string GiaiThich { get; set; }
        public string GoiY { get; set; }
    }
}

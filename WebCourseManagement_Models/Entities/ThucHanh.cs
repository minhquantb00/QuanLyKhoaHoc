using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class ThucHanh : BaseEntity
    {
        public string DeBai { get; set; }
        public string ChiTietDeBai { get; set; }
        public string CodeKhoiDau { get; set; }
        public string CallTestCode { get; set; }
        public string CodeDauVao { get; set; }
        public string MongDoiDauRa { get; set; }
        public string GiaiThich { get; set; }
        public string GoiY { get; set; }
        public int BaiHocId { get; set; }
        public virtual BaiHoc? BaiHoc { get; set; }
        public bool? HoTroDaNgonNgu { get; set; }
        public int NgonNguMacDinhId { get; set; }
        public virtual NgonNgu NgonNguMacDinh { get; set; }
    }
}

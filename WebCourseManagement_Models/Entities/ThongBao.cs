using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCourseManagement_Models.Entities
{
    public class ThongBao : BaseEntity
    {
        public int NguoiDungId { get; set; }
        public virtual NguoiDung? NguoiDung { get; set; }
        public int NguoiDungGuiThongBaoId { get; set; }
        public bool DaXemThongBao { get; set; } = false;
        public string NoiDungThongBao { get; set; }
        public DateTime ThoiGianThongBao { get; set; }
        public string LinkThongBao { get; set; }
        public bool HeThongThongBao { get; set; }
    }
}

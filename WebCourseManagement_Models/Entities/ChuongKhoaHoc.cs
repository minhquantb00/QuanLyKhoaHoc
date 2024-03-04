namespace WebCourseManagement_Models.Entities
{
    public class ChuongKhoaHoc : BaseEntity
    {
        public int KhoaHocId { get; set; }
        public virtual KhoaHoc? KhoaHoc { get; set; }
        public string TenChuong { get; set; }
        public int TongThoiGianHoc1Chuong { get; set; }
        public int SoBaiHocTrongChuong { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public virtual ICollection<BaiHoc>? BaiHocs { get; set; }
    }
}

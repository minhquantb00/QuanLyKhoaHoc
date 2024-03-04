namespace WebCourseManagement_Models.RequestModels.BaiHocRequets
{
    public class Request_ThemBaiHoc
    {
        public string TenBaiHoc { get; set; }
        public string MoTaBaiHoc { get; set; }
        public int LoaiBaiHocId { get; set; }
        public int ChuongKhoaHocId { get; set; }
        public int ThoiLuongVideo { get; set; }
    }
}

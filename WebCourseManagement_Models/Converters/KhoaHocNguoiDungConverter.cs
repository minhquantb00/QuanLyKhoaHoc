using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.DataContexts;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataKhoaHocCuaNguoiDung;

namespace WebCourseManagement_Models.Converters
{
    public class KhoaHocNguoiDungConverter
    {
        private readonly AppDbContext _context;
        private readonly KhoaHocConverter _khoaHocConverter;
        private readonly NguoiDungConverter _nguoiDungConverter;
        private readonly DanhGiaConverter _danhGiaConverter;
        private readonly BaiHocConverter _baiHocConverter;
        public KhoaHocNguoiDungConverter(AppDbContext context, KhoaHocConverter khoaHocConverter, NguoiDungConverter nguoiDungConverter, DanhGiaConverter danhGiaConverter, BaiHocConverter baiHocConverter)
        {
            _context = context;
            _baiHocConverter = baiHocConverter;
            _baiHocConverter = baiHocConverter;
            _danhGiaConverter = danhGiaConverter;
            _baiHocConverter = baiHocConverter;
        }
        public DataResponseKhoaHocCuaNguoiDung EntityToDTO(KhoaHocCuaNguoiDung khoaHocCuaNguoiDung)
        {
            return new DataResponseKhoaHocCuaNguoiDung
            {
                Id = khoaHocCuaNguoiDung.Id,
                BaiHocHienTai = _baiHocConverter.EntityToDTO(khoaHocCuaNguoiDung.BaiHocHienTai),
                DaHoanThanh = khoaHocCuaNguoiDung.DaHoanThanh == true ? "Đã hoàn thành" : "Chưa hoàn thành",
                DanhGia = _danhGiaConverter.EntityToDTO(khoaHocCuaNguoiDung.DanhGia),
                KhoaHoc = _khoaHocConverter.EntityToDTO(khoaHocCuaNguoiDung.KhoaHoc),
                NguoiDung = _nguoiDungConverter.EntityToDTO(khoaHocCuaNguoiDung.NguoiDung),
                PhanTramHoanThanh = khoaHocCuaNguoiDung.PhanTramHoanThanh,
                ThoiGianDangKy = khoaHocCuaNguoiDung.ThoiGianDangKy
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Models.DataContexts;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.ResponseModels.DataBaoCao;

namespace WebCourseManagement_Models.Converters
{
    public class BaoCaoConverter
    {
        private readonly AppDbContext _context;
        private readonly NguoiDungConverter _nguoiDungConverter;
        private readonly BinhLuanBaiHocConverter _binhLuanBaiHocConverter;
        private readonly BinhLuanBaiVietConverter _binhLuanBaiVietConverter;
        private readonly BaiVietConverter _baiVietConverter;
        public BaoCaoConverter(AppDbContext context, NguoiDungConverter nguoiDungConverter, BinhLuanBaiVietConverter binhLuanBaiVietConverter, BinhLuanBaiHocConverter binhLuanBaiHocConverter, BaiVietConverter baiVietConverter)
        {
            _context = context;
            _nguoiDungConverter = nguoiDungConverter;
            _binhLuanBaiHocConverter = binhLuanBaiHocConverter;
            _binhLuanBaiVietConverter = binhLuanBaiVietConverter;
            _baiVietConverter = baiVietConverter;
        }
        public DataResponseBaoCao EntityToDTO(BaoCao baoCao)
        {
            return new DataResponseBaoCao
            {
                BinhLuanBaiHoc = baoCao.LoaiBinhLuan.ToString().Equals("BaiHoc") == true ? _binhLuanBaiHocConverter.EntityToDTO(_context.binhLuanBaiHocs.SingleOrDefault(x => x.Id == baoCao.BinhLuanId)) : null,
                BinhLuanBaiViet = baoCao.LoaiBinhLuan.ToString().Equals("BaiViet") == true ? _binhLuanBaiVietConverter.EntityToDTO(_context.binhLuanBaiViets.SingleOrDefault(x => x.Id == baoCao.BinhLuanId)) : null,
                DaViPham = baoCao.DaViPham == true ? "Đã vi phạm" : "Không vi phạm",
                DaXacMinh = baoCao.DaXacMinh == true ? "Đã xác minh" : "Chưa xác minh",
                GhiChuBaoCao = baoCao.GhiChuBaoCao,
                Id = baoCao.Id,
                TenLoaiVanDe = _context.loaiVanDes.SingleOrDefault(x => x.Id == baoCao.LoaiVanDeId).TenLoaiVanDe,
                LoaiBinhLuan = baoCao.LoaiBinhLuan.ToString(),
                NguoiGuiBaoCao = _nguoiDungConverter.EntityToDTO(_context.nguoiDungs.SingleOrDefault(x => x.Id == baoCao.NguoiGuiBaoCaoId)),
                NguoiViPham = _nguoiDungConverter.EntityToDTO(_context.nguoiDungs.SingleOrDefault(x => x.Id == baoCao.NguoiViPhamId)),
                TenLoaiBaoCao = _context.loaiBaoCaos.SingleOrDefault(x => x.Id == baoCao.LoaiBaoCaoId).TenLoaiBaoCao,
                ThoiGianGuiBaoCao = baoCao.ThoiGianGuiBaoCao,
                ThoiGianXacMinh = baoCao.ThoiGianXacMinh,
                BaiViet = _baiVietConverter.EntityToDTO(_context.baiViets.SingleOrDefault(x => x.Id == baoCao.BaiVietId))
            };
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCourseManagement_Business.Interfaces;
using WebCourseManagement_Models.ConfigModels.MomoPayment;
using WebCourseManagement_Models.Converters;
using WebCourseManagement_Models.DataContexts;
using WebCourseManagement_Models.Entities;
using WebCourseManagement_Models.RequestModels.KhoaHocRequests;
using WebCourseManagement_Models.ResponseModels.DataHoaDon;
using WebCourseManagement_Models.ResponseModels.DataKhoaHoc;
using WebCourseManagement_Models.Responses;
using WebCourseManagement_Repositories.HandleImage;
using WebCourseManagement_Repositories.HandlePagination;

namespace WebCourseManagement_Business.Implements
{
    public class KhoaHocService : IKhoaHocService
    {
        private readonly AppDbContext _context;
        private readonly ResponseObject<DataResponseKhoaHoc> _responseObject;
        private readonly KhoaHocConverter _converter;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ResponseObject<DataResponseHoaDon> _responseObjectHoaDon;
        private readonly HoaDonConverter _hoaDonConverter;
        private readonly AuthService _authService;
        private readonly IConfiguration _configuration;
        public KhoaHocService(AppDbContext context, KhoaHocConverter converter, ResponseObject<DataResponseKhoaHoc> responseObject, IHttpContextAccessor httpContextAccessor, HoaDonConverter hoaDonConverter, ResponseObject<DataResponseHoaDon> responseObjectHoaDon, AuthService authService, IConfiguration configuration)
        {
            _context = context;
            _responseObject = responseObject;
            _converter = converter;
            _httpContextAccessor = httpContextAccessor;
            _hoaDonConverter = hoaDonConverter;
            _responseObjectHoaDon = responseObjectHoaDon;
            _authService = authService;
            _configuration = configuration;
        }
        public async Task<PageResult<DataResponseKhoaHoc>> GetAlls(int pageSize, int pageNumber)
        {
            var query = _context.khoaHocs.Where(x => x.IsActive == true).Select(x => _converter.EntityToDTO(x));
            var result = Pagination.GetPagedData(query, pageSize, pageNumber);
            return result;
        }

        public async Task<ResponseObject<DataResponseKhoaHoc>> GetKhoaHocById(int khoaHocId)
        {
            var khoaHoc = await _context.khoaHocs.SingleOrDefaultAsync(x => x.Id  == khoaHocId && x.IsActive == true);
            if (khoaHoc == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Không tìm thấy khóa học", null);
            }
            return _responseObject.ResponseSuccess("Lấy dữ liệu thành công", _converter.EntityToDTO(khoaHoc));
        }

        public async Task<ResponseObject<DataResponseKhoaHoc>> ThemKhoaHoc(int nguoiTaoId, Request_ThemKhoaHoc request)
        {
            var nguoiDung = await _context.nguoiDungs.SingleOrDefaultAsync(x => x.Id == nguoiTaoId);
            var loaiKhoaHoc = await _context.loaiKhoaHocs.SingleOrDefaultAsync(x => x.Id == request.LoaiKhoaHocId);
            if(loaiKhoaHoc == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Không tìm thấy loại khóa học", null);
            }
            KhoaHoc khoaHoc = new KhoaHoc
            {
                AnhKhoaHoc = await HandleUploadImage.Upfile(request.AnhKhoaHoc),
                IsActive = true,
                DaXoa = false,
                GiaKhoaHoc = request.GiaKhoaHoc,
                LoaiKhoaHocId = request.LoaiKhoaHocId,
                PhanTramGiamGia = request.PhanTramGiamGia == 0 ? 0 : request.PhanTramGiamGia,
                GiaKhoaHocThucTe = request.PhanTramGiamGia == 0 ? request.GiaKhoaHoc : request.GiaKhoaHoc - request.GiaKhoaHoc * request.PhanTramGiamGia,
                MoTaKhoaHoc = request.MoTaKhoaHoc,
                NgayTao = DateTime.Now,
                NguoiTaoId = nguoiTaoId,
                SoHocVienDaHoanThanh = 0,
                TieuDeKhoaHoc = request.TieuDeKhoaHoc,
                TongThoiGianKhoaHoc = 0,
                SoHocVienHocKhoaHoc = 0,
                TrailerKhoaHoc = request.TrailerKhoaHoc,
                SoSaoTrungBinh = 0
            };
            _context.khoaHocs.Add(khoaHoc);
            _context.SaveChanges();
            //var item = _context.khoaHocCuaNguoiDungs.Include(x => x.DanhGia).Where(x => x.KhoaHocId == khoaHoc.Id).ToList();
            //double tongSoSao = 0;
            //int tongSoVote = 0;
            //item.ForEach(x =>
            //{
            //    tongSoSao += x.DanhGia.SoSao;
            //    tongSoVote = _context.danhGias.Count(y => y.Id == x.DanhGia.Id); 
            //});
            //khoaHoc.SoSaoTrungBinh = tongSoSao * 1.0 / tongSoVote;
            //_context.SaveChanges();

            
            return _responseObject.ResponseSuccess("Thêm khóa học thành công", _converter.EntityToDTO(khoaHoc));
        }
        public async Task<ResponseObject<DataResponseKhoaHoc>> SuaThongTinKhoaHoc(int nguoiSuaId, Request_SuaThongTinKhoaHoc request)
        {
            var nguoiDung = await _context.nguoiDungs.SingleOrDefaultAsync(x => x.Id == nguoiSuaId);
            var khoaHoc = await _context.khoaHocs.SingleOrDefaultAsync(x => x.Id == request.KhoaHocId);
            var loaiKhoaHoc = await _context.loaiKhoaHocs.SingleOrDefaultAsync(x => x.Id == request.LoaiKhoaHocId);
            if(khoaHoc == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Không tìm thấy khóa học", null);
            }
            if(loaiKhoaHoc == null)
            {
                return _responseObject.ResponseError(StatusCodes.Status404NotFound, "Không tìm thấy loại khóa học", null);
            }
            if(nguoiSuaId != khoaHoc.NguoiTaoId)
            {
                return _responseObject.ResponseError(StatusCodes.Status400BadRequest, "Bạn không có quyền thực hiện chức năng này", null);
            }
            khoaHoc.MoTaKhoaHoc = request.MoTaKhoaHoc;
            khoaHoc.AnhKhoaHoc = await HandleUploadImage.Upfile(request.AnhKhoaHoc);
            khoaHoc.NgayCapNhat = DateTime.Now;
            khoaHoc.GiaKhoaHocThucTe = request.PhanTramGiamGia == 0 ? request.GiaKhoaHoc : request.GiaKhoaHoc - request.GiaKhoaHoc * request.PhanTramGiamGia;
            khoaHoc.PhanTramGiamGia = request.PhanTramGiamGia == 0 ? 0 : request.PhanTramGiamGia;
            khoaHoc.GiaKhoaHoc = request.GiaKhoaHoc;
            khoaHoc.LoaiKhoaHocId = request.LoaiKhoaHocId;
            khoaHoc.TieuDeKhoaHoc = request.TieuDeKhoaHoc;
            _context.SaveChanges();
            return _responseObject.ResponseSuccess("Cập nhật thông tin khóa học thành công", _converter.EntityToDTO(khoaHoc));
        }


        public async Task<string> XoaKhoaHoc(int khoaHocId)
        {
            var khoaHoc = await _context.khoaHocs.SingleOrDefaultAsync(x => x.Id == khoaHocId);
            var currentUser = _httpContextAccessor.HttpContext.User;
            var userId = currentUser.FindFirst("Id").Value;
            if (!currentUser.Identity.IsAuthenticated)
            {
                return "Người dùng chưa được xác thực";
            }
            if(khoaHoc == null)
            {
                return "Khóa học không tồn tại";
            }
            if(int.Parse(userId) != khoaHoc.NguoiTaoId)
            {
                return "Bạn không có quyền thực hiện chức năng này";
            }
            khoaHoc.IsActive = false;
            _context.SaveChanges();
            return "Xóa khóa học thành công";
        }
        public async Task<IQueryable<DataResponseKhoaHoc>> GetAllsKhoahoc()
        {
            return _context.khoaHocs.Where(x => x.IsActive == true).Select(x => _converter.EntityToDTO(x)).AsQueryable();
        }
        public async Task<ResponseObject<DataResponseHoaDon>> DangKyKhoaHoc(int nguoiDungId, Request_DangKyKhoaHoc request)
        {
            var nguoiDung = await _context.nguoiDungs.SingleOrDefaultAsync(x => x.Id == nguoiDungId);
            var khoaHoc = await _context.khoaHocs.SingleOrDefaultAsync(x => x.Id == request.KhoaHocId);
            if(khoaHoc == null)
            {
                return _responseObjectHoaDon.ResponseError(StatusCodes.Status404NotFound, "Khóa học không tồn tại", null);
            }
            HoaDonDangKy hoaDon = new HoaDonDangKy
            {
                KhoaHocId = request.KhoaHocId,
                MaGiaoDich = "MyBugs_" + DateTime.Now.Ticks.ToString() + new Random().Next(10000,99999).ToString(),
                NguoiDungId = nguoiDungId,
                ThoiGianTao = DateTime.Now,
                TongTien = khoaHoc.GiaKhoaHocThucTe,
                TrangThaiHoaDonId = 1
            };
            _context.hoaDonDangKies.Add(hoaDon);
            _context.SaveChanges();
            _authService.SendEmail(new WebCourseManagement_Repositories.EmailTo
            {
                To = nguoiDung.Email,
                Subject = "Thông báo đăng ký học",
                Content = "Bạn đã đăng ký học thành công! Vui lòng thanh toán"
            });
            return _responseObjectHoaDon.ResponseSuccess(PaymentMomo(hoaDon.Id), _hoaDonConverter.EntityToDTO(hoaDon));
        }
        private string PaymentMomo(int hoaDonId)
        {
            var hoaDon = _context.hoaDonDangKies.SingleOrDefault(x => x.Id == hoaDonId);
            var tongTien = hoaDon.TongTien;

            string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
            string partnerCode = "MOMOV2NN20220607";
            string accessKey = "zanxjP13gFbJCX2t";
            string serectkey = "slOO415FigGnrQzZQkk02qWcdCUFkbH2";
            string orderInfo = "test";
            string returnUrl = $"https://localhost:7046/api/user/DangKyKhoaHoc";
            string notifyurl = "https://momo.vn/notify";
            string amount = tongTien + "";
            string orderid = DateTime.Now.Ticks.ToString();
            string requestId = DateTime.Now.Ticks.ToString();
            string extraData = "";

            string rawHash = "partnerCode=" +
                partnerCode + "&accessKey=" +
                accessKey + "&requestId=" +
                requestId + "&amount=" +
                amount + "&orderId=" +
                orderid + "&orderInfo=" +
                orderInfo + "&returnUrl=" +
                returnUrl + "&notifyUrl=" +
            notifyurl + "&extraData=" +
            extraData;

            MomoSecurity crypto = new MomoSecurity();
            string signature = crypto.signSHA256(rawHash, serectkey);

            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "accessKey", accessKey },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderid },
                { "orderInfo", orderInfo },
                { "returnUrl", returnUrl },
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet"},
                { "signature", signature }

            };

            string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

            JObject jmessage = JObject.Parse(responseFromMomo);

            return jmessage.GetValue("payUrl").ToString();
        }

        public async Task<IQueryable<DataResponseKhoaHoc>> GetKhoaHocByNguoiDung(int nguoiDungId)
        {
            var result = _context.khoaHocs.Where(x => x.NguoiTaoId == nguoiDungId).Select(x => _converter.EntityToDTO(x));
            return result;
        }
    }
}
